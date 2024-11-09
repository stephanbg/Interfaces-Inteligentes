/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 7/11/2024
 * @file ControlLuzLampara.cs
 * @brief Este script controla el encendido y apagado de una lámpara,
 *        así como el cambio de color de un objeto iluminado al activarse. Eje8
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que controla el estado de una lámpara y el color de un objeto iluminado mediante un notificador de clic
public class ControlLuzLampara : MonoBehaviour {
  public NotificadorOnClick notificador; // Notificador para detectar clics.
  public Light luz; // Componente de luz a controlar.
  public Renderer objetoAIluminar; // Objeto que será iluminado.
  private Color colorOriginal; // Color original del objeto a iluminar.
  // Inicializa el estado de la luz y el color original del objeto.
  private void Start() {
    colorOriginal = objetoAIluminar.material.color;
    luz.enabled = false;
    if (notificador != null) notificador.OnClick += cambioEstadoLampara;
  }
  // Cambia el estado de la luz y el color del objeto iluminado.
  private void cambioEstadoLampara() {
    luz.enabled = !luz.enabled;
    if (luz.enabled) objetoAIluminar.material.color = Color.yellow;
    else objetoAIluminar.material.color = colorOriginal;
  }
  // Desuscribirse del evento al desactivar el objeto.
  private void OnDisable() {
    if (notificador != null) notificador.OnClick -= cambioEstadoLampara;
  }
}
