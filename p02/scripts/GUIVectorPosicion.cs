/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 2 de Octubre de 2024
 * @file GUIVectorPosicion.cs
 * @brief Este script muestra la posición del objeto en el mundo en la 
 *        interfaz gráfica de usuario (GUI). La posición se convierte de 
 *        coordenadas del mundo a coordenadas de pantalla para ser visualizada.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que gestiona la visualización de la posición del objeto en la GUI.
public class GUIVectorPosicion : MonoBehaviour {
 // Dibuja la posición del objeto en la interfaz gráfica.
 private void OnGUI() {
   // Obtener la posición del objeto en el mundo
   Vector3 posicionMundo = transform.position;
   // Convertir la posición del objeto de mundo a pantalla
   Vector3 posicionPantalla = Camera.main.WorldToScreenPoint(posicionMundo);
   const int anchoTexto = 200, altoTexto = 20;
   GUI.color = Color.black;
   // Mostrar solo la posición en la GUI
   GUI.Label(new Rect(posicionPantalla.x, Screen.height - posicionPantalla.y, anchoTexto, altoTexto), 
             "Posición: " + posicionMundo);
   GUI.color = Color.white;
 }
}
