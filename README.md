# Xplora - Workstation Backend API 

##  Descripción

Backend oficial de la plataforma **TripMatch / Xplora**. Esta API RESTful gestiona la lógica de negocio para conectar agencias de turismo con viajeros, administrando reservas, experiencias turísticas y perfiles de usuario.

El sistema está construido sobre una arquitectura **DDD (Domain-Driven Design)** utilizando patrones **CQRS** (Segregación de Responsabilidad de Consultas y Comandos) y **Mediator**, garantizando un alto desacoplamiento y escalabilidad.

##  Arquitectura y Contextos

El backend se divide en **Bounded Contexts** para modularizar la lógica de negocio:

* **IAM (Identity & Access Management):** Autenticación y autorización (JWT).
* **Profile:** Gestión de perfiles de Agencias y Turistas.
* **DAP (Design & Presentation):** Gestión del catálogo de Experiencias, Categorías y Favoritos.
* **ARM (Asset Resource Management):** Gestión de Reservas (Bookings).
* **Inquiry:** Sistema de consultas entre turistas y agencias.
* **Reviews:** Gestión de reseñas y valoraciones.

##  Stack Tecnológico

* **Framework:** .NET 7 / 8 (Web API)
* **Base de Datos:** MySQL (con Entity Framework Core)
* **Patrones:** Repository, Unit of Work, CQRS.
* **Mediator:** `Cortex.Mediator` para el manejo de comandos y eventos.
* **Validación:** `FluentValidation` para reglas de negocio.
* **Documentación:** Swagger (OpenAPI v3).
* **Seguridad:** JWT Bearer Authentication.

##  Endpoints de la API

La API expone recursos bajo el prefijo `/api/v1` y utiliza `kebab-case` para las rutas.

###  Auth (IAM)
| Método | Endpoint | Descripción |
| :--- | :--- | :--- |
| `POST` | `/api/v1/iam/auth/signup` | Registro de nuevo usuario. |
| `POST` | `/api/v1/iam/auth/signin` | Inicio de sesión y obtención de Token. |

###  Perfiles (Profile)
| Método | Endpoint | Descripción |
| :--- | :--- | :--- |
| `GET` | `/api/v1/profile/user/agency/{userId}` | Obtener perfil de agencia. |
| `PUT` | `/api/v1/profile/user/agency/{userId}` | Actualizar datos de agencia. |

###  Experiencias y Diseño (DAP)
| Método | Endpoint | Descripción |
| :--- | :--- | :--- |
| `GET` | `/api/v1/design/experience` | Listar todas las experiencias. |
| `POST` | `/api/v1/design/experience` | Crear una nueva experiencia. |
| `GET` | `/api/v1/design/experience/{id}` | Detalle de experiencia. |
| `PUT` | `/api/v1/design/experience/{id}` | Actualizar experiencia. |
| `DELETE` | `/api/v1/design/experience/{id}` | Eliminar experiencia. |
| `GET` | `/api/v1/design/category` | Listar categorías disponibles. |
| `POST` | `/api/v1/design/category` | Crear categoría. |
| `POST` | `/api/v1/design/favorite/favorite` | Agregar a favoritos. |

###  Reservas (ARM - Booking)
| Método | Endpoint | Descripción |
| :--- | :--- | :--- |
| `POST` | `/api/v1/assets/booking` | Crear una nueva reserva. |
| `GET` | `/api/v1/assets/booking` | Listar reservas. |
| `GET` | `/api/v1/assets/booking/{bookingId}` | Ver detalle de reserva. |
| `GET` | `/api/v1/assets/booking/tourist/{touristId}` | Ver reservas de un turista. |

###  Consultas (Inquiry)
| Método | Endpoint | Descripción |
| :--- | :--- | :--- |
| `POST` | `/api/v1/inquiry` | Enviar consulta a una agencia. |
| `GET` | `/api/v1/inquiry/experience/{experienceId}` | Consultas por experiencia. |

##  Configuración y Ejecución

### Prerrequisitos
* SDK de .NET 7 o superior.
* MySQL Server en ejecución.

### Pasos
1.  **Clonar el repositorio:**
    ```bash
    git clone [https://github.com/Xplora/workstation-back-end.git](https://github.com/Xplora/workstation-back-end.git)
    ```

2.  **Configurar Variables de Entorno:**
    Modifica el archivo `appsettings.json` con tus credenciales:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=tripmatch_db;Uid=root;Pwd=tu_password;"
    },
    "Jwt": {
      "Key": "Tu_Super_Secreto_Key_Para_Tokens_JWT",
      "Issuer": "TripMatch",
      "Audience": "TripMatchUsers"
    }
    ```

3.  **Base de Datos:**
    El proyecto está configurado para crear la base de datos automáticamente al iniciarse (`EnsureCreated`), pero si usas migraciones:
    ```bash
    dotnet ef database update
    ```

4.  **Ejecutar:**
    ```bash
    dotnet run
    ```
    * Swagger UI estará disponible en: `https://localhost:7XXX/swagger/index.html`

##  Docker

El proyecto incluye un `Dockerfile` para despliegue en contenedores.

```bash
docker build -t tripmatch-backend .
docker run -d -p 8080:80 --name tripmatch-api tripmatch-backend
