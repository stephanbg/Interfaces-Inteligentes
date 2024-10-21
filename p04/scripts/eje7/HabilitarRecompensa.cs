/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 17/10/2024
 * @file HabilitarRecompensa.cs
 * @brief Este script gestiona la visibilidad de la recompensa
 *        en función de la puntuación del jugador. Eje7
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Clase que habilita la visualización de recompensas al alcanzar una puntuación específica.
public class HabilitarRecompensa : MonoBehaviour {
  public Image imagenRecompensa; // Imagen de la recompensa a mostrar.
  public int cantidadParaRecompensa = 100; // Puntuación necesaria para habilitar la recompensa.
  private int ultimosPuntosMostrados = 0; // Últimos puntos mostrados para la recompensa.
  private TextMeshProUGUI textoRecompensa; // Componente de texto para mostrar la recompensa.
  // Método que se llama al inicio del juego.
  private void Start() {
    textoRecompensa = imagenRecompensa.GetComponentInChildren<TextMeshProUGUI>();
    controlVisibilidad(0);
  }
  // Método que se llama cada frame para verificar y mostrar la recompensa.
  private void Update() {
    if (imagenRecompensa.color.a == 1 && textoRecompensa.color.a == 1) {
      // Parar el juego hasta que se presione la tecla espacio.
      Time.timeScale = 0;
      if (Input.GetKey(KeyCode.Space)) {
        controlVisibilidad(0);
        Time.timeScale = 1; // Reanudar el juego.
      }
    } else {
      int puntos = GestorPuntuacion.getPuntuacion();
      if (
        (ultimosPuntosMostrados == 0 && puntos >= cantidadParaRecompensa) || /* primera vez */
        (puntos - ultimosPuntosMostrados >= cantidadParaRecompensa) // Resto de veces
      ) {
        // Redondeo al múltiplo de la recompensa inferior.
        puntos = (puntos / cantidadParaRecompensa) * cantidadParaRecompensa;
        ultimosPuntosMostrados = puntos;
        textoRecompensa.text = "Enhorabuena ha obtenido " + puntos + " pts !!!";
        controlVisibilidad(1);
      }
    }
  }
  // Controla la visibilidad de la imagen y el texto de la recompensa.
  private void controlVisibilidad(float alpha) {
    if (imagenRecompensa != null) {
      Color colorImagen = imagenRecompensa.color;
      colorImagen.a = alpha;
      imagenRecompensa.color = colorImagen;
    }
    if (textoRecompensa != null) {
      Color colorTexto = textoRecompensa.color;
      colorTexto.a = alpha;
      textoRecompensa.color = colorTexto;
    }
  }
}
