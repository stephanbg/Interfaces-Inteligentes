/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 17/10/2024
 * @file PuntuaRecoleccion.cs
 * @brief Este script puntúa la recolección de objetos al detectar
 *        una colisión y actualiza la puntuación. Eje5
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que se encarga de acumular la puntuación.
public class PuntuaRecoleccion : MonoBehaviour {
  public NotificadorColisionConTipo notificador; // Referencia al notificador de colisiones.
  public int puntos; // Puntos a sumar al recolectar el objeto.
  // Método que se llama al inicio del juego.
  private void Start() {
    if (notificador != null) notificador.OnColision += puntuar;
  }
  // Método que se llama para sumar puntos al recolectar.
  private void puntuar() {
    GestorPuntuacion.sumarPuntos(puntos);
    GestorPuntuacion.mostrarPuntos();
  }
  // Asegúrate de desuscribirte del evento al desactivar el objeto.
  private void OnDisable() {
    if (notificador != null) notificador.OnColision -= puntuar;
  }  
}
