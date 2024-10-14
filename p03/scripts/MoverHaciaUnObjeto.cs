/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 10/10/2024
 * @file MoverHaciaUnObjeto.cs
 * @brief Este script permite mover un objeto de manera automática hacia otro objeto. Eje6
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que permite mover un objeto hacia otro objeto especificado en la escena.
public class MoverHaciaUnObjeto : MonoBehaviour {
  // Velocidad de movimiento del objeto.
  public float velocidad = 1f;
  // Nombre del objeto objetivo al que se moverá.
  public string nombreObj2 = "Sphere";
  // Vector que representa la dirección hacia el objeto objetivo.
  private Vector3 direccion;
  // Referencia al objeto objetivo encontrado en la escena.
  private GameObject obj2;
  // Almacena el nombre del objeto objetivo anterior para comparaciones.
  private string nombreObj2Anterior;
  // Método que se llama al iniciar el script, inicializa el objeto objetivo.
  private void Start() {
    obj2 = GameObject.Find(nombreObj2);
    nombreObj2Anterior = nombreObj2;
  }
  // Actualiza la posición del objeto hacia el objetivo en cada frame.
  private void Update() {
    if (obj2 != null) {
      calcularVectorObj1Obj2();
      transform.Translate(direccion.normalized * velocidad * Time.deltaTime, Space.World);
    }
  }
  // Verifica si el nombre del objeto objetivo ha cambiado en el inspector.
  private void OnValidate() {
    if (nombreObj2 != nombreObj2Anterior) {
      obj2 = GameObject.Find(nombreObj2);
      nombreObj2Anterior = nombreObj2;
    }
  }
  // Calcula la dirección desde el objeto actual hacia el objeto objetivo.
  private void calcularVectorObj1Obj2() {
    direccion = obj2.transform.position - transform.position; // Destino - Origen
    direccion.y = 0;
  }
}
