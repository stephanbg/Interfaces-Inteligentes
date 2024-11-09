/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 7/11/2024
 * @file ElevarCamara.cs
 * @brief Este script permite elevar la cámara en el juego al mantener presionado 
 *        el botón de salto, deteniendo el movimiento si se detecta un obstáculo. Eje8
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que gestiona la elevación de la cámara.
public class ElevarCamara : MonoBehaviour {
  public float velocidadElevacion = 10f; // Velocidad de elevación de la cámara
  private float distanciaRaycast = 0.1f; // Distancia del raycast para detectar obstáculos
  // Método que se llama en cada frame.
  private void Update() {
    if (Input.GetButton("Jump")) {
      Vector3 movimiento = Vector3.up * velocidadElevacion * Time.deltaTime;
      RaycastHit hit;
      if (!Physics.Raycast(transform.position, movimiento.normalized, out hit, distanciaRaycast)) {
        transform.position += movimiento; 
      }
    }
  }
}
