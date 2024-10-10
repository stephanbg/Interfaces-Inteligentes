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

![Cubo](https://github.com/user-attachments/assets/3a7ba7b6-9b98-4980-b6b2-3d756f8783fb)

- Esfera (Sphere Collider):

  - Función: Detecta colisiones sin moverse.
  - Componentes: Sphere Collider permite activar eventos al colisionar con otros objetos (Predeterminado).

![Esfera](https://github.com/user-attachments/assets/121cb1b7-cc80-485d-8d6f-0292fa24a8c0)

- Plano (Mesh Collider):

  - Función: Superficie estática que detiene al cubo.
  - Componentes: Mesh Collider permite que el cubo colisione sin ser un objeto físico en movimiento (Predeterminado).

![Plano](https://github.com/user-attachments/assets/80fab29a-8e42-41fb-ab28-8180e1c3ecaf)

Se puede comprobar como al cubo le afecta la gravedad y rebota con la esfera y el plano.

![situacion1](https://github.com/user-attachments/assets/6a48aabc-3cc1-47cf-bd6f-81c77f0e2a3b)

## Situación 2

El plano no es un objeto físico. El cubo es un objeto físico y la esfera también. En este caso, el plano sólo tendrán collider, mientras que el cubo y la esfera deben tener Rigidbody.

## Situación 3

El plano no es un objeto físico. El cubo es un objeto físico y la esfera es cinemática. En este caso, el plano sólo tendrán collider, mientras que el cubo y la esfera deben tener Rigidbody esta última cinemático.

## Situación 4

El plano es un objeto físico. El cubo es un objeto físico y la esfera es física. En este caso, todos los objetos deben tener Rigidbody.

## Situación 5

El plano es un objeto físico. El cubo es un objeto físico y la esfera es física con 10 veces más masa que el cubo. En este caso, todos los objetos deben tener Rigidbody.

## Situación 6

El plano es un objeto físico. El cubo es un objeto físico y la esfera es física con 100 veces más masa que el cubo. En este caso, todos los objetos deben tener Rigidbody.

## Situación 7

El plano es un objeto físico. El cubo es un objeto físico y la esfera es física con fricción. En este caso, todos los objetos deben tener Rigidbody.

## Situación 8

El plano es un objeto físico. El cubo es un objeto físico y la esfera no es física y es Trigger. En este caso, todos los objetos deben tener Rigidbody.

## Situación 9

El plano es un objeto físico. El cubo es un objeto físico y la esfera es física y es Trigger. En este caso, todos los objetos deben tener Rigidbody.