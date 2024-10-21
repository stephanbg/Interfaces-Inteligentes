/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 17/10/2024
 * @file DesplazamientoPuerta.cs
 * @brief Este script controla el desplazamiento de una puerta en el juego,
 *        permitiendo abrir y cerrar la puerta al recibir un clic. Eje8
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que gestiona el desplazamiento de una puerta.
public class DesplazamientoPuerta : MonoBehaviour {
  public NotificadorOnClick notificador; // Notificador para detectar clics.
  public float velocidadDesplazamiento = 1f; // Velocidad de desplazamiento de la puerta.
  private Vector3 posOrigenPuerta; // Posición original de la puerta.
  private float anchoPuerta; // Ancho de la puerta.
  private bool puertaCerrada = true; // Estado de la puerta.
  // Método que se llama al iniciar el script.
  private void Start() {
    posOrigenPuerta = transform.position; 
    anchoPuerta = GetComponent<Renderer>().bounds.size.x; 
    if (notificador != null) notificador.OnClick += desplazarPuerta; 
  }
  // Desplaza la puerta al recibir un clic.
  private void desplazarPuerta() {
    if (puertaCerrada) abrir(); 
    else cerrar(); 
  }
  // Abre la puerta desplazándola.
  private void abrir() {
    transform.position += new Vector3(-anchoPuerta, 0, 0); 
    puertaCerrada = false; 
  }
  // Cierra la puerta volviendo a su posición original.
  private void cerrar() {
    transform.position = posOrigenPuerta; 
    puertaCerrada = true; 
  }
  // Desuscribirse del evento al desactivar el objeto.
  private void OnDisable() {
    if (notificador != null) notificador.OnClick -= desplazarPuerta;
  }  
}
