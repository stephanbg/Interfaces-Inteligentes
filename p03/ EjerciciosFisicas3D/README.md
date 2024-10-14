# Ejercicio Físicas 3D

El ejercicio consiste en experimentar con diferentes configuraciones de los components Rigidbody y Collider y explicar los resultados obtenidos en base a lo explicado en clase. Para ello vamos a configurar una escena con 3 objetos:

- Plano, Cubo y Esfera. El plano, y la cámara se ubican en las posiciones por defecto. El cubo se ubica con y=0.5.

![ejercicioFisicas3D](https://github.com/user-attachments/assets/6fc2d94b-6553-4cc6-b845-2f3050aa3b9f)


## Situación 1

El plano no es un objeto físico. El cubo es un objeto físico y la esfera no. En este caso, el plano y la esfera sólo tendrán collider, mientras que el cubo debe tener Rigidbody.

- Cubo (Rigidbody y Box Collider):
  
  - Función: Objeto físico que cae y colisiona.
  - Componentes:
    - Rigidbody: Permite la interacción física (gravedad, movimiento).
    - Box Collider: Define la forma de colisión del cubo, permitiendo detectar interacciones con otros objetos.

![Cubo1](https://github.com/user-attachments/assets/3a7ba7b6-9b98-4980-b6b2-3d756f8783fb)

- Esfera (Sphere Collider):

  - Función: Detecta colisiones sin moverse.
  - Componentes: Sphere Collider permite activar eventos al colisionar con otros objetos (Predeterminado).

![Esfera1](https://github.com/user-attachments/assets/121cb1b7-cc80-485d-8d6f-0292fa24a8c0)

- Plano (Mesh Collider):

  - Función: Superficie estática que detiene al cubo.
  - Componentes: Mesh Collider permite que el cubo colisione sin ser un objeto físico en movimiento (Predeterminado).

![Plano1](https://github.com/user-attachments/assets/80fab29a-8e42-41fb-ab28-8180e1c3ecaf)

Se puede comprobar como al cubo le afecta la gravedad y rebota con la esfera y el plano.

![situacion1](https://github.com/user-attachments/assets/6a48aabc-3cc1-47cf-bd6f-81c77f0e2a3b)

## Situación 2

El plano no es un objeto físico. El cubo es un objeto físico y la esfera también. En este caso, el plano sólo tendrán collider, mientras que el cubo y la esfera deben tener Rigidbody.

- Cubo y Esfera (Rigidbody, Box Collider y Sphere Collider):
  - Sucede lo mismo que con el cubo en la situación 1.

Solo se muestra el componente añadido de RigidBody a la esfera, debido a que es lo nuevo en esta escena.

![Esfera2](https://github.com/user-attachments/assets/a8b27327-3738-4843-aaa1-20604a8b8f3f)

- Plano (Mesh Collider):
  - El plano no cambia respecto a la situación 1.
 
Se puede observar cómo tanto el cubo como la esfera son afectados por la gravedad, rebotan entre sí y se detienen al interactuar con el plano.

![situacion2](https://github.com/user-attachments/assets/5673bbc1-27b6-44d5-b0e5-9a902d13c689)

## Situación 3

El plano no es un objeto físico. El cubo es un objeto físico y la esfera es cinemática. En este caso, el plano sólo tendrán collider, mientras que el cubo y la esfera deben tener Rigidbody esta última cinemático.

- Cubo y Esfera (Rigidbody, Box Collider y Sphere Collider):
  - Sucede lo mismo que con el cubo en la situación 1.
  - A la esfera se le añade también que sea **cinemática**.
 
  ![isKinematic](https://github.com/user-attachments/assets/0d380056-7b10-4adc-b1f0-5d620b97a45d)

Un RigidBody cinemático permite que un objeto se mueva y se controle manualmente sin ser afectado por la gravedad o fuerzas físicas. Esto significa que puedes posicionarlo y moverlo a voluntad, pero aún así puede colisionar con otros objetos y empujarlos.

La principal diferencia con un simple Collider es que, mientras que un Collider solo detecta colisiones y no tiene interacción física, un RigidBody cinemático puede influir en otros objetos en la escena. Esto permite que el objeto con el RigidBody cinemático participe activamente en la simulación de colisiones, manteniendo una lógica de movimiento más coherente y flexible dentro del motor de física.

- Plano (Mesh Collider):
  - El plano no cambia respecto a la situación 1.

Se puede observar que el cubo, al ser un RigidBody, sigue respondiendo a las fuerzas físicas, como la gravedad y las colisiones. En contraste, al activar el modo cinemático en la esfera, se desactiva su interacción con la física, lo que le permite ser controlada manualmente. Esto significa que, aunque la esfera no es afectada por la gravedad ni por otras fuerzas, puede interactuar con el cubo, permitiendo un manejo más preciso de las colisiones. Por otro lado, el plano actúa como un 'muro', funcionando como un Collider que detiene tanto al cubo como a cualquier otro objeto que se encuentre con él.

![situacion3](https://github.com/user-attachments/assets/874e248c-ab8d-4c8d-8d13-51cfac810efa)

## Situación 4

El plano es un objeto físico. El cubo es un objeto físico y la esfera es física. En este caso, todos los objetos deben tener Rigidbody.

- Cubo, Esfera y Plano (Rigidbody, Box Collider, Sphere Collider y Mesh Collider):
  - Ahora los 3 objetos de la escena son RigidBody, por lo que reciben interacciones físicas (gravedad, movimiento).

Por lo tanto, como se observa a continuación, todos los objetos tienen la misma fricción (drag), lo que permite que la gravedad actúe de manera uniforme sobre ellos, haciendo que caigan simultáneamente.

![situacion4](https://github.com/user-attachments/assets/822a00b0-a10a-475c-acfa-239310c8951b)

## Situación 5

El plano es un objeto físico. El cubo es un objeto físico y la esfera es física con 10 veces más masa que el cubo. En este caso, todos los objetos deben tener Rigidbody.

- Cubo, Esfera y Plano (Rigidbody, Box Collider, Sphere Collider y Mesh Collider):
  - Sucede lo mismo que en la situación 4, pero ahora la esfera tiene 10 veces más masa que el cubo. Por defecto todos tienen de masa 1.

![Masax10](https://github.com/user-attachments/assets/11e8f4d7-959b-46a5-99f8-9fbdee1ce5b3)

Al aumentar la masa de un objeto, uno podría pensar que debería caer más rápido que los demás debido a la gravedad. Sin embargo, en un entorno de simulación física como Unity, todos los objetos, independientemente de su masa, caen a la misma velocidad en ausencia de resistencia. Esto se debe a que la aceleración debida a la gravedad es constante y actúa de igual manera sobre todos los cuerpos.

En esta escena, como no hemos configurado factores como la fricción o la resistencia del aire, todos los objetos experimentan la misma aceleración gravitacional, lo que resulta en que caen simultáneamente. En condiciones ideales, sin otros factores que afecten el movimiento, la masa no influye en la velocidad de caída de un objeto. El gif quedaría igual que la situación 4.

![situacion4](https://github.com/user-attachments/assets/822a00b0-a10a-475c-acfa-239310c8951b)

## Situación 6

El plano es un objeto físico, al igual que el cubo, mientras que la esfera tiene una masa 100 veces mayor que la del cubo. En este caso, todos los objetos deben tener un componente Rigidbody.

![Masax100](https://github.com/user-attachments/assets/6b17a23a-3a15-4cd8-b360-68a47b9c3c58)

En esta situación, la configuración es similar a la anterior, con la única diferencia de que la esfera posee una masa significativamente mayor. Sin embargo, al igual que antes, aunque incrementemos la masa de un objeto, si no ajustamos factores como la fricción o otros elementos de la escena, la velocidad de caída de todos los objetos será la misma.

![situacion4](https://github.com/user-attachments/assets/822a00b0-a10a-475c-acfa-239310c8951b)

## Situación 7

El plano es un objeto físico. El cubo es un objeto físico y la esfera es física con fricción. En este caso, todos los objetos deben tener Rigidbody.

Los 3 objetos son RigidBody como en las situaciones anteriores, lo único que se le añade fricción (Drag) a la esfera para que veamos como si que cambia su velocidad al caer respecto al resto de objetos.

![Friccion](https://github.com/user-attachments/assets/122961ac-0edd-4d44-a3d8-8ada10b5acd9)

En este gif se puede observar como al añadirle 10 de fricción a la esfera va a caer más lento que los otros dos objetos.

![situacion7](https://github.com/user-attachments/assets/ab75b60d-feca-49c8-90de-5e0b4449fc8a)

## Situación 8

El plano es un objeto físico. El cubo es un objeto físico y la esfera no es física y es Trigger. En este caso, todos los objetos deben tener Rigidbody.

En esta situación, para que la esfera no actúe como un objeto físico, pero aún así tenga el componente Rigidbody, es necesario activar la opción de cinemática. Esto se debe a que, al configurarla como cinemática, la esfera no será afectada por la gravedad ni por fuerzas externas, lo que le permite evitar interacciones físicas directas con otros objetos en la escena.

![trigger](https://github.com/user-attachments/assets/12e1b205-2615-4e67-9da7-dcf0ce86f7f1)

![isKinematic](https://github.com/user-attachments/assets/0d380056-7b10-4adc-b1f0-5d620b97a45d)

En este gif, se observa que, al ser cinemática, la esfera no se ve influenciada por la física, lo que significa que no rebotará al chocar con otros objetos. Además, dado que la esfera tiene activada la opción de Trigger, no bloquea ni empuja a los otros objetos, permitiendo que estos atraviesen su collider sin generar efectos visuales de colisión. Esto permite utilizar la esfera para detectar eventos sin interferir en la dinámica del entorno físico.

![situacion8](https://github.com/user-attachments/assets/dd883b2f-3dee-4926-8d4c-ed8a72e1a00a)

## Situación 9

El plano es un objeto físico. El cubo es un objeto físico y la esfera es física y es Trigger. En este caso, todos los objetos deben tener Rigidbody.

Los tres objetos son Rigidbody, pero se añade a la esfera la configuración de Trigger. Un Rigidbody configurado como Trigger puede detectar cuándo otros colliders entran o salen de su área sin generar una respuesta física. Esto significa que, aunque participa en la simulación física, no bloquea ni empuja a otros objetos. Se utiliza principalmente para activar eventos en el juego, como iniciar diálogos o activar mecánicas, permitiendo interacciones flexibles.

En el gif, ajustaré el drag para mostrar cómo la esfera, al ser un Rigidbody configurado como Trigger, atraviesa otros objetos. Aunque detecta las colisiones, solo las utiliza para activar eventos y no genera efectos visuales de colisión.

![situacion9](https://github.com/user-attachments/assets/26cc2bb3-529a-4f8d-bbf7-ef28a1d1ee39)

## Notas adicionales

***1.- Métodos para Mover Rigidbodies:***

Al trabajar con objetos que tienen un componente Rigidbody, es fundamental utilizar métodos como AddForce, MovePosition o MoveRotation. Estos métodos están diseñados para interactuar con el motor físico de Unity y garantizan un comportamiento predecible en la simulación. Manipular directamente el transform de un Rigidbody puede llevar a situaciones imprevistas, como colisiones erráticas o movimientos no deseados, ya que no se alinean con los cálculos físicos gestionados por el motor.

***2.- Influencia de la Masa en las Colisiones:***

La masa de un objeto desempeña un papel crucial en las fuerzas de colisión. Un objeto con mayor masa ejercerá más fuerza al colisionar, lo que afecta al movimiento resultante de ambos objetos involucrados. Por ejemplo, en una colisión entre un cubo ligero y una esfera pesada, la esfera (siendo más masiva) seguirá moviéndose con más velocidad tras la colisión, mientras que el cubo experimentará un cambio de velocidad más significativo.

***3.- Efecto del Drag en el Movimiento:***

El drag representa la resistencia al movimiento a través del aire. Un objeto con un drag alto experimentará una desaceleración más pronunciada en comparación con uno con menos drag. Por ejemplo, si se lanza un cubo y una esfera con el mismo impulso, el cubo con mayor drag caerá más lentamente y se detendrá antes que la esfera, que tiene menos resistencia.

***4.- Uso de Triggers en el Juego:***

Los triggers permiten detectar colisiones sin generar una respuesta física. Esto es útil para activar eventos en el juego, como iniciar diálogos, recolectar objetos o activar mecanismos. Por ejemplo, al entrar en el área de un trigger, un personaje podría activar una animación o recibir un objeto sin que los colisionadores interfieran físicamente con su movimiento.

***5.- Prácticas de Optimización:***

Para mejorar el rendimiento de la simulación física, es recomendable utilizar colliders simplificados y ajustar las propiedades de los Rigidbody según las necesidades del juego. Por ejemplo, los objetos que no requieren interacción física constante pueden configurarse como Rigidbody cinemáticos para optimizar el procesamiento.
