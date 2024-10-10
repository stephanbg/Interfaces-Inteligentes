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

Por lo tanto, como se observa a continuación, todos los objetos tienen la misma masa, lo que permite que la gravedad actúe de manera uniforme sobre ellos, haciendo que caigan simultáneamente.

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

## Situación 9

El plano es un objeto físico. El cubo es un objeto físico y la esfera es física y es Trigger. En este caso, todos los objetos deben tener Rigidbody.

## Notas adicionales

- Para mover un RigidBody, es aconsejable utilizar métodos como AddForce, MovePosition o MoveRotation, que están diseñados específicamente para interactuar con la física del motor. Estos métodos garantizan un comportamiento coherente y predecible dentro de la simulación. Manipular directamente el transform de un RigidBody puede dar lugar a situaciones imprevistas, como colisiones erráticas o movimientos no deseados, ya que no se alinean con los cálculos físicos que gestiona el motor.
  
- La masa de un objeto juega un papel crucial en las fuerzas de colisión entre objetos. Un objeto con mayor masa ejercerá más fuerza al colisionar, lo que influye en el movimiento resultante de ambos objetos. Por otro lado, el drag afecta la resistencia al movimiento a través del aire, lo que impacta en la velocidad de caída del objeto. A mayor drag, mayor será la desaceleración, lo que puede hacer que los objetos caigan más lentamente en comparación con aquellos con menos drag.
