/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 10/10/2024
 * @file RotarLookAt.cs
 * @brief Este script permite rotar un objeto hacia otro. Eje7
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que permite rotar un objeto para mirar hacia otro objeto especificado.
public class RotarLookAt : MonoBehaviour {
  // Nombre del objeto objetivo al que se rotará el objeto actual.
  public string nombreObj2 = "Sphere";
  // Referencia al objeto objetivo encontrado en la escena.
  private GameObject obj2;
  // Almacena el nombre del objeto objetivo anterior para comparaciones.
  private string nombreObj2Anterior;
  // Método que se llama al iniciar el script, inicializa el objeto objetivo.
  private void Start() {
    obj2 = GameObject.Find(nombreObj2);
    nombreObj2Anterior = nombreObj2;
  }
  // Actualiza la rotación del objeto actual para mirar hacia el objetivo en cada frame.
  private void Update() {
    if (obj2 != null) transform.LookAt(obj2.transform);
  }
  // Verifica si el nombre del objeto objetivo ha cambiado en el inspector.
  private void OnValidate() {
    if (nombreObj2 != nombreObj2Anterior) {
      obj2 = GameObject.Find(nombreObj2);
      nombreObj2Anterior = nombreObj2;
    }
  }  
}
