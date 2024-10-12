/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 10/10/2024
 * @file MoverForward.cs
 * @brief Este script permite a un objeto siempre avanzar en su eje Z (Forward). Eje8
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que mueve un objeto continuamente hacia adelante en su dirección local.
public class MoverForward : MonoBehaviour {
  // Velocidad a la que el objeto avanzará en su eje Z.
  public float velocidad = 1;
  // Actualiza la posición del objeto en cada frame para moverlo hacia adelante.
  private void Update() {
    transform.Translate(transform.forward * velocidad * Time.deltaTime);
  }
}
