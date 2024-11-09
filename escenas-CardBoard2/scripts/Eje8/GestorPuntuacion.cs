/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 7/11/2024
 * @file GestorPuntuacion.cs
 * @brief Este script gestiona la puntuación del juego, permitiendo sumar 
 *        puntos y mostrar la puntuación actual. Eje5
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que gestiona la puntuación del juego.
public class GestorPuntuacion : MonoBehaviour {
  private static int puntuacion = 0; // Almacena la puntuación actual del juego.
  // Suma una cantidad de puntos a la puntuación actual.
  public static void sumarPuntos(int puntos) {
    puntuacion += puntos;
  }
  // Muestra la puntuación actual en la consola.
  public static void mostrarPuntos() {
    Debug.Log("Puntuación actual: " + puntuacion);
  }
  // Devuelve la puntuación actual.
  public static int getPuntuacion() { 
    return puntuacion; 
  }
}
