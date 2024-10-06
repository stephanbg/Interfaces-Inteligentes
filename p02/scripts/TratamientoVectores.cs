/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 2 de Octubre de 2024
 * @file TratamientoVectores.cs
 * @brief Este script realiza diversas operaciones matemáticas sobre 
 *        dos vectores, incluyendo el cálculo de sus magnitudes, ángulo, 
 *        distancia y la comparación de sus alturas. Los resultados se 
 *        muestran en la consola.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Clase que gestiona el tratamiento y análisis de dos vectores, 
 *  actualizando los cálculos cuando se detectan cambios en sus valores.
 */
public class TratamientoVectores : MonoBehaviour {
 // Vectores a analizar.
 public Vector3 vector1, vector2;
 // Variables para almacenar resultados de cálculos.
 public double magnitud1, magnitud2, angulo, distancia;
 public string alturaMayor;
 // Indica si los valores han cambiado.
 private bool valoresCambiados = false;
 // Almacena los vectores anteriores para comparación.
 private Vector3 vector1Anterior, vector2Anterior;
 // Inicializa los vectores anteriores al inicio.
 private void Start() {
   vector1Anterior = vector1;
   vector2Anterior = vector2;
 }
 // Actualiza el estado en cada frame.
 private void Update() {
   // Verifica si los vectores han cambiado
   if (vector1 != vector1Anterior || vector2 != vector2Anterior) {
     valoresCambiados = true; // Marca que los valores han cambiado
     vector1Anterior = vector1; // Actualiza el vector anterior
     vector2Anterior = vector2; // Actualiza el vector anterior
   }
   if (valoresCambiados) {
     calcularMagnitudes();
     calcularAngulo();
     calcularDistancia();
     calcularAlturaMayor();
     mostrarInfo();
     valoresCambiados = false; // Resetea el estado
   }
 }
 // Calcula las magnitudes de los vectores.
 private void calcularMagnitudes() {
   magnitud1 = vector1.magnitude;
   magnitud2 = vector2.magnitude;
 }
 // Calcula el ángulo entre los vectores.
 private void calcularAngulo() {
   angulo = Vector3.Angle(vector1, vector2);
 }
 // Calcula la distancia entre los vectores.
 private void calcularDistancia() {
   distancia = Vector3.Distance(vector1, vector2);
 }
 // Determina cuál vector tiene mayor altura (componente Y).
 private void calcularAlturaMayor() {
   if (vector1.y > vector2.y) alturaMayor = "Vector1";
   else if (vector1.y < vector2.y) alturaMayor = "Vector2";
   else alturaMayor = "Iguales";
 }
 // Muestra la información calculada en la consola.
 private void mostrarInfo() {
   Debug.Log($"Magnitud de vector1: {vector1.magnitude}");
   Debug.Log($"Magnitud de vector2: {vector2.magnitude}");
   Debug.Log($"Ángulo entre vector1 y vector2: {angulo}");
   Debug.Log($"Distancia entre vector1 y vector2: {distancia}");
   Debug.Log($"¿Qué vector esta más alto?: {alturaMayor}");
 }
}
