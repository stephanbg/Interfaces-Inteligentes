/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 10/10/2024
 * @file MoverHaciaUnaDireccion.cs
 * @brief Este script permite mover un objeto en una dirección específica 
 *        y a una velocidad configurada, utilizando un sistema de coordenadas 
 *        local o global según la opción seleccionada. Eje3
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que gestiona el movimiento de un objeto en una dirección específica.
public class MoverHaciaUnaDireccion : MonoBehaviour {
  // Dirección de movimiento del objeto.
  public Vector3 movimientoDireccion = new Vector3(1, 1, 1);
  // Velocidad de movimiento y factor de proporcionalidad.
  public float velocidad = 5f, proporcionalidad = 1f;
  // Opción para determinar el espacio de movimiento ("Self" o "World").
  public string espacioMovimiento = "Self";
  // Mueve el objeto en el espacio local o mundial dependiendo de lo especificado.
  private void Update() {
    if (espacioMovimiento == "Self") {
      transform.Translate(movimientoDireccion.normalized * proporcionalidad * velocidad * Time.deltaTime);
    } else if (espacioMovimiento == "World") {
      transform.Translate(movimientoDireccion.normalized * proporcionalidad * velocidad * Time.deltaTime, Space.World);
    }
  }
}
