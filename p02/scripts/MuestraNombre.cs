/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 2 de Octubre de 2024
 * @file MuestraNombre.cs
 * @brief Este script muestra el nombre del objeto en la consola al 
 *        iniciar la escena.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Clase que muestra el nombre del objeto al que está asociado 
 *  en la consola de depuración al inicio.
 */
public class MuestraNombre : MonoBehaviour {
 // Muestra el nombre del objeto en la consola al iniciar.
 private void Start() {
   Debug.Log($"El nombre del objeto es: {gameObject.name}"); 
 }
}
