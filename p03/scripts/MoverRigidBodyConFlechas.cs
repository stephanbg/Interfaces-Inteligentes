/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 10/10/2024
 * @file MoverRigidBodyConFlechas.cs
 * @brief Este script permite mover un RigidBody perfecto, sin usar transform, solo con
 *        métodos como MovePosition. Eje12
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que permite mover un objeto Rigidbody utilizando las teclas de flecha.
public class MoverRigidBodyConFlechas : MonoBehaviour {
  // Velocidad a la que se moverá el objeto.
  public float velocidad = 5f;
  // Referencia al componente Rigidbody del objeto.
  private Rigidbody rigidBody;
  // Inicializa la referencia al Rigidbody en el inicio.
  private void Start() {
    rigidBody = GetComponent<Rigidbody>();
  }
  // Actualiza la posición del objeto según la entrada del teclado en cada frame.
  private void Update() {
    float horizontal = 0f, vertical = 0f;
    if (Input.GetKey(KeyCode.UpArrow)) vertical = 1f;
    if (Input.GetKey(KeyCode.DownArrow)) vertical = -1f;
    if (Input.GetKey(KeyCode.LeftArrow)) horizontal = -1f;
    if (Input.GetKey(KeyCode.RightArrow)) horizontal = 1f;
    Vector3 movimiento = new Vector3(horizontal, 0, vertical) * velocidad * Time.deltaTime;
    rigidBody.MovePosition(rigidBody.position + movimiento);
  }
}
