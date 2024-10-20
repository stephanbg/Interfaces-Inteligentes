using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que permite mover un objeto hacia otro objeto especificado en la escena.
public class MoverConAnimacionAObjetivo: MonoBehaviour {
  public NotificadorColision notificador; // Suscripción
  public float velocidad = 1f; // Velocidad de movimiento del objeto.
  public float velocidadRotacion = 5f;
  public string nombreObjDestino = "Egg1"; // Nombre del objeto objetivo.
  private Vector3 direccion; // Dirección hacia el objeto objetivo.
  private GameObject obj2; // Referencia al objeto objetivo.
  private bool moverHaciaObjetivo = false; // Estado para controlar el movimiento.
  private Rigidbody rb;
  private Animator anim;
  private void Start() {
    obj2 = GameObject.Find(nombreObjDestino);
    rb = GetComponent<Rigidbody>();
    anim = GetComponent<Animator>();
    if (notificador != null) notificador.OnColision += iniciarMovimiento;
  }
  private void FixedUpdate() {
    if (moverHaciaObjetivo) moverHaciaObjeto();
  }
  // Método que se llama cuando se detecta una colisión.
  private void iniciarMovimiento() {
    moverHaciaObjetivo = true; // Cambia el estado para empezar a mover.
  }
  // Mueve el objeto hacia el objetivo.
  private void moverHaciaObjeto() {
    if (obj2 != null) {
      calcularVectorObj1Obj2();
      Vector3 nuevaPosicion = rb.position + (direccion.normalized * velocidad * Time.fixedDeltaTime);
      Quaternion direccionRotacion = Quaternion.LookRotation(direccion);
      Quaternion rotacionSuave = Quaternion.Slerp(rb.rotation, direccionRotacion, Time.deltaTime * velocidadRotacion);
      anim.SetBool("IsRunning", true);
      rb.MoveRotation(rotacionSuave);      
      rb.MovePosition(nuevaPosicion);  
    }
  }
  // Calcula la dirección desde el objeto actual hacia el objeto objetivo.
  private void calcularVectorObj1Obj2() {
    direccion = obj2.transform.position - transform.position; // Destino - Origen
    direccion.y = 0; // Ignorar el movimiento vertical.
  }
  private void OnCollisionEnter(Collision colision) {
    if (colision.gameObject.name == nombreObjDestino) {
      moverHaciaObjetivo = false;
      anim.SetBool("IsRunning", false);
    }
  }
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
