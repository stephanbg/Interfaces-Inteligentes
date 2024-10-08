/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 8 de Octubre de 2024
 * @file IntercambioPosiciónYCambiaColor.cs
 * @brief Este script permite intercambiar el clindro con la esfera más cercana respecto al cubo y cambia su color
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Intercambia el clindro con la esfera más cercana respecto al cubo y cambia su color.
 */
public class IntercambioPosiciónYCambiaColor : MonoBehaviour {
 
 private GameObject cilindro, esferaMasCercana;
 
 // Inicio para intercambio y cambio de color
 private void Start() {
   GameObject cubo = GameObject.FindWithTag("Cubo");
   GameObject[] esferas = GameObject.FindGameObjectsWithTag("Esfera_tipo_2");
   calcularEsferaMasCercana(cubo, esferas);
   cilindro = GameObject.Find("Cylinder");
   intercambio();
   cambioColorEsfera();
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

 // Intercambio entre esfera y cilindro
 private void intercambio() {
   Vector3 posAux = esferaMasCercana.transform.position;
   esferaMasCercana.transform.position = cilindro.transform.position;
   cilindro.transform.position = posAux;
 }

 // Cambia color de esfera
 private void cambioColorEsfera() {
   esferaMasCercana.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
 }
}
