/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 7/11/2024
 * @file NotificadorRecolectar.cs
 * @brief Clase que notifica eventos de recolectar objetos en Unity. Eje8
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Clase que se utiliza para mandar una notificación si la cámara apunta a un objeto del
 * tipo "Recolectar" a una cierta distancia.
 */
public class NotificadorRecolectar : MonoBehaviour {
  public delegate void hover(GameObject obj);  // Delegado para el evento OnHover.
  public event hover OnHover;  // Evento que se activa cuando la retícula está sobre el objeto.
  public string tipo = "Recolectar";  // Nombre del layer con el que se interactúa.
  public float distanciaMaxima = 10f;  // Distancia máxima del raycast.
  private GameObject objActual;  // Objeto actual sobre el que se encuentra la retícula.
  private void Update() {
    // Lanza un rayo desde la posición de la cámara en la dirección hacia donde está mirando la cámara.
    Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
    RaycastHit hit;
    // Verificamos si el raycast colisiona con algún objeto del tipo "Recolectar".
    if (Physics.Raycast(ray, out hit, distanciaMaxima)) {
      if (hit.collider != null && hit.collider.gameObject.CompareTag(tipo)) {
        // Si el objeto es del tipo "Recolectar" y es diferente al objeto actual, disparamos el evento.
        if (objActual != hit.collider.gameObject) {
          // Actualizamos el objeto actual y disparamos el evento OnHover.
          objActual = hit.collider.gameObject;
          OnHover?.Invoke(objActual);
        }
      }
    }
  }
}
