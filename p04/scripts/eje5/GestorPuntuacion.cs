using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorPuntuacion : MonoBehaviour {
  public static void sumarPuntos(int puntos) {
    puntuacion += puntos;
  }
  public static void mostrarPuntos() {
    Debug.Log("Puntuación actual: " + puntuacion);
  }
  public static int getPuntuacion() { return puntuacion; }
  private static int puntuacion = 0;
}
