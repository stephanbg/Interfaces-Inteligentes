/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 10/10/2024
 * @file MovimientoConFlechas.cs
 * @brief Este script permite mover un objeto en la escena utilizando las teclas 
 *        de WASD. La velocidad del movimiento se puede ajustar en 
 *        el inspector de Unity, y el objeto se mueve en el espacio global. Eje4
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que gestiona el movimiento de un objeto a través de WASD.
public class MovimientoWASD : MonoBehaviour {
  // Velocidad de movimiento del objeto, ajustable en el inspector.
  public float velocidad = 5f;
  // Actualiza la posición del objeto en cada frame según la entrada del teclado. Lo mueve en el espacio global.
  private void Update() {
    float horizontal = 0f, vertical = 0f;
    if (Input.GetKey(KeyCode.W)) vertical = 1f;
    if (Input.GetKey(KeyCode.S)) vertical = -1f;
    if (Input.GetKey(KeyCode.A)) horizontal = -1f;
    if (Input.GetKey(KeyCode.D)) horizontal = 1f;
    Vector3 movimiento = new Vector3(horizontal, 0, vertical) * velocidad * Time.deltaTime;
    transform.Translate(movimiento, Space.World);
  }
}
