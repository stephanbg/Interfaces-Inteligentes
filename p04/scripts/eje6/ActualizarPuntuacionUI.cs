/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 17/10/2024
 * @file ActualizarPuntuacionUI.cs
 * @brief Este script actualiza la interfaz de usuario para mostrar
 *        la puntuación actual del jugador. Eje6
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Clase que gestiona la actualización de la puntuación en la UI.
public class ActualizarPuntuacionUI : MonoBehaviour {
  public TextMeshProUGUI textoPuntuacion; // Referencia al componente de texto de la UI.
  // Método que se llama al inicio del juego.
  private void Start() {
    textoPuntuacion.text = "Puntuación actual: 0";
  }
  // Método que se llama cada frame para actualizar la puntuación en la UI.
  private void Update() {
    textoPuntuacion.text = "Puntuación actual: " + GestorPuntuacion.getPuntuacion();
  }
}
