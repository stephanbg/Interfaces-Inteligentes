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
 // Variable para almacenar la posición anterior
 private Vector3 posicionAnterior;
 // Método que se llama al iniciar el script
 void Start() {
   // Inicializa la posición anterior
   posicionAnterior = obj.transform.position; 
   // Imprime la posición inicial
   ImprimirPosicion();
 }
 // Método que se llama en cada frame
 void Update() {
   // Compara la posición actual con la posición anterior
   Vector3 posicionActual = obj.transform.position;
   // Si la posición ha cambiado, el objeto está en movimiento
   if (posicionActual != posicionAnterior) ImprimirPosicion();
   // Actualiza la posición anterior para el siguiente frame
   posicionAnterior = posicionActual;
 }
 // Método para imprimir la posición del objeto
 void ImprimirPosicion() {
   Vector3 posiciones = obj.transform.position;
   Debug.Log(
     "El objeto con nombre " + obj.name + " se encuentra en la posición (x: " +
     posiciones.x + ", y: " + posiciones.y + ", z: " + posiciones.z + ")"
   );
 }
}
