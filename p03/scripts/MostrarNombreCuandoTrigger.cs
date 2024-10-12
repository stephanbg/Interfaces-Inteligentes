/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 10/10/2024
 * @file MostrarNombreCuandoTrigger.cs
 * @brief Este script permite detectar el lanzamiento de un trigger cuando
 *        un objeto entra en contacto con otro (Uno de ellos RigidBody perfecto marcado como IsTrigger). Eje11
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que muestra el nombre del objeto al entrar en un trigger.
public class MostrarNombreCuandoTrigger : MonoBehaviour {
  /** Detecta la colisón entre dos objetos, uno de ellos debe ser RigidBody perfecto marcado como IsTrigger.
   * @parameter disparador: Objeto que ha activado el evento de trigger.
   */
  private void OnTriggerEnter(Collider disparador) {
    Debug.Log(
      $"El objeto {gameObject.name} ha entrado en el evento disparado por {disparador.gameObject.name}"
    );
  }
}
