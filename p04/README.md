# Delegados, Eventos

## Objetivo

---

## Ejercicio 1
A partir de la escena que has estado utilizando en las últimas prácticas, crea la siguiente mecánica. crea la siguiente mecánica. Cuando el cubo colisiona con el cilindro, las esferas de tipo 1 se dirigen hacia una de las esferas de tipo 2 que fijes de antemano y las esferas de tipo 2 se desplazan hacia el cilindro.

En el gif, se puede observar cómo las esferas naranjas representan el tipo 1, mientras que las esferas rojas representan el tipo 2. Cuando el cilindro detecta que el cubo entra en contacto con él, se activa un mecanismo de notificación. En respuesta, las esferas de tipo 1 comienzan a desplazarse hacia la esfera de tipo 2 situada a la derecha. Al mismo tiempo, las esferas de tipo 2 se acercan hacia el cilindro. Este comportamiento crea una dinámica interesante entre los diferentes tipos de esferas y su interacción con el cilindro.

![eje1](https://github.com/user-attachments/assets/27381794-a306-452b-a3f5-9f34253fbded)

---

## Ejercicio 2
Sustituye los objetos geométricos [por arañas para las esferas y huevo para el cilindro](https://assetstore.unity.com/packages/3d/characters/creatures/fuga-spiders-with-destructible-eggs-and-mummy-151921) que encontrarás en el enlace

En este gif, se muestra la sustitución del cilindro por un huevo, así como el reemplazo de las esferas por arañas. Es importante destacar que realicé un análisis del Animator para comprender el momento exacto en que ocurre la transición de IDLE a RUN. Esto me permitió programar el comportamiento adecuado para que, al chocar el cubo con el huevo, las arañas comenzaran a moverse.

![eje2](https://github.com/user-attachments/assets/fd143cf6-9d47-4757-802c-4a97b4f0ea6b)

---

## Ejercicio 3
Adapta la escena anterior para que existan arañas de tipo 1 y de tipo 2, así como diferentes tipos de huevo, tipo 1 y tipo 2:
* Cuando el cubo colisiona con cualquier araña tipo 2,  las arañas en el grupo 1 se acercan a un objeto seleccionado. Cuando el cubo toca cualquier araña del grupo 1 se dirigen hacia los huevos del grupo 2 que serán objetos físico. Si alguna araña colisiona con uno de ellos debe cambiar de color. 

En el gif, el cubo interactúa inicialmente con una araña de tipo 1, lo que provoca que ambas arañas de este tipo se dirijan hacia un huevo aleatorio de tipo 2, donde cambian de color. Posteriormente, al tocar una araña de tipo 2, las arañas de tipo 1 se dirigen hacia la momia en la escena.

![eje3](https://github.com/user-attachments/assets/b963d386-fbaa-488a-8829-7c798975d6b9)

---

## Ejercicio 4
Cuando el cubo se aproxima al objeto de referencia, las arañas del grupo 1 se teletransportan a un huevo objetivo que debes fijar de antemano.Las arañas del grupo 2 se orientan hacia un objeto ubicado en la escena con ese propósito. 

En elgif se observa cómo, al acercarse el cubo a una cierta distancia de la momia, se desencadenan varias acciones. Primero, las arañas de tipo 1 se teletransportan al huevo que se encuentra en la parte inferior de la pantalla. Al mismo tiempo, las tres arañas de tipo 2 ajustan su orientación para mirar hacia el quad ubicado en la pared izquierda.

Una vez que el cubo se aleja y supera la distancia crítica, todas las arañas regresan a su estado original, restableciendo así su comportamiento previo.

![eje4](https://github.com/user-attachments/assets/b3c6043c-e67e-47d2-a2b5-5e3256558210)

---

## Ejercicio 5
Implementar la mecánica de recolectar huevo en la escena que actualicen la puntuación del jugador. Las arañas de tipo 1 suman 5 puntos y las arañas de tipo 2 suman 10. Mostrar la puntuación en la consola.

En el gif se puede observar cómo las dos arañas en la parte inferior pertenecen al tipo 1. Al colisionar con un huevo, su puntuación aumenta en 5 puntos. Por otro lado, las arañas situadas en la parte superior son del tipo 2 y, al chocar con un huevo, incrementan la puntuación en 10 puntos.

![eje5](https://github.com/user-attachments/assets/2bebbc76-9de3-4ca9-850c-c4c4a458bacc)

---

## Ejercicio 6
Partiendo del script anterior crea una interfaz que muestre la puntuación que va obteniendo el cubo. 

En el gif se puede ver cómo he integrado el elemento canvas, y a su vez, dentro del mismo el elemento de TextMeshPro que muestra la puntuación actual del cubo. A medida que el cubo recolecta huevos a través de las distintas arañas, la puntuación se actualiza en tiempo real, reflejando los puntos obtenidos por cada tipo de araña. (He decidido no desactivar los huevos, debido a que hay muy pocos en la escena y no se podría llegar a una puntuación alta).

![eje6](https://github.com/user-attachments/assets/2e8bc0eb-2c59-48f6-9be4-064249af3430)

---

## Ejercicio 7
Partiendo de los ejercicios anteriores, implementa una mecánica en la que cada 100 puntos el jugador obtenga una recompensa que se muestre en la UI.

---

## Ejercicio 8
Genera una escena que incluya elementos que se ajusten a la escena del prototipo y alguna de las mecánicas anteriores.

---

## Ejercicio 9
Implementa el ejercicio 3 siendo el cubo un objeto físico.