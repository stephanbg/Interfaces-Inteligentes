using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour {
  public NotificadorCercaDelCubo notificador;
  public string nombreObjetivo = "Quad";
  public float velocidadRotacion = 1f;
  private GameObject obj;
  private Vector3 direccion, direccionOrigen;
  private Rigidbody rb;
  private bool mirarAlObjetivo = false, primeraVez = true;
  private void Start() {
    obj = GameObject.Find(nombreObjetivo);
    rb = GetComponent<Rigidbody>();
    direccionOrigen = transform.forward;
    calcularVectorObj1Obj2();
    if (notificador != null) {
      notificador.OnZona += mirarAObjetivo;
      notificador.OnFueraDeZona += volverARotacionInicial;
    }
  }
  private void FixedUpdate() {
    if (mirarAlObjetivo) mirarAObjetivo();
    else if (!primeraVez) volverARotacionInicial();
  }
  private void mirarAObjetivo() {
    if (obj != null) {
      Quaternion direccionRotacion = Quaternion.LookRotation(direccion);
      Quaternion rotacionSuave = Quaternion.Slerp(rb.rotation, direccionRotacion, Time.deltaTime * velocidadRotacion);
      rb.MoveRotation(rotacionSuave);
      mirarAlObjetivo = true;
      primeraVez = false;
    }
  }
  private void volverARotacionInicial() {
    if (obj != null) {
      Quaternion direccionRotacion = Quaternion.LookRotation(direccionOrigen);
      Quaternion rotacionSuave = Quaternion.Slerp(rb.rotation, direccionRotacion, Time.deltaTime * velocidadRotacion);
      rb.MoveRotation(rotacionSuave);
      mirarAlObjetivo = false;
    }
  }
  private void calcularVectorObj1Obj2() {
    if (obj != null) {
      direccion = obj.transform.position - transform.position; // Destino - Origen
      direccion.y = 0; // Ignorar el movimiento vertical.
    }
  }
  private void OnDisable() {
    if (notificador != null) {
      notificador.OnZona -= mirarAObjetivo;
      notificador.OnFueraDeZona -= volverARotacionInicial;
    }
  }  
}
