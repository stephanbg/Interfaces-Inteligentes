/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 2 de Octubre de 2024
 * @file RandomColorPorFrame.cs
 * @brief Este script cambia aleatoriamente uno de los componentes de color 
 *        del material del objeto cada cierto número de frames, 
 *        definido por el usuario.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Clase que gestiona el cambio aleatorio de color de un objeto cada 
 *  un número específico de frames.
 */
public class RandomColorPorFrame : MonoBehaviour {
 // Almacena un color aleatorio.
 private Color randomColor;
 // Contador de frames transcurridos.
 private int contadorFrames = 0;
 // Número de frames a esperar antes de cambiar el color.
 public int framesEspera = 120;
 // Inicializa un color aleatorio al inicio.
 private void Start() {
   randomColor = new Color(Random.value, Random.value, Random.value);
   GetComponent<Renderer>().material.color = randomColor;
 }
 // Actualiza el color del objeto cada vez que se alcanza los frames predefinidos.
 private void Update() {
   if (contadorFrames == framesEspera) {
     int indiceRand = Random.Range(0, 3);
     randomColor[indiceRand] = Random.value;
     GetComponent<Renderer>().material.color = randomColor;
     contadorFrames = 0;
   } else contadorFrames++;
 }
}
