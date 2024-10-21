/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 17/10/2024
 * @file MovimientoCamara.cs
 * @brief Este script permite controlar el movimiento y la rotación de una cámara
 *        en un entorno 3D, gestionando la entrada del usuario para moverla y
 *        rotarla con restricciones en el movimiento vertical. Eje8
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que gestiona el movimiento y la rotación de la cámara.
public class MovimientoCamara : MonoBehaviour {
  public float velocidadMovimiento = 10f; // Velocidad de movimiento de la cámara
  public float velocidadRotacion = 7f; // Velocidad de rotación de la cámara
  public float limiteRotacionVertical = 35f; // Ángulo máximo de rotación vertical
  private float distanciaRaycast = 0.5f; // Distancia para el raycast
  private float rotacionX = 0f, rotacionY = 0f; // Rotación en el eje X y eje Y
  // Método que se llama en cada frame, para mover y rotar la cámara.
  private void Update() {
    moverCamara();
    rotarCamara();
  }
  // Mueve la cámara según la entrada del usuario.
  private void moverCamara() {
    float movimientoHorizontal = Input.GetAxis("Horizontal");
    float movimientoVertical = Input.GetAxis("Vertical");
    Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical);
    // Transformar el movimiento según la orientación de la cámara
    movimiento = transform.TransformDirection(movimiento) * velocidadMovimiento * Time.deltaTime;
    // Comprobar colisión con raycast
    RaycastHit hit;
    if (!Physics.Raycast(transform.position, movimiento.normalized, out hit, distanciaRaycast)) {
      transform.position += movimiento; // Mover la cámara si no hay colisión
    }
  }
  // Rota la cámara según el movimiento del ratón.
  private void rotarCamara() {
    float ratonX = Input.GetAxis("Mouse X") * velocidadRotacion;
    float ratonY = Input.GetAxis("Mouse Y") * velocidadRotacion;
    // Aplicar rotación suave en ambos ejes
    rotacionX -= ratonY;
    rotacionX = Mathf.Clamp(rotacionX, -limiteRotacionVertical, limiteRotacionVertical);
    rotacionY = transform.eulerAngles.y + ratonX;
    // Crear la rotación deseada con suavidad
    Quaternion rotacionDeseada = Quaternion.Euler(rotacionX, rotacionY, 0);
    transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, Time.deltaTime * velocidadRotacion);
  }
}
