/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 17/10/2024
 * @file VerInventario.cs
 * @brief Clase que gestiona la visualización del inventario en el juego. Eje8
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Clase que gestiona la visualización y control del inventario.
public class VerInventario : MonoBehaviour {
  private bool inventarioAbierto; // Indica si el inventario está abierto o cerrado.
  private CanvasGroup canvasGroup; // Referencia al CanvasGroup que controla la visibilidad del inventario.
  // Método que se llama al inicio del juego.
  private void Start() {
    inventarioAbierto = false;
    canvasGroup = GetComponent<CanvasGroup>();
    if (canvasGroup != null) {
      canvasGroup.alpha = 0; // Ocultar al inicio.
      canvasGroup.interactable = false; // No interactuable al inicio.
      canvasGroup.blocksRaycasts = false; // No bloquea raycasts.
    }
  }
  // Método que se llama en cada frame.
  private void Update() {
    if (Input.GetKeyDown(KeyCode.I)) cambiarEstadoInventario();
  }
  // Método para cambiar el estado del inventario.
  private void cambiarEstadoInventario() {
    inventarioAbierto = !inventarioAbierto;
    canvasGroup.alpha = inventarioAbierto ? 1 : 0; // Mostrar u ocultar el inventario.
    canvasGroup.interactable = inventarioAbierto; // Hacer interactuable si está visible.
    canvasGroup.blocksRaycasts = inventarioAbierto; // Permitir raycasts si está visible.
    // Pausar el juego.
    Time.timeScale = inventarioAbierto ? 0 : 1;
    cambiarEstadoInteraciones(inventarioAbierto);
  }

  // Método para cambiar el estado de las interacciones en la escena.
  private void cambiarEstadoInteraciones(bool estado) {
    // Desactivar/activar la interacción en la escena.
    foreach (var interactable in FindObjectsOfType<MonoBehaviour>()) {
      Collider collider = interactable.GetComponent<Collider>();
      // Desactivar el collider si el inventario está abierto.
      if (collider != null) collider.enabled = !estado;
    }
  }  
}
