/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 17/10/2024
 * @file MoverRigidBodyConWASD.cs
 * @brief Este script permite mover un RigidBody perfecto, sin usar transform, solo con
 *        métodos como MovePosition. Eje1
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que permite mover un objeto Rigidbody utilizando las teclas de WASD.
public class MoverRigidBodyConWASD : MonoBehaviour {
  public float velocidad = 5f; // Velocidad a la que se moverá el objeto.
  private Rigidbody rb; // Referencia al componente Rigidbody del objeto.
  // Inicializa la referencia al Rigidbody en el inicio.
  private void Start() { rb = GetComponent<Rigidbody>(); }
  // Actualiza la posición del objeto según la entrada del teclado en cada frame.
  private void FixedUpdate() {
    float horizontal = 0f, vertical = 0f;
    if (Input.GetKey(KeyCode.W)) vertical = 1f;
    if (Input.GetKey(KeyCode.S)) vertical = -1f;
    if (Input.GetKey(KeyCode.A)) horizontal = -1f;
    if (Input.GetKey(KeyCode.D)) horizontal = 1f;
    Vector3 movimiento = new Vector3(horizontal, 0, vertical) * velocidad * Time.fixedDeltaTime;
    rb.MovePosition(rb.position + movimiento);
  }
}
