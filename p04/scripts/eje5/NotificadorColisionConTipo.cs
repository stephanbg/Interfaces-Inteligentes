using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificadorColisionConTipo : MonoBehaviour {
  public string[] tipos = {"Tipo1_huevo", "Tipo2_huevo"};
  public delegate void colision();
  public event colision OnColision;
  private void OnCollisionEnter(Collision colision) {
    foreach (string tipo in tipos) {
      if (colision.gameObject.CompareTag(tipo)) {
        OnColision();
        break;
      }
    }
  }
}
