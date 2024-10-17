# Delegados, Eventos

## Objetivo

---

## Ejercicio 1
A partir de la escena que has estado utilizando en las últimas prácticas, crea la siguiente mecánica. crea la siguiente mecánica. Cuando el cubo colisiona con el cilindro, las esferas de tipo 1 se dirigen hacia una de las esferas de tipo 2 que fijes de antemano y las esferas de tipo 2 se desplazan hacia el cilindro.

En el gif, se puede observar cómo las esferas naranjas representan el tipo 1, mientras que las esferas rojas representan el tipo 2. Cuando el cilindro detecta que el cubo entra en contacto con él, se activa un mecanismo de notificación. En respuesta, las esferas de tipo 1 comienzan a desplazarse hacia la esfera de tipo 2 situada a la derecha. Al mismo tiempo, las esferas de tipo 2 se acercan hacia el cilindro. Este comportamiento crea una dinámica interesante entre los diferentes tipos de esferas y su interacción con el cilindro.

![eje1](https://github.com/user-attachments/assets/27381794-a306-452b-a3f5-9f34253fbded)

---

## Ejercicio 2
Sustituye los objetos geométricos por arañas para las esferas y huevo para el cilindro que encontrarás en el enlace

---

## Ejercicio 3
Adapta la escena anterior para que existan arañas de tipo 1 y de tipo 2, así como diferentes tipos de huevo, tipo 1 y tipo 2:
* Cuando el cubo colisiona con cualquier araña tipo 2,  las arañas en el grupo 1 se acercan a un objeto seleccionado. Cuando el cubo toca cualquier araña del grupo 1 se dirigen hacia los huevos del grupo 2 que serán objetos físico. Si alguna araña colisiona con uno de ellos debe cambiar de color. 

---

## Ejercicio 4
Cuando el cubo se aproxima al objeto de referencia, las arañas del grupo 1 se teletransportan a un huevo objetivo que debes fijar de antemano.Las arañas del grupo 2 se orientan hacia un objeto ubicado en la escena con ese propósito. 

---

## Ejercicio 5
Implementar la mecánica de recolectar huevo en la escena que actualicen la puntuación del jugador. Las arañas de tipo 1 suman 5 puntos y las arañas de tipo 2 suman 10. Mostrar la puntuación en la consola.

---

## Ejercicio 6
Partiendo del script anterior crea una interfaz que muestre la puntuación que va obteniendo el cubo. 

---

## Ejercicio 7
Partiendo de los ejercicios anteriores, implementa una mecánica en la que cada 100 puntos el jugador obtenga una recompensa que se muestre en la UI.

---

## Ejercicio 8
Genera una escena que incluya elementos que se ajusten a la escena del prototipo y alguna de las mecánicas anteriores.

---

## Ejercicio 9
Implementa el ejercicio 3 siendo el cubo un objeto físico.
