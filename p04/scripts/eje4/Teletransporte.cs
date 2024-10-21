/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 17/10/2024
 * @file Teletransporte.cs
 * @brief Este script permite teletransportar un objeto a una posición 
 *        destino al acercarse a otro objeto y volver a su posición 
 *        original al alejarse. Eje4
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que gestiona el teletransporte de un objeto basado en la proximidad a otro objeto.
public class Teletransporte : MonoBehaviour {
  public NotificadorCercaDelCubo notificador; // Notificador para la proximidad a un objeto.
  public string nombreObjetivo = "Egg_Red (3)"; // Nombre del objeto objetivo al que se teletransportará.
  public float ajuste = 0.35f; // Ajuste de distancia al teletransportar.
  private GameObject obj; // Referencia al objeto objetivo.
  private Vector3 direccionDst, posOrigen; // Direcciones y posición original del objeto.
  private Rigidbody rb; // Componente Rigidbody del objeto.
  // Se llama al inicio del script para inicializar la posición y buscar el objeto objetivo.
  private void Start() {
    posOrigen = transform.position; 
    obj = GameObject.Find(nombreObjetivo); 
    if (obj != null) {
      rb = GetComponent<Rigidbody>(); 
      calcularVectorObj1Obj2(); 
    }
    if (notificador != null) {
      notificador.OnZona += teletransporteADestino; 
      notificador.OnFueraDeZona += teletransporteAOrigen; 
    }
  }
  // Método que teletransporta el objeto a la posición destino.
  private void teletransporteADestino() {
    if (obj != null) {
      Vector3 nuevaPosicion = obj.transform.position - (direccionDst * ajuste); 
      rb.MovePosition(nuevaPosicion); 
    }
  }
  // Método que teletransporta el objeto a su posición original.
  private void teletransporteAOrigen() {
    if (obj != null) rb.MovePosition(posOrigen); 
  }
  // Calcula la dirección desde la posición original hacia el objeto objetivo, ignorando el eje Y.
  private void calcularVectorObj1Obj2() {
    direccionDst = obj.transform.position - posOrigen; 
    direccionDst.y = 0; 
  }
  // Asegúrate de desuscribirte de los eventos al desactivar el objeto.
  private void OnDisable() {
    if (notificador != null) {
      notificador.OnZona -= teletransporteADestino; 
      notificador.OnFueraDeZona -= teletransporteAOrigen; 
    }
  }
}
