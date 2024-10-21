/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 17/10/2024
 * @file NotificadorColision.cs
 * @brief Este script notifica a otros objetos cuando colisiona con un objeto específico en la escena.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que notifica a otros objetos sobre colisiones específicas.
public class NotificadorColision : MonoBehaviour {
  public string nombreObjColision = "Cube"; // Nombre del objeto con el que se detectará la colisión.
  public delegate void colision(); // Delegado para el evento de colisión.
  public event colision OnColision; // Evento que se invoca cuando ocurre la colisión.
  // Se llama cuando este objeto colisiona con otro.
  private void OnCollisionEnter(Collision colision) {
    /* Verifica si el objeto colisionado es el que se busca.
       Invoca el evento si hay colisión con el objeto objetivo.*/
    if (colision.gameObject.name == nombreObjColision) OnColision();
  }
}
