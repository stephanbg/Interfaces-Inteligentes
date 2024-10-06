/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 2 de Octubre de 2024
 * @file DistanciaRespectoAEsfera.cs
 * @brief Este script calcula y muestra la distancia entre un objeto 
 *        (el que tiene este script) y una esfera con la etiqueta "Esfera_roja".
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Clase que calcula la distancia entre el objeto que contiene este script 
 *  y una esfera específica, mostrando la información en la consola.
 */
public class DistanciaRespectoAEsfera : MonoBehaviour {
 // Referencia a la esfera cuyo distancia se calculará.
 private GameObject laEsfera;
 // Almacena la distancia calculada.
 private double distancia;
 // Inicializa la referencia a la esfera y calcula la distancia respecto a ella.
 private void Start() {
   laEsfera = GameObject.FindWithTag("Esfera_roja");
   calcularDistanciaRespectoAEsfera();
   mostrarInfo();
 }
 // Calcula la distancia entre el objeto y la esfera.
 private void calcularDistanciaRespectoAEsfera() {
   distancia = Vector3.Distance(laEsfera.transform.position, transform.position);
 }
 // Muestra la distancia calculada en la consola.
 private void mostrarInfo() {
   Debug.Log($"La distancia entre la esfera y {gameObject.name} es: {distancia}");
 }
}
