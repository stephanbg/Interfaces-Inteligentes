/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 7/11/2024
 * @file PuntuaRecoleccion.cs
 * @brief Este script puntúa la recolección de objetos al detectar
 *        una colisión y actualiza la puntuación. Eje5
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que se encarga de acumular la puntuación.
public class PuntuaRecoleccion : MonoBehaviour {
  public NotificadorRecolectar notificador; // Referencia al notificador de colisiones.
  public int puntos; // Puntos a sumar al recolectar el objeto.
  // Método que se llama al inicio del juego.
  private void Start() {
    if (notificador != null) notificador.OnHover += puntuar;
  }
  // Método que se llama para sumar puntos al recolectar.
  private void puntuar(GameObject obj) {
    GestorPuntuacion.sumarPuntos(puntos);
    GestorPuntuacion.mostrarPuntos();
    if (obj != null) StartCoroutine(hacerInvisibleDespuesDeEspera(obj, 1f));
  }
  // Cuando se recolecta el objeto se hace invisible tras el tiempoDeEspera
  private IEnumerator hacerInvisibleDespuesDeEspera(GameObject obj, float tiempoDeEspera) {
    yield return new WaitForSeconds(tiempoDeEspera);
    obj.layer = LayerMask.NameToLayer("Default");
    Collider collider = obj.GetComponent<Collider>();
    if (collider != null) collider.enabled = false;
    Renderer renderer = obj.GetComponent<Renderer>();
    if (renderer != null) renderer.enabled = false;
  }
  // Asegúrate de desuscribirte del evento al desactivar el objeto.
  private void OnDisable() {
    if (notificador != null) notificador.OnHover -= puntuar;
  }  
}
