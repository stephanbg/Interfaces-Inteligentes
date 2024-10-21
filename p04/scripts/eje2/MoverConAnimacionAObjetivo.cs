/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 17/10/2024
 * @file MoverConAnimacionAObjetivo.cs
 * @brief Este script permite mover un objeto hacia otro objeto
 *        especificado en la escena con animación. Eje2
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que permite mover un objeto hacia otro objeto especificado en la escena.
public class MoverConAnimacionAObjetivo : MonoBehaviour {
  public NotificadorColision notificador; // Suscripción al evento de colisión.
  public float velocidad = 1f; // Velocidad de movimiento del objeto.
  public float velocidadRotacion = 5f; // Velocidad de rotación.
  public string nombreObjDestino = "Egg_Red"; // Nombre del objeto objetivo.
  private Vector3 direccion; // Dirección hacia el objeto objetivo.
  private GameObject obj2; // Referencia al objeto objetivo.
  private bool moverHaciaObjetivo = false; // Estado para controlar el movimiento.
  private Rigidbody rb; // Referencia al componente Rigidbody.
  private Animator anim; // Referencia al componente Animator.
  // Se llama al inicio del script para inicializar las variables y suscribirse al evento de colisión.
  private void Start() {
    obj2 = GameObject.Find(nombreObjDestino);
    if (obj2 != null) {
      rb = GetComponent<Rigidbody>();
      anim = GetComponent<Animator>();
    }
    if (notificador != null) notificador.OnColision += iniciarMovimiento;
  }
  // Se llama en cada frame fijo y mueve el objeto hacia el objetivo si se ha iniciado el movimiento.
  private void FixedUpdate() {
    if (moverHaciaObjetivo) moverHaciaObjeto();
  }
  // Método que se activa al detectar una colisión con el objeto objetivo, iniciando el movimiento hacia él.
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
    direccion = obj2.transform.position - transform.position; // (Destino - Origen).
    direccion.y = 0;
  }
  // Se llama cuando ocurre una colisión con el objeto objetivo, deteniendo el movimiento y la animación.
  private void OnCollisionEnter(Collision colision) {
    if (colision.gameObject.name == nombreObjDestino) {
      moverHaciaObjetivo = false;
      anim.SetBool("IsRunning", false);
    }
  }
  // Se llama mientras se está colisionando con otro objeto, deteniendo el movimiento y la animación si es el objeto objetivo.
  private void OnCollisionStay(Collision colision) {
    if (colision.gameObject.name == nombreObjDestino) {
      moverHaciaObjetivo = false;
      anim.SetBool("IsRunning", false);
    }
  }  
  // Asegúrate de desuscribirte del evento al desactivar el objeto.
  private void OnDisable() {
    if (notificador != null) notificador.OnColision -= iniciarMovimiento;
  }
}
