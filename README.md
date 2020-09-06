
## Introducción
Este código contiene las Api de:
1. Agregar cuenta
2. Consultar Cuenta
3. Consignar Cuenta
4. Retirar Cuenta

Al ejecutar el programa crea automáticamente una pesona para poder posteriormente agregarle cuentas


### a. Instrucciones de cómo ejecutar la aplicación en un ambiente local
#### Backend
1. Descargar el código del programa 
2. En el archivo appsettings.json (ruta Prueba5/appsettings.json) actualizar los datos de conexión
3. Ejecutar el programa, se abrira una ventana en el navegador , reescribir la url("http://localhost:52438/index.html")
4. verificar la creación de la base de datos en el servidor editado en el paso #2
5. Verificar las funcionalidades de la API

#### FrontEnd
1. Descargar el código del programa
2. Instalar los módulos para que se permita la ejecucion del programa `npm install`
3. Ejecutar la aplicación mediante el comando `ng serve -o`, se abrira una ventana en el navegador 

### b. Supuestos de negocio y tecnología que realizó para solucionar el problema
#### Supuestos
* Se tienen usuarios ya creados para poder realizar los movimientos de cuenta
* Para crear una cuenta es necesario un número que identifique la persona y no el nombre 
#### Tecnología
* El Backend se realizo mediante .Net Core 3.1
* El FrontEnd se realizo mediante Angular 9

### c. Explicación de la arquitectura que planteo para solucionar el problema.
* La solucion se realizó mediante un modelo de capas:
######  Modelo
Contiene las clases necesarias para el funcionamiento del API
######  BancoDal
* Contiene las clases que tienen el contacto con la base de datos 
* Contiene la carpeta `configuración` de las tablas de usuario y persona que permite que se cree la migración y al ejecutar el programa se generará la base de datos
* Contiene La carpeta `DatosIniciales`que crea un usuario para que se permita la administración de cuentas sin editar la base de datos
* Contiene la carpeta `Interfaces` de las clases que tienen el contacto con la base de datos
* Contiene la carpeta `Migrations` la cual contiene los datos necesarios para que se cree la base de datos cuando se ejecuta el programa
* Contiene la clase `BancoContext` que permite la conexion del programa con la base de datos
######  BancoBll
* Contiene las clases que comunican al API con las clases que interactuan con la base de datos
* Contiene la carpeta `Interfaces` de las clases que comunican al API con las clases que interactuan con la base de datos

### d. Explicación de las tecnologías seleccionadas para resolver el problema.
* El Backend se realizo mediante .Net Core 3.1
* El FrontEnd se realizo mediante Angular 9

### e. Qué haría mejor o como podría atacar mejor el problema si tuviera más tiempo.
* Ajustar el estilo del formulario
* Agregar autenticación mediante token de verificacion
* Validaciones en el código fuente
* Diseño de pruebas unitarias 
* Implementar un mecanismo de auditoría a base de archivos de texto.

## Link video
https://youtu.be/2tqLk9G2Clg

