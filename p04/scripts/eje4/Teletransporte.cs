using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransporte : MonoBehaviour {
  public NotificadorCercaDelCubo notificador;
  public string nombreObjetivo = "Egg_Red (3)";
  public float ajuste = 0.35f;
  private GameObject obj;
  private Vector3 direccionDst, posOrigen;
  private Rigidbody rb;
  private void Start() {
    posOrigen = transform.position;
    obj = GameObject.Find(nombreObjetivo);
    rb = GetComponent<Rigidbody>();
    calcularVectorObj1Obj2();
    if (notificador != null) {
      notificador.OnZona += teletransporteADestino;
      notificador.OnFueraDeZona += teletransporteAOrigen;
    }
  }
  private void teletransporteADestino() {
    if (obj != null) {
      Vector3 nuevaPosicion = obj.transform.position - (direccionDst * ajuste);
      rb.MovePosition(nuevaPosicion);
    }
  }
  private void teletransporteAOrigen() {
    if (obj != null) rb.MovePosition(posOrigen);
  }  
  private void calcularVectorObj1Obj2() {
    direccionDst = obj.transform.position - posOrigen; // Destino - Origen
    direccionDst.y = 0; // Ignorar el movimiento vertical.
  }  
  private void OnDisable() {
    if (notificador != null) {
      notificador.OnZona -= teletransporteADestino;
      notificador.OnFueraDeZona -= teletransporteAOrigen;
    }
  }
}
