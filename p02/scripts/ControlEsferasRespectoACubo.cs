/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 2 de Octubre de 2024
 * @file ControlEsferasRespectoACubo.cs
 * @brief Este script gestiona la interacción entre un cubo y varias esferas. 
 *        Determina cuál es la esfera más lejana y la más cercana al cubo, 
 *        y permite aumentar la altura de la esfera más cercana después de 
 *        un tiempo de espera. También cambia el color de la esfera más lejana 
 *        al presionar la barra espaciadora.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Clase que controla la relación entre un cubo y esferas, permitiendo 
 *  modificar sus propiedades basándose en la distancia al cubo.
 */
public class ControlEsferasRespectoACubo : MonoBehaviour {
 // Referencias a la esfera más lejana y la más cercana al cubo.
 private GameObject esferaMasLejana, esferaMasCercana;
 // Inicializa las esferas y calcula las más lejana y cercana.
 private void Start() {
   GameObject cubo = GameObject.FindWithTag("Cubo");
   GameObject[] esferas = GameObject.FindGameObjectsWithTag("Esfera_tipo_2");
   calcularEsferaMasLejana(cubo, esferas);
   calcularEsferaMasCercana(cubo, esferas);
   StartCoroutine(aumentarAlturaEsferaMasCercanaConEspera(2.0f)); // Espera 2 segundos crea corrutina
 }
 // Escucha la entrada del teclado para cambiar el color de la esfera más lejana.
 private void Update() {
  if (Input.GetKeyDown(KeyCode.Space)) cambiarColorTrasPulsarEspacioDeEsferaMasLejana();
 }
 // Aumenta la altura de la esfera más cercana después de un tiempo de espera.
 private IEnumerator aumentarAlturaEsferaMasCercanaConEspera(float espera) {
   yield return new WaitForSeconds(espera); // Espera el tiempo especificado
   Vector3 nuevaPosicion = esferaMasCercana.transform.position;
   nuevaPosicion.y += Random.value;
   esferaMasCercana.transform.position = nuevaPosicion;
 }
 // Cambia el color de la esfera más lejana al presionar la barra espaciadora.
 private void cambiarColorTrasPulsarEspacioDeEsferaMasLejana() {
   esferaMasLejana.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
 } 
 // Calcula la esfera más lejana al cubo.
 private void calcularEsferaMasLejana(GameObject cubo, GameObject[] esferas) {
   esferaMasLejana = esferas[0];
   double distanciaMax = Vector3.Distance(cubo.transform.position, esferas[0].transform.position);
   double cadaDistancia;
   for (int i = 1; i < esferas.Length; ++i) {
     cadaDistancia = Vector3.Distance(cubo.transform.position, esferas[i].transform.position);
     if (distanciaMax < cadaDistancia) {
       esferaMasLejana = esferas[i];
       distanciaMax = cadaDistancia;
     }
   }
 }
 // Calcula la esfera más cercana al cubo.
 private void calcularEsferaMasCercana(GameObject cubo, GameObject[] esferas) {
   esferaMasCercana = esferas[0];
   double distanciaMin = Vector3.Distance(cubo.transform.position, esferas[0].transform.position);
   double cadaDistancia;
   for (int i = 1; i < esferas.Length; ++i) {
     cadaDistancia = Vector3.Distance(cubo.transform.position, esferas[i].transform.position);
     if (distanciaMin > cadaDistancia) {
       esferaMasCercana = esferas[i];
       distanciaMin = cadaDistancia;
     }
   } 
 } 
}
