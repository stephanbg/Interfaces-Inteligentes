/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 28/11/2024
 * @file NotificadorColisionCualquierObj.cs
 * @brief Este script notifica a otros objetos cuando colisiona con un objeto específico en la escena.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que notifica a otros objetos sobre colisiones específicas.
public class NotificadorColisionCualquierObj : MonoBehaviour {
  public delegate void colision(); // Delegado para el evento de colisión.
  public event colision OnColision; // Evento que se invoca cuando ocurre la colisión.
  // Se llama cuando este objeto colisiona con otro que no sea parte del escenario.
  private void OnCollisionEnter(Collision colision) { 
    if (colision.gameObject.tag != "escenario") { OnColision(); }
  }
}
