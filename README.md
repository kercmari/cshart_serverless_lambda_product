###  MiProyecto API

API desarrollada en .NET 8 para gestionar productos. Esta API permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre productos y est� dise�ada para ejecutarse localmente o como un servicio serverless en AWS utilizando API Gateway y Lambda.

Tabla de Contenidos

- Requisitos Previos
- C�mo Inicializar Localmente
- Despliegue en AWS Serverless
- Documentaci�n de Endpoints


#### Requisitos Previos

1. NET SDK 8.0 instalado.
2. Docker (opcional para pruebas locales en contenedor).


C�mo Inicializar Localmente

##### Opci�n 1: Ejecuci�n Directa

1. Clona el repositorio:

    ```
    git clone https://github.com/tu-usuario/mi-proyecto.git cd mi-proyecto
    ```

2. Restaura las dependencias y compila el proyecto:

    ```
    dotnet restore dotnet build
    ```
3. Ejecuta la API:

    ```
    dotnet run --project MiProyecto
    ```


##### Opci�n 2: Usar Docker

1. Construye y ejecuta el contenedor con Docker:

    ```
    docker-compose up --build
    ```

La API estar� disponible en:

- Base URL: `http://localhost:5227`
- Documentaci�n Swagger: `http://localhost:5227/swagger`

#### Endpoints

Base URL

- Local: `http://localhost:5227/api/Product`
- Despliegue en AWS: `https://jiea20ag80.execute-api.us-east-1.amazonaws.com/api/Product`

Endpoints

1. Obtener Producto por ID
    - Descripci�n: Devuelve un producto espec�fico por su ID.
    - M�todo: GET
    - URL: /api/Product/{id}
    - Respuesta Exitosa (200):
        ```json
        { "id": 1, "name": "Producto 1", "description": "Descripci�n del producto", "price": 19.99, "stock": 50 }
        ```
    -  Respuesta No Encontrada (404):
        ```json
        { "message": "Producto no encontrado." }
        ```
2. Obtener Todos los Productos

    - Descripci�n: Devuelve una lista de todos los productos.
    - M�todo: GET
    - URL: /api/Product
    - Respuesta Exitosa (200)
        ```json 
        [ { "id": 1, "name": "Producto 1", "description": "Descripci�n del producto", "price": 19.99, "stock": 50 }, { "id": 2, "name": "Producto 2", "description": "Otro producto", "price": 29.99, "stock": 30 } ]

3. Crear un Producto

    - Descripci�n: Crea un nuevo producto.
    - M�todo: POST
    - URL: /api/Product
    - Cuerpo de la Solicitud:
        ```json
        { "name": "Producto Nuevo", "description": "Descripci�n del producto", "price": 19.99, "stock": 100 }
        ```

    - Respuesta Exitosa (201):
        ```json
        { "id": 3, "name": "Producto Nuevo", "description": "Descripci�n del producto", "price": 19.99, "stock": 100 }
        ```


4. Actualizar un Producto

    - Descripci�n: Actualiza la informaci�n de un producto existente.
    - M�todo: PUT
    - URL: /api/Product/{id}
    - Cuerpo de la Solicitud:
        ```json
        { "name": "Producto Actualizado", "description": "Descripci�n actualizada", "price": 29.99, "stock": 50 }
        ```

    - Respuesta Exitosa (200):
        ```json
        { "message": "Producto actualizado exitosamente.", "existingProduct": { "id": 1, "name": "Producto Actualizado", "description": "Descripci�n actualizada", "price": 29.99, "stock": 50 } }
    ```

5. Eliminar un Producto
    - Descripci�n: Elimina un producto por su ID.
    - M�todo: DELETE
    - URL: /api/Product/{id}
    - Respuesta Exitosa (200):

        ```json 
        { "message": "Producto eliminado exitosamente.", "product": { "id": 1, "name": "Producto Eliminado" } }
        ```



#### Despliegue en AWS Serverless

La API se encuentra desplegada como un servicio serverless en AWS Lambda utilizando API Gateway. Puedes acceder a la API y su documentaci�n interactiva Swagger en:

- Base URL: `https://jiea20ag80.execute-api.us-east-1.amazonaws.com`
- Swagger: `https://jiea20ag80.execute-api.us-east-1.amazonaws.com/swagger/index.html`

Infraestructura Utilizada

- API Gateway: Maneja las solicitudes HTTP y redirige a AWS Lambda.
- AWS Lambda: Ejecuta la l�gica de la API en .NET 8.
-almacenamiento adicional, puede integrarse f�cilmente.
![alt text](image-1.png)

> [!NOTE]  
> Hay un archivo collections.json para importar en postman y hacer pruebas del servicio despelgado

![alt text](image-1.png)
