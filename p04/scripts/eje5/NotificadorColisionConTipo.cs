/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 17/10/2024
 * @file NotificadorColisionConTipo.cs
 * @brief Este script notifica colisiones con objetos de tipos específicos
 *        definidos en un array. Eje5
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que notifica colisiones con tipos de objetos específicos.
public class NotificadorColisionConTipo : MonoBehaviour {
  public string[] tipos = {"Tipo1_huevo", "Tipo2_huevo"}; // Array de tipos de objetos que generan colisión.
  public delegate void colision(); // Delegado para el evento de colisión.
  public event colision OnColision; // Evento que se invoca al detectar una colisión.
  // Método que se llama al entrar en colisión con otro objeto. Si es del tipo especificado se lanza el evento.
  private void OnCollisionEnter(Collision colision) {
    foreach (string tipo in tipos) {
      if (colision.gameObject.CompareTag(tipo)) {
        OnColision();
        break;
      }
    }
  }
}
