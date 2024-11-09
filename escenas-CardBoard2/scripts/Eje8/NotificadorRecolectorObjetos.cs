/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 7/11/2024
 * @file NotificadorRecolectorObjetos.cs
 * @brief Clase que notifica la recolección de objetos al hacer clic en ellos. Eje8
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que gestiona la notificación de recolección de objetos.
public class NotificadorRecolectorObjetos : MonoBehaviour {
  public delegate void click(GameObject obj); // Delegado para el evento OnClick, que pasa el objeto recolectado.
  public event click OnClick; // Evento que se activa al hacer clic en el objeto.
  // Método que se llama cuando se detecta un clic del ratón sobre el objeto.
  private void OnMouseDown() { OnClick(gameObject); }
}
