/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 7/11/2024
 * @file MoverConJoystick.cs
 * @brief Este script permite mover la cámara con un joystick. Eje8
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para mover con el joystick la cámara
public class MoverConJoystick : MonoBehaviour {
  public float velocidad = 5f; // Velocidad de la cámara
  private Joystick joystick; // Joystick
  // Encuentra el tag del joystick
  private void Start() {
    joystick = GameObject.FindWithTag("Joystick").GetComponent<Joystick>();
  }
  // Mueve la cámara en cada frame
  private void Update() {
    float horizontal = joystick.Horizontal;
    float vertical = joystick.Vertical;
    Vector3 direccion = new Vector3(horizontal, 0, vertical);
    transform.Translate(direccion * velocidad * Time.deltaTime);
  }
}
