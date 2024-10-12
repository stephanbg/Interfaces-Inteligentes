/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 10/10/2024
 * @file GestorDeVelocidad.cs
 * @brief Este script permite gestionar y mostrar la velocidad de un objeto 
 *        en función de las teclas de dirección presionadas, multiplicando 
 *        la velocidad configurada por el valor de entrada horizontal y vertical. Eje1
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que gestiona la velocidad de un objeto basado en la entrada del teclado.
public class GestorDeVelocidad : MonoBehaviour  {
  // Velocidad base del objeto.
  public float velocidad = 5f;
  // Variables para almacenar la entrada horizontal y vertical.
  private float horizontal, vertical;
  // Actualiza la entrada del teclado y muestra la velocidad en la consola.
  private void Update() {
    horizontal = Input.GetAxis("Horizontal");
    vertical = Input.GetAxis("Vertical");
    if (Input.GetKey(KeyCode.UpArrow)) Debug.Log($"UpArrow: {velocidad * vertical}");
    if (Input.GetKey(KeyCode.DownArrow)) Debug.Log($"DownArrow: {velocidad * vertical}");
    if (Input.GetKey(KeyCode.LeftArrow)) Debug.Log($"LeftArrow: {velocidad * horizontal}");
    if (Input.GetKey(KeyCode.RightArrow)) Debug.Log($"RightArrow: {velocidad * horizontal}");
  }
}
