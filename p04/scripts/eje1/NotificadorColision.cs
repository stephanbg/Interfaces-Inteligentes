using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificadorColision : MonoBehaviour {
  public string nombreObjColision = "Cube";
  public delegate void colision();
  public event colision OnColision;
  private void OnCollisionEnter(Collision colision) {
    if (colision.gameObject.name == nombreObjColision) OnColision();
  }
}
