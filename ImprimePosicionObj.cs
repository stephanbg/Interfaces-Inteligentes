using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprimePosicionObj : MonoBehaviour {
 public GameObject obj;
 void Start() {
   Vector3 posiciones = obj.transform.position;
   Debug.Log(
     "El objeto con nombre " + obj.name + " se encuentra en la posición (x: " +
     posiciones[0] + ", y: " + posiciones[1] + ", z: " + posiciones[2] + ")"
   );
 }
}
