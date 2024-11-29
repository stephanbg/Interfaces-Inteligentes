# Práctica: Micrófono y cámara

## Objetivo

El objetivo de esta práctica es el uso de componentes de entrada con Unity3D. Los componentes que vamos a ver en esta práctica son la cámara y el micrófono del ordenador o teléfono móvil.

---

## Ejercicios

### Micrófono

1.- Utilizar la escena de las arañas y activar la reproducción de alguno de los sonidos incluidos en la carpeta adjunta cuando una araña alcanza algún objetivo. Para reproducir sonido en una aplicación Unity es necesario utilizar un objeto AudioSource. El objeto AudioSource reproduce el sonido que contiene un AudioClip, que podemos instanciar arrastrando desde el editor el asset con el clip de audio que esté importado en la escena.

https://github.com/user-attachments/assets/140aa7ab-d369-4ac4-92a2-385182ff966f

2.- Del mismo modo que podemos reproducir un sonido previamente grabado, podemos hacer que se reproduzca el AudioClip que genera el micrófono utilizando la función Microphone.Start. Crea una escena en la que estés en un espacio abierto en el que habrá una pantalla central con altavoces que al pulsar la tecla R reproduzcan el sonido que se obtenga por el micrófono del dispositivo.

https://github.com/user-attachments/assets/c6fc0dcc-9e0d-4747-852d-33c0054e7695

---

### Cámara

3.- En este caso, debes utilizar lo que capta la cámara para reproducirlo en una pantalla ubicada en la escena anterior. Para ver las imágenes grabadas debe asociarse el objeto WebCamTexture al atributo mainTexture de un material y seguidamente llamar a la función Play() de dicho objeto. Por tanto, a través del objeto Renderer del elemento que uses como pantalla accedes a la propiedad material y a su mainTexture asignarle lo que se capta por la cámara. Para pausar la reproducción basta llamar a la función Pause() y, para detenerla, a la función Stop().

https://github.com/user-attachments/assets/744fb3bc-0627-46f9-b789-92034fd2c9f9

4.- Se debe mostrar el nombre de la cámara en la consola.

![WebCam](https://github.com/user-attachments/assets/f82a0f1f-3977-439f-9995-5971d45fb7ac)

5.- Debe ser posible capturar fotogramas aislados y conservarlos en memoria como imágenes fijas. Se debe crear un objeto para la textura, Texture2D y pasarle la imagen-frame de la cámara como un bloque de píxeles y finalmente almacenar en un fichero dicha textura.

https://github.com/user-attachments/assets/2d06ca50-c7e2-437a-9ed8-ecf23920abda
