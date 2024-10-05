# Introducción C# - Scripts

---

## Objetivos

El objetivo de estos ejercicios es familiarizarse con la creación y manipulación de objetos en Unity, utilizando scripting para controlar propiedades como color, posición y distancia, así como aprender a gestionar componentes y etiquetas. Esto incluye tanto la interacción con la interfaz como el manejo de la lógica de programación en C#.

---

## Ejercicios

**1.-** Crea un script asociado a un objeto en la escena que inicialice un vector de 3 posiciones con valores entre 0.0 y 1.0, para tomarlo como un vector de color (Color). Cada 120 frames se debe cambiar el valor de una posición aleatoria y asignar el nuevo color al objeto. Parametrizar la cantidad de frames de espera para poderlo cambiar desde el inspector.

![eje1](https://github.com/user-attachments/assets/c4254ead-d9d0-43f7-8889-607a0ad0270a)

**2.-** Crea una escena simple en la que ubiques un plano y sobre él un cubo, una esfera y un cilindro. Cada uno de los objetos debe estar en un color diferente. En la consola cada objeto debe mostrar su nombre.

![eje2](https://github.com/user-attachments/assets/4409a458-823a-488c-9ec2-39758ffab6df)

**3.-** Crea un script asociado a la esfera con dos variables Vector3 públicas. Dale valor a cada componente de los vectores desde el inspector. Muestra en la consola:
- La magnitud de cada uno de ellos. 
- El ángulo que forman
- La distancia entre ambos.
- Un mensaje indicando qué vector está a una altura mayor.
Muestra en el inspector cada uno de esos valores.

![eje3](https://github.com/user-attachments/assets/914cbf7e-1faa-4ff3-ad08-8d0b7ce3e52b)

**4.-** Muestra en pantalla el vector con la posición de la esfera.

![eje4](https://github.com/user-attachments/assets/1a6b3942-7954-441d-81ff-07f37946be5c)

**5.-** Crea un script para la esfera que muestre en consola la distancia a la que están el cubo y el cilindro.

![eje5](https://github.com/user-attachments/assets/f60375d9-5697-47eb-a6ad-5b8ec9755554)

**6.-** Selecciona tres posiciones en tu escena a través de un objeto invisible (marcador) que incluya 3 vectores numéricos para configurar posiciones en las que quieres ubicar los objetos en respuesta a pulsar la barra espaciadora. Estos vectores representan un desplazamiento respecto a la posición original del objeto. Crea un script que ubique en las posiciones configuradas cuando el usuario pulse la barra espaciadora. 

![eje6](https://github.com/user-attachments/assets/77ef5842-c7ae-4d7a-ada5-a1d92e4a3859)

**7.-** Cambia el color del cilindro cuando el usuario pulse la tecla C, cambia el color del cubo cuando el usuario pulse la flecha arriba.

![eje7](https://github.com/user-attachments/assets/f6ddfd4e-342a-420a-a0bf-9cdf29e0bea6)

**8.-** Agrega 5 esferas más en la escena. Crea un grupo de 2 , asígnales la misma etiqueta para indicar esferas de tipo 1 y a las restantes otra etiqueta diferente a ésta para indicar esferas de grupo 2. En la escena también habrá un cubo. Implementa un script que aumente la altura de la esfera de tipo 2 más cercana al cubo. Cambia el color de la más lejana cuando el jugador pulsa la tecla espacio.

![eje8](https://github.com/user-attachments/assets/c6fdaaec-70bd-4633-b2a9-08f30b5c4991)
