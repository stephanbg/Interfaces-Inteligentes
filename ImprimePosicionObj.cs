/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 26 de Septiembre de 2024
 * @file ImprimePosicionObj.cs
 * @brief Este script imprime en la consola la posición de un GameObject 
 * asignado en el Inspector al iniciar la escena.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que imprime la posición de un objeto en la consola
public class ImprimePosicionObj : MonoBehaviour {
 // Variable pública para asignar un GameObject desde el Inspector
 public GameObject obj;
 // Método que se llama al iniciar el script
 void Start() {
   // Obtiene la posición del objeto asignado
   Vector3 posiciones = obj.transform.position;
   // Imprime en la consola la posición del objeto
   Debug.Log(
     "El objeto con nombre " + obj.name + " se encuentra en la posición (x: " +
     posiciones.x + ", y: " + posiciones.y + ", z: " + posiciones.z + ")"
   );
 }
}
