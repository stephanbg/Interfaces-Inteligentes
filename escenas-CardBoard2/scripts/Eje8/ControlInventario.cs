/**
 * Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Interfaces Inteligentes
 *
 * @author Stephan Brommer Gutiérrez
 * @since 7/11/2024
 * @file ControlInventario.cs
 * @brief Este script gestiona un inventario de objetos recolectados en el juego,
 *        permitiendo agregar objetos al inventario y actualizar la interfaz de usuario 
 *        para reflejar los cambios. Eje8
 */

using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Clase que gestiona un inventario de objetos recolectados.
public class ControlInventario : MonoBehaviour {
  public NotificadorRecolectorObjetos[] notificadores; // Array de notificadores para los objetos recolectores.
  public TextMeshProUGUI textoContenido; // Componente de texto para mostrar el contenido del inventario.
  private List<string> inventario = new List<string>(); // Lista que almacena los nombres de los objetos en el inventario.
  // Método que se llama al iniciar el script.
  private void Awake() {
    if (notificadores != null) {
      foreach (NotificadorRecolectorObjetos notificador in notificadores) {
        if (notificador != null) notificador.OnClick += agregarElementoAInventario;
      }
    }
  }
  // Agrega un elemento al inventario y lo destruye.
  private void agregarElementoAInventario(GameObject obj) {
    inventario.Add(obj.name);
    if (obj != null) {
      obj.layer = LayerMask.NameToLayer("Default");
      Collider collider = obj.GetComponent<Collider>();
      if (collider != null) collider.enabled = false;
      Destroy(obj);
    }
    actualizarTextoInventario();
  }
  // Actualiza el texto del inventario en la interfaz de usuario.
  private void actualizarTextoInventario() {
    textoContenido.text = string.Join("\n", inventario);
  }
}
