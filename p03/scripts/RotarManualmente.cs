/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 10/10/2024
 * @file RotarManualmente.cs
 * @brief Este script permite a un objeto rotar sobre su eje Y (horizontalemente). Eje8
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que permite rotar un objeto manualmente mediante la entrada del teclado. Horizontalmente
public class RotarManualmente : MonoBehaviour {
  // Velocidad de rotación del objeto.
  public float velocidadRotacion = 100;
  /** Actualiza la rotación del objeto en cada frame según la entrada horizontal del teclado.
   *  Siempre gira sobre el eje Y del objeto de manera local.
   */
  private void Update() {
    float entradaHorizontal = Input.GetAxis("Horizontal");
    transform.Rotate(0, entradaHorizontal * velocidadRotacion * Time.deltaTime, 0);
  }
}
