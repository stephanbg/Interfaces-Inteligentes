/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 7/11/2024
 * @file NotificadorOnClick.cs
 * @brief Clase que notifica eventos de clic sobre un objeto en Unity. Eje8
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que gestiona la notificación de clics en el objeto.
public class NotificadorOnClick : MonoBehaviour {
  public delegate void click(); // Delegado para el evento OnClick.
  public event click OnClick; // Evento que se activa al hacer clic en el objeto.
  // Método que se llama cuando se detecta un clic del ratón sobre el objeto.
  private void OnMouseDown() { OnClick(); }
  //private void OnPointerClick() { OnClick(); }
}
