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
 *        de flecha del teclado. La velocidad del movimiento se puede ajustar en 
 *        el inspector de Unity, y el objeto se mueve en el espacio global. Eje4
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que gestiona el movimiento de un objeto a través de las teclas de flecha.
public class MovimientoConFlechas : MonoBehaviour {
  // Velocidad de movimiento del objeto, ajustable en el inspector.
  public float velocidad = 5f;
  // Actualiza la posición del objeto en cada frame según la entrada del teclado. Lo mueve en el espacio global.
  private void Update() {
    float horizontal = 0f, vertical = 0f;
    if (Input.GetKey(KeyCode.UpArrow)) vertical = 1f;
    if (Input.GetKey(KeyCode.DownArrow)) vertical = -1f;
    if (Input.GetKey(KeyCode.LeftArrow)) horizontal = -1f;
    if (Input.GetKey(KeyCode.RightArrow)) horizontal = 1f;
    Vector3 movimiento = new Vector3(horizontal, 0, vertical) * velocidad * Time.deltaTime;
    transform.Translate(movimiento, Space.World);
  }
}
