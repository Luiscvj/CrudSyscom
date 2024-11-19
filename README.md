Library Management System
Este proyecto es una aplicación .NET 8 con Entity Framework Core 9 que implementa un sistema de gestión de bibliotecas. El objetivo es demostrar un diseño limpio y buenas prácticas en el desarrollo de software basado en arquitectura en capas.

Requisitos Previos
Antes de ejecutar este proyecto, asegúrate de contar con lo siguiente:

Visual Studio 2022 (o superior) con soporte para .NET 8.
SQL Server (local o remoto).
El archivo de la solución enviado por correo.
Configuración y Ejecución
Descarga el archivo enviado por correo y descomprímelo en tu equipo.
Abre la solución en Visual Studio.
En el administrador de paquetes de NuGet, ejecuta el siguiente comando para aplicar las migraciones y poblar la base de datos con datos iniciales:
bash
Copiar código
Update-Database
Ejecuta el proyecto para probar los endpoints expuestos en la API desde el frontend provisto.
Arquitectura del Proyecto
El proyecto está dividido en cuatro capas principales para garantizar la separación de responsabilidades y facilitar la mantenibilidad:

1. Domain
Esta capa contiene las entidades del dominio que representan los datos como objetos. Gracias a Entity Framework Core, estas entidades se utilizan para interactuar con la base de datos de manera transparente.

Ejemplo de una entidad:


 public class Book
 {
     [Key]//Uso de DataAnotations
     public int BookId { get; set; }
     public string BookTitle { get; set; }
     public DateTime PublicationDate { get; set; }
     public ICollection<Genre>? Genres { get; set; } = new List<Genre>();
     public ICollection<Author> Authors { get; set; } = new List<Author>();


 }
2. Persistence
Esta capa es responsable de gestionar la conexión con la base de datos. Incluye la configuración de Entity Framework Core y el contexto de datos, LibraryCrudContext, que permite manipular los datos directamente desde el código.

Ejemplo de la configuración de LibraryCrudContext:


public class LibraryCrudContext : DbContextEsta clase es la que me permite  comunicarme con mi motor de base de datos y manipular los datos
{
    public LibraryCrudContext(DbContextOptions options) : base(options)
    {  }  
    
    
    
   

    
3. Application
En esta capa se implementan los patrones Repositorio y Unidad de Trabajo, los cuales son fundamentales para la manipulación de datos:

Repositorio: Proporciona una abstracción sobre las operaciones de acceso a datos, facilitando la prueba y el mantenimiento.
Unidad de Trabajo (Unit of Work): Coordina las transacciones para garantizar que todas las operaciones se completen de manera consistente.
¿Por qué usar estos patrones?

Fomentan un diseño desacoplado.
Simplifican la administración de transacciones y operaciones complejas.
Facilitan el cambio de implementación del repositorio si es necesario (por ejemplo, cambiar de EF Core a otro ORM).
4. API
Esta capa implementa la configuración general de la aplicación, incluyendo:

Configuración de CORS: Para permitir el acceso desde el frontend.
Inyección de dependencias: Se registran los servicios necesarios para el funcionamiento del sistema.
Controladores: Exponen los endpoints que interactúan con la aplicación.
Ejemplo de configuración en Program.cs:



builder.Services.AddDbContext<LibraryCrudContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

Endpoints
Todos los endpoints están documentados y son accesibles a través del frontend. Puedes probarlos fácilmente desde la interfaz proporcionada.


**Nota importante**: Al ejecutarlo verificar que se ejecuta con http para no generar errores



Tecnologías Utilizadas
.NET 8
Entity Framework Core 9
SQL Server
Visual Studio 2022
