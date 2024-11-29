/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 28/11/2024
 * @file ReproduccionSonidoConContacto.cs
 * @brief Esta clase gestiona la reproducción de un sonido en un objeto cuando se detecta una colisión 
 *        con otros objetos. Utiliza un sistema de notificación para activar la reproducción del sonido
 *        y asegura que el sonido no se reproduzca más de una vez simultáneamente.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase gestiona la reproducción de un sonido en un objeto cuando se detecta una colisión con otros objetos.
public class ReproduccionSonidoConContacto : MonoBehaviour {
  public NotificadorColisionCualquierObj[] notificadores;  // Array de objetos encargados de notificar las colisiones.
  public AudioSource srcAudio;  // Componente AudioSource que se utiliza para reproducir el sonido.
  public AudioClip clipSonido;  // El AudioClip que se reproducirá cuando ocurra una colisión.
  private bool sonidoReproduciendose = false; // Bandera para saber si el sonido ya está siendo reproducido.
  /**
   * Método que se llama al habilitar este componente.
   * Inicializa el AudioSource y configura los notificadores de colisión para que 
   * llamen al método ReproduceSonido cuando se detecte una colisión.
   */
  private void OnEnable() {
    srcAudio = GetComponent<AudioSource>();  // Obtiene el componente AudioSource del objeto.
    if (clipSonido != null) srcAudio.clip = clipSonido;  // Asigna el clip de sonido si no es nulo.
    if (notificadores != null) {
      foreach (var notificador in notificadores) {
        if (notificador != null) notificador.OnColision += ReproduceSonido;  // Se suscribe al evento de colisión de cada notificador.
      }
    }
  }
  /**
   * Método que reproduce el sonido cuando se detecta una colisión.
   * Se asegura de que el sonido no se reproduzca simultáneamente más de una vez.
   */
  private void ReproduceSonido() {
    if (srcAudio != null && srcAudio.clip != null && !sonidoReproduciendose) {
      sonidoReproduciendose = true;  // Marca el estado del sonido como "reproduciéndose".
      srcAudio.PlayOneShot(srcAudio.clip);  // Reproduce el sonido una sola vez.
      StartCoroutine(EsperarFinSonido());  // Inicia una coroutine para esperar el fin del sonido.
    }
  }
  /**
   * Coroutine que espera el tiempo de duración del sonido para poder permitir una nueva reproducción.
   * Se espera el tiempo necesario según la longitud del clip de audio.
   */
  private IEnumerator EsperarFinSonido() {
    yield return new WaitForSeconds(srcAudio.clip.length);  // Espera la duración del clip de audio.
    sonidoReproduciendose = false;  // Restablece la bandera indicando que el sonido ya terminó.
  }
  /**
   * Método que se llama al deshabilitar este componente.
   * Desactiva la suscripción a los eventos de colisión de los notificadores.
   */
  private void OnDisable() {
    if (notificadores != null) {
      foreach (var notificador in notificadores) {
        if (notificador != null) notificador.OnColision -= ReproduceSonido;  // Se desuscribe del evento de colisión.
      }
    }
  }
}
