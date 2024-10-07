/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 2 de Octubre de 2024
 * @file MoverObjetos.cs
 * @brief Este script mueve tres objetos en el espacio 3D cuando se presiona la tecla de salto. 
 *        Utiliza desplazamientos predefinidos para cada objeto, aplicando un movimiento continuo 
 *        basado en el tiempo transcurrido entre frames.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que gestiona el movimiento de tres objetos etiquetados en la escena.
public class MoverObjetos : MonoBehaviour {
 // Variables para almacenar referencias a los objetos a mover.
 private GameObject obj1, obj2, obj3;
 // Vectores de desplazamiento para cada objeto.
 public Vector3 desplazamiento1 = new Vector3(0.7f, -0.5f, 0.5f);
 public Vector3 desplazamiento2 = new Vector3(-0.5f, 0.5f, -0.5f);
 public Vector3 desplazamiento3 = new Vector3(0.5f, -0.5f, 0.3f);
 // Método llamado al iniciar el script, para buscar y asignar los objetos por sus etiquetas.
 void Start() {
   obj1 = GameObject.FindGameObjectWithTag("obj1-eje6");
   obj2 = GameObject.FindGameObjectWithTag("obj2-eje6");
   obj3 = GameObject.FindGameObjectWithTag("obj3-eje6");
 }
 // Método llamado en cada frame.
 void Update() {
   // Verificar si se está presionando la tecla de salto.
   if (Input.GetAxis("Jump") > 0) {
     // Mover los objetos aplicando el desplazamiento multiplicado por el tiempo delta.
     obj1.transform.position += desplazamiento1 * Time.deltaTime;
     obj2.transform.position += desplazamiento2 * Time.deltaTime;
     obj3.transform.position += desplazamiento3 * Time.deltaTime;
   }
 }
}
