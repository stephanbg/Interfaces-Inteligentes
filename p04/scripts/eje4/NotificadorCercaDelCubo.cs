using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificadorCercaDelCubo : MonoBehaviour {
  public string nombreObjCercano = "Cube";
  public float distanciaCercana = 3f;
  public delegate void distanciaProxima();
  public delegate void distanciaLejana();
  public event distanciaProxima OnZona;
  public event distanciaLejana OnFueraDeZona;
  private GameObject objCercano;
  private bool enZona = false;
  private void Start() {
    objCercano = GameObject.Find(nombreObjCercano);
  }
  private void Update() {
    if (objCercano != null) {
      float distancia = Vector3.Distance(transform.position, objCercano.transform.position);
      if (distancia <= distanciaCercana) {
        if (!enZona) { 
          OnZona();
          enZona = true;
        }
      } else {
        if (enZona) {
          OnFueraDeZona();
          enZona = false;
        }
      }
    }
  }
}
