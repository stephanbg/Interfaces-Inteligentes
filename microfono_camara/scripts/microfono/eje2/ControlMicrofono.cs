/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 28/11/2024
 * @file ControlMicrofono.cs
 * @brief Esta clase gestiona la grabación de audio desde un micrófono y la reproducción de lo grabado.
 *        Permite iniciar y detener la grabación con un botón y maneja la duración máxima de la grabación.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que graba desde el micrófono y permite empezar/detener la grabación
public class ControlMicrofono : MonoBehaviour {
  public string nombreMicro = "";  // Nombre del micrófono (si está vacío, se usa el predeterminado)
  public bool bucle = false;  // Si la grabación debe ser en bucle (no en este caso)
  public int duracionMax = 10;  // Duración máxima de la grabación en segundos
  public int frecuencia = 44100;  // Frecuencia de muestreo para la grabación
  private AudioSource srcAudio;  // Referencia al AudioSource donde reproducir el sonido
  private bool grabando;  // Estado de la grabación (si está grabando o no)
  private bool reproduciendo;  // Estado de la reproducción (si está reproduciendo o no)
  private float duracionGrabacion;  // Duración real de la grabación
  /**
   * Método llamado al inicio del juego.
   * Inicializa el componente AudioSource y establece los estados de grabación y reproducción.
   */
  private void Start() {
    srcAudio = GetComponent<AudioSource>();  // Obtiene el componente AudioSource para reproducir audio.
    grabando = false;  // Inicialmente no estamos grabando.
    reproduciendo = false;  // Inicialmente no estamos reproduciendo.
    duracionGrabacion = 0f;  // Inicializamos la duración de la grabación en cero.
  }
  /**
   * Método llamado en cada frame.
   * Verifica si el usuario presiona la tecla de grabación y gestiona el ciclo de grabación y reproducción.
   */
  private void Update() {
    // Verificamos si el AudioSource está disponible y si no estamos reproduciendo
    if (srcAudio != null && !reproduciendo) {
      if (Input.GetKeyDown(KeyCode.R)) {  // Si el usuario presiona la tecla 'R'
        if (grabando) {
          duracionGrabacion = (float)Microphone.GetPosition(nombreMicro) / frecuencia;  // Calculamos la duración real de la grabación
          Microphone.End(nombreMicro);  // Detenemos la grabación
          ReproducirSonido();  // Reproducimos lo que se ha grabado
        } else {
          srcAudio.clip = Microphone.Start(nombreMicro, bucle, duracionMax, frecuencia);  // Iniciamos la grabación desde el micrófono
          duracionGrabacion = 0f;  // Reiniciamos la duración de la grabación
        }
        grabando = !grabando;  // Cambiamos el estado de la grabación
      }
      // Verificamos si la duración máxima ha pasado y detener la grabación automáticamente
      if (grabando && Microphone.GetPosition(nombreMicro) >= srcAudio.clip.samples) {
        duracionGrabacion = (float)srcAudio.clip.samples / frecuencia;  // Calculamos la duración real de la grabación
        Microphone.End(nombreMicro);  // Detenemos la grabación cuando se alcance la duración máxima
        grabando = false;  // Cambiamos el estado de grabación a falso
        ReproducirSonido();  // Reproducimos lo grabado
      }
    }
  }
  /**
   * Método que reproduce el sonido grabado.
   * Reproduce lo que se ha grabado usando el AudioSource.
   */
  private void ReproducirSonido() {
    if (srcAudio != null && srcAudio.clip != null) {
      reproduciendo = true;  // Marcamos que estamos reproduciendo
      srcAudio.PlayOneShot(srcAudio.clip);  // Reproducimos el sonido grabado
      StartCoroutine(EsperarReproduccion());  // Iniciamos una coroutine para esperar que termine la reproducción
    }
  }
  /**
   * Coroutine que espera el tiempo de duración del audio grabado.
   * Después de la espera, marca el estado de reproducción como "finalizado".
   */
  private IEnumerator EsperarReproduccion() {
    yield return new WaitForSeconds(duracionGrabacion);  // Esperamos la duración real de la grabación
    reproduciendo = false;  // Marcamos que ha terminado la reproducción
  }
}
