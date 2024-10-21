/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 17/10/2024
 * @file MoverHaciaUnObjetoSinAnimacion.cs
 * @brief Este script permite mover un objeto hacia otro objeto especificado en la escena sin animar. Eje1
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que permite mover un objeto hacia otro objeto especificado en la escena.
public class MoverHaciaUnObjetoSinAnimacion : MonoBehaviour {
  public NotificadorColision notificador; // Suscripción a eventos de colisión.
  public float velocidad = 1f; // Velocidad de movimiento del objeto.
  public float velocidadRotacion = 5f; // Velocidad de rotación del objeto.
  public string nombreObjDestino = "Sphere"; // Nombre del objeto objetivo.
  private Vector3 direccion; // Dirección hacia el objeto objetivo.
  private GameObject obj2; // Referencia al objeto objetivo.
  private bool moverHaciaObjetivo = false; // Estado para controlar el movimiento.
  private Rigidbody rb; // Referencia al componente Rigidbody del objeto.
  // Inicializa el obj, su rigidbody y se suscribe al evento.
  private void Start() {
    obj2 = GameObject.Find(nombreObjDestino);
    if (obj2 != null) rb = GetComponent<Rigidbody>();
    if (notificador != null) notificador.OnColision += iniciarMovimiento;
  }
  // Mueve el objeto si se ha iniciado el movimiento.
  private void FixedUpdate() {
    if (moverHaciaObjetivo) moverHaciaObjeto();
  }
  // Método que se llama cuando se detecta una colisión.
  private void iniciarMovimiento() {
    moverHaciaObjetivo = true;
  }
  // Mueve el objeto hacia el objetivo.
  private void moverHaciaObjeto() {
    if (obj2 != null) {
      calcularVectorObj1Obj2();
      Vector3 nuevaPosicion = rb.position + (direccion.normalized * velocidad * Time.fixedDeltaTime);
      Quaternion direccionRotacion = Quaternion.LookRotation(direccion);
      Quaternion rotacionSuave = Quaternion.Slerp(rb.rotation, direccionRotacion, Time.deltaTime * velocidadRotacion);
      rb.MoveRotation(rotacionSuave);
      rb.MovePosition(nuevaPosicion);
    }
  }
  // Calcula la dirección desde el objeto actual hacia el objeto objetivo.
  private void calcularVectorObj1Obj2() {
    direccion = obj2.transform.position - transform.position; // (Destino - Origen).
    direccion.y = 0;
  }
  // Se llama cuando ocurre una colisión.
  private void OnCollisionEnter(Collision colision) {
    if (colision.gameObject.name == nombreObjDestino) moverHaciaObjetivo = false; // Detiene el movimiento al colisionar con el objeto objetivo.
  }
  // Se llama mientras se está colisionando con otro objeto.
  private void OnCollisionStay(Collision colision) {
    if (colision.gameObject.name == nombreObjDestino) moverHaciaObjetivo = false; // Detiene el movimiento mientras se colisiona con el objeto objetivo.
  }
  // Asegúrate de desuscribirte del evento al desactivar el objeto.
  private void OnDisable() {
    if (notificador != null) notificador.OnColision -= iniciarMovimiento;
  }
}
