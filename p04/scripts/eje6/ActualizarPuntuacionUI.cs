using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActualizarPuntuacionUI : MonoBehaviour {
  public TextMeshProUGUI textoPuntuacion;
  private void Start() {
    textoPuntuacion.text = "Puntuación actual: 0";
  }
  private void Update() {
    textoPuntuacion.text = "Puntuación actual: " + GestorPuntuacion.getPuntuacion();
  }
}
