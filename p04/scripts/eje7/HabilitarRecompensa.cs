using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HabilitarRecompensa : MonoBehaviour {
  public Image imagenRecompensa;
  public int cantidadParaRecompensa = 100;
  private int ultimosPuntosMostrados = 0;
  private TextMeshProUGUI textoRecompensa;
  private void Start() {
    textoRecompensa = imagenRecompensa.GetComponentInChildren<TextMeshProUGUI>();
    controlVisibilidad(0);
  }
  private void Update() {
    if (imagenRecompensa.color.a == 1 && textoRecompensa.color.a == 1) {
      // Parar el juego hasta que le de a enter
      Time.timeScale = 0;
      if (Input.GetKey(KeyCode.Space)) {
        controlVisibilidad(0);
        Time.timeScale = 1; // Reanudar
      }
    } else {
      int puntos = GestorPuntuacion.getPuntuacion();
      if (
        (ultimosPuntosMostrados == 0 && puntos >= cantidadParaRecompensa) ||
        (puntos - ultimosPuntosMostrados >= cantidadParaRecompensa)
      ) {
        // Redoneo al múltiplo de la recompensa inferior
        puntos = (puntos / cantidadParaRecompensa) * cantidadParaRecompensa;
        ultimosPuntosMostrados = puntos;
        textoRecompensa.text = "Enhorabuena ha obtenido " + puntos + " pts !!!";
        controlVisibilidad(1);
      }
    }
  }
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
