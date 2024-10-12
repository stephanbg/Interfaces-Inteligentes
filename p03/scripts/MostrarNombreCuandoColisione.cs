/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 10/10/2024
 * @file MostrarNombreCuandoColisione.cs
 * @brief Este script permite detectar la colisión entre dos objetos (Uno de ellos RigidBody perfecto). Eje9
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que muestra el nombre del objeto al colisionar con otro objeto.
public class MostrarNombreCuandoColisione : MonoBehaviour {
  /** Detecta la colisón entre dos objetos, uno de ellos debe ser RigidBody perfecto.
   * @parameter colision: Objeto que ha colisionado con este objeto.
   */
  private void OnCollisionEnter(Collision colision) {
    Debug.Log($"El objeto {gameObject.name} ha colisionado con {colision.gameObject.name}");
  }
}
