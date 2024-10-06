/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 2 de Octubre de 2024
 * @file MoverObjeto.cs
 * @brief Este script permite mover un objeto a una posición aleatoria 
 *        en base a un conjunto de desplazamientos predefinidos cada vez 
 *        que se presiona la tecla de espacio.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Clase que gestiona el movimiento de un objeto desplazándolo de manera aleatoria.
 *  Dichos desplazamientos están definidos en una matriz.
 */
public class MoverObjeto : MonoBehaviour {
 // Array de posiciones de desplazamiento predefinidas.
 public Vector3[] posicionesDesplazamiento = new Vector3[3];
 // Inicializa las posiciones de desplazamiento al inicio.
 private void Start() {
   posicionesDesplazamiento[0] = new Vector3(0.5f, 0.0f, 0.5f);
   posicionesDesplazamiento[1] = new Vector3(-0.5f, 0.5f, -0.5f);
   posicionesDesplazamiento[2] = new Vector3(0.5f, -0.5f, 0.0f);
 }
 // Actualiza el estado del objeto en cada frame, cada vez que se le da al espacio se mueve el objeto.
 private void Update() {
   if (Input.GetKeyDown(KeyCode.Space)) MoverAposicionAleatoria();
 }
 // Mueve el objeto a una posición aleatoria basada en la matriz de desplazamientos.
 private void MoverAposicionAleatoria() {
   int indiceAleatorio = Random.Range(0, posicionesDesplazamiento.Length);
   Vector3 nuevaPosicion = transform.position + posicionesDesplazamiento[indiceAleatorio];
   transform.position = nuevaPosicion;
 }
}
