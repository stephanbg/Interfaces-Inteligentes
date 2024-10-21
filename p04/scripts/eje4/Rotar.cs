/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 17/10/2024
 * @file Rotar.cs
 * @brief Este script permite que un objeto gire hacia otro objeto 
 *        especificado cuando lo mencione el notificador, y vuelva a su rotación 
 *        original. Eje4
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que gestiona la rotación de un objeto hacia otro.
public class Rotar : MonoBehaviour {
  public NotificadorCercaDelCubo notificador; // Referencia al notificador de proximidad.
  public string nombreObjetivo = "Quad"; // Nombre del objeto hacia el cual girar.
  public float velocidadRotacion = 1f; // Velocidad de rotación del objeto.
  private GameObject obj; // Referencia al objeto objetivo.
  private Vector3 direccion, direccionOrigen; // Direcciones hacia el objeto y dirección original.
  private Rigidbody rb; // Referencia al componente Rigidbody.
  private bool mirarAlObjetivo = false, primeraVez = true; // Controla el estado de rotación.
  // Se llama al inicio del script para encontrar el objeto objetivo y establecer la dirección inicial.
  private void Start() {
    obj = GameObject.Find(nombreObjetivo);
    direccionOrigen = transform.forward;
    if (obj != null) {
      rb = GetComponent<Rigidbody>();
      calcularVectorObj1Obj2();
    }
    if (notificador != null) {
      notificador.OnZona += mirarAObjetivo;
      notificador.OnFueraDeZona += volverARotacionInicial;
    }
  }
  // Se llama en cada frame fijo para gestionar la rotación del objeto.
  private void FixedUpdate() {
    if (mirarAlObjetivo) mirarAObjetivo();
    else if (!primeraVez) volverARotacionInicial();
  }
  // Método que hace que el objeto gire hacia el objeto objetivo.
  private void mirarAObjetivo() {
    if (obj != null) {
      Quaternion direccionRotacion = Quaternion.LookRotation(direccion);
      Quaternion rotacionSuave = Quaternion.Slerp(rb.rotation, direccionRotacion, Time.fixedDeltaTime * velocidadRotacion);
      rb.MoveRotation(rotacionSuave);
      mirarAlObjetivo = true;
      primeraVez = false;
    }
  }
  // Método que hace que el objeto vuelva a su rotación original.
  private void volverARotacionInicial() {
    if (obj != null) {
      Quaternion direccionRotacion = Quaternion.LookRotation(direccionOrigen);
      Quaternion rotacionSuave = Quaternion.Slerp(rb.rotation, direccionRotacion, Time.fixedDeltaTime * velocidadRotacion);
      rb.MoveRotation(rotacionSuave);
      mirarAlObjetivo = false;
    }
  }
  // Calcula la dirección desde el objeto actual hacia el objeto objetivo, ignorando el eje Y.
  private void calcularVectorObj1Obj2() {
    direccion = obj.transform.position - transform.position; // Calcula el vector dirección (Destino - Origen).
    direccion.y = 0;
  }
  // Asegúrate de desuscribirte de los eventos al desactivar el objeto.
  private void OnDisable() {
    if (notificador != null) {
      notificador.OnZona -= mirarAObjetivo;
      notificador.OnFueraDeZona -= volverARotacionInicial;
    }
  }  
}
