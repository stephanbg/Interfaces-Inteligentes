/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 2 de Octubre de 2024
 * @file CambiarColorConFlechaArriba.cs
 * @brief Este script permite cambiar el color del objeto al que está asociado 
 *        cada vez que se presiona la tecla de flecha arriba. El nuevo color 
 *        se selecciona aleatoriamente utilizando valores RGB generados en 
 *        tiempo de ejecución.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Clase que permite cambiar el color del material de un objeto al presionar 
 *  la tecla de flecha arriba. Utiliza valores aleatorios para generar el nuevo 
 *  color.
 */
public class CambiarColorConFlechaArriba : MonoBehaviour {
 // Referencia al material del objeto, que se utilizará para cambiar su color.
 private Material m_Material;
 // Inicializa la referencia al material del objeto en el inicio.
 private void Start() {
   m_Material = GetComponent<Renderer>().material;
 }
 // Actualiza el color del material al azar si se presiona la tecla de flecha arriba.
 private void Update() {
   if (Input.GetKeyDown(KeyCode.UpArrow)) {  
     m_Material.color = new Color(Random.value, Random.value, Random.value);
   }
 }
}
