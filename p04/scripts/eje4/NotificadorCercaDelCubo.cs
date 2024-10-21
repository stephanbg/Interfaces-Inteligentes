/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 17/10/2024
 * @file NotificadorCercaDelCubo.cs
 * @brief Este script notifica cuando un objeto está cerca de otro objeto
 *        especificado, activando eventos en función de la distancia. Eje4
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que verifica la proximidad a un objeto específico y notifica eventos.
public class NotificadorCercaDelCubo : MonoBehaviour {
  public string nombreObjCercano = "Cube"; // Nombre del objeto que se verifica.
  public float distanciaCercana = 3f; // Distancia dentro de la cual se considera que el objeto está "cerca".
  public delegate void distancia(); // Delegado para el evento cuando se acerca o aleja.
  public event distancia OnZona; // Evento que se activa al entrar en la zona cercana.
  public event distancia OnFueraDeZona; // Evento que se activa al salir de la zona cercana.
  private GameObject objCercano; // Referencia al objeto que se está verificando.
  private bool enZona = false; // Estado que indica si se está dentro de la zona cercana.
  // Se llama al inicio del script para encontrar el objeto cercano especificado.
  private void Start() {
    objCercano = GameObject.Find(nombreObjCercano);
  }
  // Se llama una vez por frame para verificar la distancia al objeto cercano.
  private void Update() {
    if (objCercano != null) {
      float distancia = Vector3.Distance(transform.position, objCercano.transform.position);
      if (distancia <= distanciaCercana) {
        if (!enZona) { 
          OnZona(); // Activa el evento si no estaba ya en la zona.
          enZona = true; // Actualiza el estado a "dentro de la zona".
        }
      } else {
        if (enZona) {
          OnFueraDeZona(); // Activa el evento si se sale de la zona.
          enZona = false; // Actualiza el estado a "fuera de la zona".
        }
      }
    }
  }
}
