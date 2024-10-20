using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntuaRecoleccion : MonoBehaviour {
  public NotificadorColisionConTipo notificador;
  public int puntos;
  private void Start() {
    if (notificador != null) notificador.OnColision += puntuar;
  }
  private void puntuar() {
    GestorPuntuacion.sumarPuntos(puntos);
    GestorPuntuacion.mostrarPuntos();
  }
  private void OnDisable() {
    if (notificador != null) notificador.OnColision -= puntuar;
  }  
}
