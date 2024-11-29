/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 28/11/2024
 * @file TV.cs
 * @brief Esta clase gestiona la captura de video desde la cámara web y la visualización en un objeto
 *        3D en Unity. Permite iniciar y detener la captura de video, y tomar capturas de pantalla
 *        de la imagen en tiempo real.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// Clase que gestiona la captura de video desde la cámara web y la visualización en un objeto 3D en Unity.
public class TV : MonoBehaviour {
  private Material tvMaterial; // Material del objeto para mostrar el video o la imagen
  private Renderer tvRenderer; // Componente Renderer para acceder al material
  private WebCamTexture webcamTextura; // Textura que se usa para mostrar el video de la cámara
  private string rutaDirImagenes; // Ruta donde se guardarán las capturas de pantalla
  private Texture2D texturaOriginal; // Textura original del material antes de asignar el video
  private int contadorCapturas = 1; // Contador para nombrar las capturas de pantalla
  /**
   * Método llamado al inicio del juego.
   * Inicializa el material, la textura de la cámara, la ruta para las capturas y la cámara web.
   */
  private void Start() {
    tvRenderer = GetComponent<Renderer>();
    tvMaterial = tvRenderer.material;
    rutaDirImagenes = Path.Combine(Application.dataPath, "Scripts/camara/Eje3/Capturas");
    // Si la carpeta de capturas no existe, la crea.
    if (!Directory.Exists(rutaDirImagenes)) Directory.CreateDirectory(rutaDirImagenes);
    texturaOriginal = tvMaterial.mainTexture as Texture2D;
    webcamTextura = new WebCamTexture();
    Debug.Log("Nombre de la cámara seleccionada: " + WebCamTexture.devices[0].name);
  }
  /**
   * Método llamado en cada frame.
   * Detecta la entrada del usuario para iniciar/detener la captura de video o tomar una foto.
   */
  private void Update() {
    if (Input.GetKeyDown(KeyCode.S)) IniciarCaptura(); // Inicia la captura de video cuando se presiona 'S'.
    if (Input.GetKeyDown(KeyCode.P)) DetenerCaptura(); // Detiene la captura de video cuando se presiona 'P'.
    if (Input.GetKeyDown(KeyCode.X)) TomarFotograma(); // Toma una foto cuando se presiona 'X'.
  }
  /**
   * Método que inicia la captura de video desde la cámara web.
   * Asigna el video a la textura del material y empieza la grabación.
   */
  private void IniciarCaptura() {
    if (webcamTextura == null || !webcamTextura.isPlaying) {
      tvMaterial.mainTexture = webcamTextura; // Asigna la textura de la cámara al material para mostrar el video.
      webcamTextura.Play(); // Inicia la cámara web para empezar a capturar video.
      Debug.Log("Captura de video iniciada.");
    }
  }
  /**
   * Método que detiene la captura de video.
   * Detiene la grabación y restaura la textura original del material.
   */
  private void DetenerCaptura() {
    if (webcamTextura != null && webcamTextura.isPlaying) {
      webcamTextura.Stop(); // Detiene la cámara web.
      tvMaterial.mainTexture = texturaOriginal; // Restaura la textura original del material.
      Debug.Log("Captura de video detenida.");
    }
  }
  /**
   * Método que toma un fotograma de la cámara web y lo guarda como una imagen.
   * La imagen se guarda como un archivo PNG en la carpeta de capturas.
   */
  private void TomarFotograma() {
    if (webcamTextura != null && webcamTextura.isPlaying) {
      // Crear una nueva textura con las dimensiones de la webcam.
      Texture2D capturaTextura = new Texture2D(webcamTextura.width, webcamTextura.height);
      capturaTextura.SetPixels(webcamTextura.GetPixels());  // Copia los píxeles de la webcam a la nueva textura.
      capturaTextura.Apply();  // Aplica los cambios a la textura.
      // Convierte la textura en un array de bytes para guardarlo como PNG.
      byte[] bytes = capturaTextura.EncodeToPNG();
      // Define la ruta de archivo y guarda la imagen.
      string rutaArchivo = Path.Combine(rutaDirImagenes, "Captura_" + contadorCapturas + ".png");
      File.WriteAllBytes(rutaArchivo, bytes); // Guarda la captura de pantalla como un archivo PNG.
      contadorCapturas++;
      Debug.Log("Foto tomada y guardada en: " + rutaArchivo);
    } else Debug.LogWarning("No hay video en curso para tomar una foto.");
  }
}
