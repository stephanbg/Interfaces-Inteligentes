/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 7/11/2024
 * @file MoverConAnimacion.cs
 * @brief Este script controla el movimiento de un objeto con animaciones.
 *        El objeto se moverá hacia la cámara cuando el puntaje del jugador sea
 *        suficiente, y cambiará de animación dependiendo de la distancia a la cámara (corre o ataca).
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que se encarga de mover el objeto con animaciones basadas en la puntuación y la distancia a la cámara.
public class MoverConAnimacion : MonoBehaviour {
  public int puntosParaIniciarDesplazamiento; // Número de puntos necesarios para activar el desplazamiento del objeto.
  public float velocidadMovimiento = 5f; // Velocidad a la que el objeto se mueve.
  public float velocidadRotacion = 10f; // Velocidad a la que el objeto rota hacia su destino.
  public float distanciaDeteccion = 5f; // Distancia máxima para activar la animación de ataque.
  private Vector3 direccion; // Dirección en la que el objeto se moverá hacia la cámara.
  private Animator animator; // Componente Animator para gestionar las animaciones del objeto.

  // Método llamado al inicio para obtener el componente Animator del objeto hijo.
  private void Start() {
    animator = GetComponentInChildren<Animator>();
  }
  
  // Método llamado en cada frame para controlar el movimiento y animación del objeto.
  private void Update() {
    // Verifica si la puntuación es suficiente para iniciar el movimiento.
    if (GestorPuntuacion.getPuntuacion() >= puntosParaIniciarDesplazamiento) {
      calcularVectorDireccion(); // Calcula la dirección hacia la cámara.
      float distancia = Vector3.Distance(transform.position, Camera.main.transform.position);
      if (distancia <= distanciaDeteccion) {
        animator.SetBool("IsRunning", false);
        animator.SetBool("IsAttacking", true);
      } else {
        animator.SetBool("IsRunning", true);
        animator.SetBool("IsAttacking", false);
        moverObjeto();   // Mueve el objeto hacia la cámara.
      }
      rotarHaciaDestino(); // Rota el objeto para que mire hacia la cámara.
    } else {
      animator.SetBool("IsRunning", false);
      animator.SetBool("IsAttacking", false);
    }
  }

  // Método para calcular la dirección en la que el objeto debe moverse, tomando la posición de la cámara.
  private void calcularVectorDireccion() {
    direccion = Camera.main.transform.position - transform.position;
    direccion.y = 0;
  }

  // Método para mover el objeto hacia la cámara.
  private void moverObjeto() {
    transform.Translate(direccion.normalized * velocidadMovimiento * Time.deltaTime, Space.World);
  }

  // Método para rotar el objeto hacia la dirección calculada.
  private void rotarHaciaDestino() {
    Quaternion objetivoRotacion = Quaternion.LookRotation(-direccion);
    transform.rotation = Quaternion.Slerp(transform.rotation, objetivoRotacion, velocidadRotacion * Time.deltaTime);
  }
}
