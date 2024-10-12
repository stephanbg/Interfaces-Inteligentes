/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 10/10/2024
 * @file MoverRigidBodyHaciaUnObjeto.cs
 * @brief Este script permite que un objeto con Rigidbody se desplace y rote 
 *        hacia un objetivo especificado, deteniéndose al colisionar con él. 
 *        Utiliza velocidad de desplazamiento y rotación configurables desde 
 *        el inspector, y permite cambiar el objetivo en tiempo de ejecución. Eje12
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que gestiona el movimiento y rotación de un objeto hacia otro objetivo.
public class MoverRigidBodyHaciaUnObjeto : MonoBehaviour {
  // Velocidad a la que el objeto se desplaza hacia el objetivo.
  public float velocidadDesplazamiento = 5f;
  // Velocidad a la que el objeto rota hacia el objetivo.
  public float velocidadRotacion = 5f;
  // Nombre del objeto objetivo.
  public string nombreObj2 = "Sphere";
  // Vector que indica la dirección hacia el objetivo.
  private Vector3 direccion;
  // Referencia al objeto objetivo.
  private GameObject obj2;
  // Almacena el nombre del objeto objetivo anterior para detección de cambios.
  private string nombreObj2Anterior;
  // Referencia al componente Rigidbody del objeto.
  private Rigidbody rigidBody;
  // Indica si el objeto ha llegado al destino.
  private bool llegueAdestino = false;
  // Inicializa referencias al objeto objetivo y al Rigidbody.
  private void Start() {
    obj2 = GameObject.Find(nombreObj2);
    nombreObj2Anterior = nombreObj2;
    rigidBody = GetComponent<Rigidbody>();
  }
  // Actualiza la posición y rotación del objeto en cada frame.
  private void Update() {
    if (obj2 != null && !llegueAdestino) {
      calcularVectorObj1Obj2();
      // Calcula la nueva posición del objeto
      Vector3 nuevaPosicion = transform.position + (direccion.normalized * velocidadDesplazamiento * Time.deltaTime);
      // Calcula la nueva rotación utilizando Slerp para suavizar la rotación del objeto hacia la dirección del objetivo.
      Quaternion nuevaRotacion = Quaternion.Slerp(
        rigidBody.rotation,
        Quaternion.LookRotation(direccion),
        velocidadRotacion * Time.deltaTime
      );
      rigidBody.MoveRotation(nuevaRotacion);      
      rigidBody.MovePosition(nuevaPosicion);
    }
  }
  // Actualiza la referencia al objeto objetivo si su nombre ha cambiado.
  private void OnValidate() {
    if (nombreObj2 != nombreObj2Anterior) {
      obj2 = GameObject.Find(nombreObj2);
      nombreObj2Anterior = nombreObj2;
      llegueAdestino = false;
    }
  }
  // Calcula el vector de dirección desde el objeto hacia el objetivo.
  private void calcularVectorObj1Obj2() {
    direccion = obj2.transform.position - transform.position; // Destino - Origen
    direccion.y = 0; // Se ignora la componente vertical.
  }
  // Detecta colisiones con el objeto objetivo para detener el movimiento.
  private void OnCollisionEnter(Collision colision) {
    if (colision.gameObject.name == nombreObj2) llegueAdestino = true;
  }
  // Permite reanudar el movimiento al salir de la colisión con el objetivo.
  private void OnCollisionExit(Collision colision) {
    if (colision.gameObject.name == nombreObj2) llegueAdestino = false;
  }  
}
