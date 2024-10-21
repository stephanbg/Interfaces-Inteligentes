/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 17/10/2024
 * @file MoverConAnimacionARandGrupo.cs
 * @brief Este script permite mover un objeto hacia un objeto aleatorio
 *        de un grupo en la escena, cambiando su color al colisionar. Eje3
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Clase que permite mover un objeto hacia un objetivo aleatorio de un grupo especificado.
 * Además, cambia el color del objeto si colisiona.
 */
public class MoverConAnimacionARandGrupo : MonoBehaviour {
  public NotificadorColision[] notificadores; // Array de notificadores para suscribirse a eventos de colisión.
  public float velocidad = 1f; // Velocidad de movimiento del objeto.
  public float velocidadRotacion = 5f; // Velocidad de rotación del objeto.
  public string tipo = "Tipo2_huevo"; // Tag del tipo de objeto objetivo a buscar.
  private Vector3 direccion; // Dirección hacia el objeto objetivo.
  private GameObject obj2; // Referencia al objeto objetivo seleccionado aleatoriamente.
  private bool moverHaciaObjetivo = false; // Estado para controlar el movimiento.
  private Rigidbody rb; // Referencia al componente Rigidbody.
  private Animator anim; // Referencia al componente Animator.
  private Renderer rd; // Referencia al componente Renderer para cambiar el color.

  // Se llama al inicio del script para encontrar un objeto aleatorio del tipo especificado y suscribirse a los eventos de colisión.
  private void Start() {
    GameObject[] objetosTipo2 = GameObject.FindGameObjectsWithTag(tipo);
    if (objetosTipo2 != null) {
      int randomIndice = Random.Range(0, objetosTipo2.Length);
      obj2 = objetosTipo2[randomIndice]; // Asigna el objeto objetivo aleatorio.
      if (obj2 != null) {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rd = GetComponentInChildren<Renderer>();
      }
    }
    if (notificadores != null) {
      foreach (NotificadorColision notificador in notificadores) {
        if (notificador != null) notificador.OnColision += iniciarMovimiento;
      }
    }
  }
  // Se llama en cada frame fijo y mueve el objeto hacia el objetivo si se ha iniciado el movimiento.
  private void FixedUpdate() {
    if (moverHaciaObjetivo) moverHaciaObjeto();
  }
  // Método que se llama cuando se detecta una colisión, iniciando el movimiento hacia el objeto objetivo.
  private void iniciarMovimiento() {
    moverHaciaObjetivo = true;
  }
  // Mueve el objeto hacia el objetivo, aplicando rotación y animación de movimiento.
  private void moverHaciaObjeto() {
    if (obj2 != null) {
      calcularVectorObj1Obj2();
      Vector3 nuevaPosicion = rb.position + (direccion.normalized * velocidad * Time.fixedDeltaTime);
      Quaternion direccionRotacion = Quaternion.LookRotation(direccion);
      Quaternion rotacionSuave = Quaternion.Slerp(rb.rotation, direccionRotacion, Time.fixedDeltaTime * velocidadRotacion);
      anim.SetBool("IsRunning", true);
      rb.MoveRotation(rotacionSuave);
      rb.MovePosition(nuevaPosicion);
    }
  }
  // Calcula la dirección desde el objeto actual hacia el objeto objetivo, ignorando el eje Y.
  private void calcularVectorObj1Obj2() {
    direccion = obj2.transform.position - transform.position; // Calcula el vector dirección (Destino - Origen).
    direccion.y = 0;
  }
  // Se llama cuando ocurre una colisión con un objeto del tipo especificado, cambiando el color del objeto y deteniendo el movimiento.
  private void OnCollisionEnter(Collision colision) {
    if (colision.gameObject.CompareTag(tipo) && moverHaciaObjetivo) {
      rd.material.color = new Color(Random.value, Random.value, Random.value);
      moverHaciaObjetivo = false;
      anim.SetBool("IsRunning", false);
    }
  }
  // Se llama mientras se está colisionando con otro objeto del tipo especificado, deteniendo el movimiento y la animación.
  private void OnCollisionStay(Collision colision) {
    if (colision.gameObject.CompareTag(tipo) && moverHaciaObjetivo) {
      moverHaciaObjetivo = false;
      anim.SetBool("IsRunning", false);
    }
  }  
  // Asegúrate de desuscribirte de los eventos al desactivar el objeto.
  private void OnDisable() {
    foreach (NotificadorColision notificador in notificadores) {
      if (notificador != null) notificador.OnColision -= iniciarMovimiento;
    }
  }
}
