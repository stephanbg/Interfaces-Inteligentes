# Movimiento - Físicas

---

## Objetivos

---

### Ejercicio 1

Agrega un campo velocidad a un cubo y asígnale un valor que se pueda cambiar en el inspector de objetos. Muestra la consola el resultado de multiplicar la velocidad por el valor del eje vertical y por el valor del eje horizontal cada vez que se pulsan las teclas flecha arriba-abajo ó flecha izquierda-derecha. El mensaje debe comenzar por el nombre de la flecha pulsada.

![eje1](https://github.com/user-attachments/assets/c6c1b1e0-9557-451c-8e5d-08b25086c025)

---

### Ejercicio 2

Mapea la tecla H a la función disparo.

![eje2](https://github.com/user-attachments/assets/02132b89-73d2-456d-8f7c-433f54290c03)

---

### Ejercicio 3

Crea un script asociado al cubo que en cada iteración traslade al cubo una cantidad proporcional un vector que indica la dirección del movimiento: moveDirection que debe poder modificarse en el inspector.  La velocidad a la que se produce el movimiento también se especifica en el inspector, con la propiedad speed. Inicialmente la velocidad debe ser mayor que 1 y el cubo estar en una posición y=0. En el informe de la práctica comenta los resultados que obtienes en cada una de las siguientes situaciones:

**NOTA:** He utilizado la normalización del vector de dirección para asegurar que el objeto se mueva a una velocidad constante, independientemente de la longitud del vector. Sin normalización, si movimientoDireccion tiene una longitud mayor o menor a 1, el objeto se moverá más rápido o más lento. Al normalizar el vector, siempre se multiplica por una dirección con longitud 1, lo que garantiza que el movimiento dependa solo de la velocidad y la proporcionalidad, evitando comportamientos inesperados.

 a.- duplicas las coordenadas de la dirección del movimiento.

![eje3(a)](https://github.com/user-attachments/assets/5562688d-a647-4c6c-9543-9cf61db7290f)

Al duplicar las coordenadas del vector de dirección, aumentas la velocidad de movimiento del cubo porque el desplazamiento total en cada iteración se calcula multiplicando la dirección (que ahora es más larga, pero sigue apuntando en la misma dirección) por la velocidad. Esto significa que, al incrementar la longitud del vector de dirección, el cubo se mueve más rápidamente en cada actualización, ya que se desplaza una mayor distancia en el mismo intervalo de tiempo.

 b.- duplicas la velocidad manteniendo la dirección del movimiento.

 ![eje3(b)](https://github.com/user-attachments/assets/f8f4f479-7ce2-4e22-818c-23458fdfe75b)

En este segundo caso, al duplicar la velocidad y mantener la proporcionalidad sin cambios, se obtiene el mismo resultado que en el apartado (a). Esto se debe a que, al final, simplemente se está multiplicando la fórmula original por un factor de 2.

```bash
transform.Translate(movimientoDireccion.normalized * proporcionalidad * velocidad * Time.deltaTime);
```

Por lo tanto, al duplicar la velocidad, efectivamente se duplica el desplazamiento total del cubo en cada iteración, igualando el efecto de haber duplicado la dirección del movimiento. Ambos enfoques llevan al cubo a la misma posición final tras un intervalo de tiempo determinado.
 
 c.- la velocidad que usas es menor que 1.

 ![eje3(c)](https://github.com/user-attachments/assets/bfbd5ac6-1e61-49ad-a00e-89232ed922dd)

Al utilizar una velocidad de 0.5, estamos limitando el desplazamiento del cubo, lo que efectivamente actúa como un factor de división por 2. Por lo tanto, aunque el cubo se mueve en la misma dirección, lo hace a una velocidad reducida, resultando en un desplazamiento más lento. al utilizar una velocidad de 0.5, estamos limitando el desplazamiento del cubo, lo que efectivamente actúa como un factor de división por 2. Por lo tanto, aunque el cubo se mueve en la misma dirección, lo hace a una velocidad reducida, resultando en un desplazamiento más lento.
 
 d.- la posición del cubo tiene y>0.

 ![eje3(d)](https://github.com/user-attachments/assets/a06cd23c-7306-4d3f-a3dc-6ba4fb75a324)

Al partir de `y = 2` y usar un movimiento basado en la referencia local, el cubo se desplazará en la misma dirección definida por movimientoDireccion, sin importar su altura inicial. Esto contrasta con un movimiento basado en la referencia mundial, donde la posición inicial tendría un impacto más significativo en la dirección del desplazamiento.
 
 e.- intercambiar movimiento relativo al sistema de referencia local y el mundial.

---

### Ejercicio 4

Mueve el cubo con las teclas de flecha arriba-abajo, izquierda-derecha a la velocidad speed. Cada uno de estos ejes implican desplazamientos en el eje vertical y horizontal respectivamente. Mueve la esfera con las teclas w-s (movimiento vertical) a-d (movimiento horizontal).

![eje4](https://github.com/user-attachments/assets/c0a16a71-902b-4669-b9f9-91c350157029)

Si ambos objetos son Rigidbody cinemáticos, no actuarán las fuerzas físicas sobre ellos y, por lo tanto, no colisionarán correctamente. Para que se produzcan colisiones entre ellos, al menos uno de los objetos debe ser un Rigidbody normal. Ambos objetos pueden ser Rigidbody normales, y deben ser movidos utilizando métodos que integren la física, como Rigidbody.MovePosition() o aplicando fuerzas, en lugar de modificar directamente el transform. Esto permitirá que el motor de física detecte y responda a las colisiones entre los objetos adecuadamente. Aunque en este caso, he decidido que ambos sean RigidBody cinemáticos. 

---

### Ejercicio 5

Adapta el movimiento en el ejercicio 4 para que sea proporcional al tiempo transcurrido durante la generación del frame.

En el ejercicio anterior, ya había ajustado el movimiento para que fuera proporcional al tiempo transcurrido en cada frame, utilizando Time.deltaTime. Esto permite que el movimiento se vea más fluido y constante, sin depender de la tasa de frames. Así, los objetos se mueven a una velocidad uniforme, independientemente de cuántos frames se generen por segundo. Una vez se adquiere el vector de movimiento se modifica el transform del objeto mediante Translate.

![eje5](https://github.com/user-attachments/assets/bd16be5a-e100-49a4-9573-037313d67be5)

---

### Ejercicio 6

Adapta el movimiento en el ejercicio 5 para que el cubo se mueva hacia la posición de la esfera. Debes considerar, que el avance no debe estar influenciado por cuánto de lejos o cerca estén los dos objetos. 

En el gif que describes, el cubo sigue a la esfera sin modificar su altura gracias a que el script calcula continuamente la dirección entre ambos. Se detiene al alcanzar la esfera, ya que el vector de dirección se convierte en cero. Si se modifica el inspector y el cubo no puede encontrar el objeto objetivo, se detiene. Sin embargo, si encuentra otro objeto, como la cápsula de la escena, comenzará a seguirlo.

El Rigidbody cinemático puede atravesar el collider estático de la cápsula porque al moverse con transform.Translate, no se detectan correctamente las colisiones. Para que el cubo choque con la cápsula, debería configurarse como un Rigidbody normal y moverse usando Rigidbody.MovePosition, lo que permitiría que Unity manejese las colisiones adecuadamente. Además, sería necesario colocar el cubo sobre un plano estático para evitar que el cubo cayese por la gravedad.

![eje6](https://github.com/user-attachments/assets/d4a14725-153e-4b44-871f-302baca3118f)

---

### Ejercicio 7

Adapta el movimiento en el ejercicio 6 de forma que el cubo gire hacia la esfera. Realiza pruebas cambiando la posición de la esfera mediante las teclas awsd.

En el gif, el cubo combina su movimiento hacia la esfera con la rotación usando LookAt, adaptándose automáticamente al nuevo objetivo al cambiarlo. Es crucial que el movimiento esté en el espacio del mundo, ya que, de lo contrario, el cubo podría moverse en trayectorias curvilíneas debido a su propia rotación. Al utilizar el espacio del mundo, se garantiza un desplazamiento directo hacia la esfera. En resumen, esta combinación permite un seguimiento fluido y preciso del objetivo.

![eje7](https://github.com/user-attachments/assets/eba4505e-3599-4c98-bd58-ea7f34b3888d)

---

### Ejercicio 8

Utilizar el eje “Horizontal” para girar el objetivo y que avance siempre en la dirección hacia adelante.

En este ejercicio, he separado la funcionalidad en dos scripts distintos para mejorar la organización y claridad del código.

El primer script se encarga de la rotación del cubo, utilizando el método Rotate en combinación con Input.GetAxis("Horizontal"). Esto permite que el cubo gire suavemente alrededor del eje Y en respuesta a las teclas A y D, o las flechas izquierda y derecha.

El segundo script se centra en el movimiento hacia adelante del cubo. Aquí, utilizo transform.Translate(transform.forward * velocidad * Time.deltaTime, Space.World) para mover el cubo continuamente en la dirección en la que está mirando. Esto garantiza que, sin importar su rotación, el cubo se desplace siempre hacia adelante.

El gif resultante muestra cómo ambos scripts interactúan: el cubo gira en función de la entrada del usuario mientras avanza en la dirección en la que está apuntando. Esta separación de lógica en dos scripts facilita el control y ajustes futuros, haciendo el código más modular y flexible.

![eje8](https://github.com/user-attachments/assets/8d6b700f-80ff-4632-8f66-70cd402d936e)

---

### Ejercicio 9

Configura el cilindro como un objeto físico, cuando el cubo o la esfera colisionen con él se debe mostrar un mensaje en consola con la etiqueta del objeto que haya colisionado. 

---

### Ejercicio 10

Configura el cubo como un objeto cinemático y la esfera como un objeto físico. Adapta los scripts del ejercicio 9 para obtener el mismo comportamiento.

---

### Ejercicio 11

Configura el cilindro como un objeto de tipo Trigger. Adapta los scripts de los ejercicios anteriores para obtener el mismo comportamiento.

---

### Ejercicio 12

Agrega un cilindro de un color diferente al que ya hay en la escena y configúralo como un objeto físico. Selecciona un conjunto de teclas que te permitan controlar su movimiento por la escena y prográmale un movimiento que permita dirigirlo hacia la esfera. Prueba diferentes configuraciones de la esfera física con masa 10 veces mayor que el cilindro, física con masa 10 veces menor que el cilindro, cinemática y trigger. También prueba la configuración del cilindro de forma que su fricción se duplique o no. Explica en el informe todos los resultados posibles. 

---

### Nota adicional

Formas de colisiones (Extracción del manual de unity)

![manual_unity_colisiones](https://github.com/user-attachments/assets/3b31c197-7925-406c-b098-bac3df848b59)
