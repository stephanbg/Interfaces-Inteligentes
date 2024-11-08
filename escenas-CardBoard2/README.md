# Escenas Cardboard-2

Con la escena del ejercicio 8 de la práctica anterior crea un proyecto de CardBoard, en el que implementes la mecánica de recolección de algún objeto. La interacción para la recolección se lleva a cabo con la mirada del jugador. Además cuando se llega a una determinada puntuación un tipo de objetos debe dirigirse hacia un punto preestablecido.

## Sistema de Interacción en Realidad Virtual con Cardboard Reticle Pointer

Este sistema implementa un mecanismo de interacción en un entorno de realidad virtual (VR) utilizando el **Cardboard Reticle Pointer** de Google, lo que permite al jugador interactuar con objetos en el entorno mediante la mirada. A continuación, se describe cómo funciona el sistema de interacción:

### 1. Uso del Cardboard Reticle Pointer
El **Cardboard Reticle Pointer** actúa como un puntero o cursor en la escena, permitiendo al usuario interactuar con el entorno simplemente mirando o fijando su atención sobre los objetos. 

- El **reticle pointer** es un círculo o retículo que aparece en el centro de la vista del usuario y se mueve de acuerdo a la dirección de la mirada o del dispositivo (en este caso, utilizando Google Cardboard).
- El sistema detecta cuando el jugador está apuntando a un objeto interactuable y cambia su apariencia visual para indicar que puede ser seleccionado.

### 2. Interacción con Objetos
Los objetos en la escena tienen un **comportamiento visual** que cambia dependiendo de si están siendo seleccionados por el jugador.

- **Textura oscura inicialmente:** Los objetos interactuables empiezan con una textura más oscura o un color apagado, lo que indica que están disponibles para ser seleccionados, pero aún no han sido apuntados o seleccionados por el jugador.
- **Cambio de textura al interactuar:** Cuando el **reticle pointer** apunta hacia un objeto durante un cierto tiempo, la textura de ese objeto se aclara, indicando que ha sido seleccionado. Este cambio de apariencia ayuda a que el jugador sepa que ha interactuado con el objeto.

### 3. Recolectar Calaveras
El jugador tiene el objetivo de **recolectar dos calaveras** en la escena. Para hacerlo:

- El jugador debe apuntar con el **reticle pointer** hacia las calaveras. Cuando el retículo está sobre ellas, la textura de las calaveras se aclara, lo que indica que pueden ser recolectadas.
- Una vez seleccionadas, las calaveras se "recogen", lo que puede activar eventos en el juego, en este caso ambas calaveras aumentan 10 puntos cada una.

### 4. El Monstruo Persigue y Ataca
Una vez que el jugador ha recolectado las calaveras, un **monstruo** comienza a perseguirlo y atacarlo. Este comportamiento se maneja de la siguiente manera:

- **Desencadenar la persecución:** Cuando el jugador recoge las calaveras, el sistema activa al monstruo, quien comienza a moverse hacia la posición del jugador.
- **Ataques del monstruo:** Si el monstruo alcanza al jugador, este **ataca**.
  
Esto se puede observar en el siguiente gif:

![escenas-cardboard-2](https://github.com/user-attachments/assets/6e09db29-a58a-4ee1-912c-7108ee1bc2ef)

