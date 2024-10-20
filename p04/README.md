# Delegados, Eventos

## Objetivo

El objetivo de esta práctica es implementar una mecánica de interacción compleja utilizando colisiones y triggers en Unity. A través de la interacción entre diferentes tipos de objetos (cubo, arañas y huevos), se busca desarrollar un sistema de recolección que actualice la puntuación del jugador y presente recompensas a medida que se alcanzan ciertos hitos. Además, se requiere integrar una interfaz de usuario (UI) que muestre la puntuación actual y las recompensas obtenidas, proporcionando una experiencia más inmersiva y dinámica en la escena.

Durante esta práctica, también se aprenderá a implementar el **patrón observador**, que permite gestionar la comunicación entre los objetos de manera eficiente y reactiva, facilitando la respuesta a eventos como colisiones y cambios en el estado del juego. Esto ayudará a comprender mejor la gestión de colisiones y la interacción de objetos.

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

![eje5](https://github.com/user-attachments/assets/b283a55a-8cb8-4a87-9997-1d98d253ff64)

---

## Ejercicio 6
Partiendo del script anterior crea una interfaz que muestre la puntuación que va obteniendo el cubo. 

En el gif se puede ver cómo he integrado el elemento canvas, y a su vez, dentro del mismo el elemento de TextMeshPro que muestra la puntuación actual del cubo. A medida que el cubo recolecta huevos a través de las distintas arañas, la puntuación se actualiza en tiempo real, reflejando los puntos obtenidos por cada tipo de araña. (He decidido no desactivar los huevos, debido a que hay muy pocos en la escena y no se podría llegar a una puntuación alta).

![eje6](https://github.com/user-attachments/assets/94a57e49-c18a-421d-861a-5a604fb332ed)

---

## Ejercicio 7
Partiendo de los ejercicios anteriores, implementa una mecánica en la que cada 100 puntos el jugador obtenga una recompensa que se muestre en la UI.

En el gif, se observa cómo el jugador recolecta huevos, acumulando puntos a medida que avanza. Al llegar a 100 puntos, se activa un mensaje de recompensa que aparece en la pantalla, informando al usuario sobre su logro.

Una vez que se muestra el mensaje de recompensa, el juego se pausa automáticamente. Esto significa que el jugador no puede continuar hasta que presione la barra espaciadora. Esta pausa permite que el jugador se tome un momento para leer el mensaje y reflexionar sobre su progreso antes de seguir adelante.

Además, para demostrar de manera más efectiva el sistema de puntuación y recompensas, se utilizó el script de teletransporte. Este script permite que las arañas recojan puntos más rápidamente, lo que facilita que el jugador alcance los hitos de 100 y 200 puntos en menos tiempo. De esta forma, se pudo observar cómo se activaban los mensajes de recompensa en diferentes momentos del juego, evidenciando la dinámica de puntuación y recompensas.

![eje7](https://github.com/user-attachments/assets/4df89dcd-14aa-4dd4-ab12-eb5d4b01bdcb)

---

## Ejercicio 8
Genera una escena que incluya elementos que se ajusten a la escena del prototipo y alguna de las mecánicas anteriores.

En este proyecto, hemos desarrollado un entorno interactivo con una atmósfera de miedo, ambientado en una habitación de hospital abandonado. Aquí te detallo las mecánicas implementadas y cómo cada una contribuye a la experiencia general:

### Mecánica de abrir la puerta

En el primer gif, se puede observar la mecánica para abrir la puerta. El usuario simplemente hace clic en la pantalla, lo que provoca que la puerta se desplace hacia la izquierda. Esta interacción no solo establece un sentido de inmersión, sino que también permite al jugador explorar diferentes áreas del hospital, aumentando la curiosidad y la tensión.

![eje8-puerta](https://github.com/user-attachments/assets/73b21abb-0fef-4cc7-87f7-beacb2c1456e)

### Interacción con el aparato de electricidad

El segundo gif muestra cómo se puede interactuar con un dispositivo que controla la electricidad. Al hacer clic en la pantalla, el usuario puede encender o apagar la luz. Esta mecánica es fundamental para crear un ambiente inquietante; la iluminación juega un papel crucial en el terror psicológico, y la capacidad de manipularla añade una capa de control al jugador, mientras que también genera un sentido de vulnerabilidad.

![eje8-luz](https://github.com/user-attachments/assets/ebeb639d-c225-41a3-88ab-86f4a466ca62)

### Sistema de Inventario

En el último gif, se presenta el sistema de inventario, donde los objetos recolectables pueden ser recogidos haciendo clic en la pantalla. Una vez que el jugador interactúa con un objeto, este se almacena en el inventario y se destruye de la escena. Esto no solo promueve la exploración, sino que también añade un elemento de estrategia, ya que los jugadores deben decidir qué objetos son más útiles para su progreso en el juego.

![eje8-recolectables](https://github.com/user-attachments/assets/bc88437b-0541-4479-b4d0-75af1445e26d)

Todo este sistema se desarrolla en un entorno de hospital abandonado, que es clave para el tono de miedo y misterio del juego. La combinación de mecánicas interactivas, exploración y una ambientación cuidadosamente diseñada se alinea perfectamente con la temática, creando una experiencia envolvente que busca mantener al jugador en tensión constantemente.

---

## Ejercicio 9
Implementa el ejercicio 3 siendo el cubo un objeto físico.

En el ejercicio 3 ya había implementado el cubo como objeto físico, moviéndolo con MovePosition y utilizando el método FixedUpdate.
