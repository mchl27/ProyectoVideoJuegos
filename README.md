# ProyectoVideoJuegos - Sophos Solution / Politecnico Internacional

Este es un servicio web desarrollado con C#, ASP.NET y SQL Server para una tienda de videojuegos en línea. La aplicación permite a los usuarios buscar, comprar y descargar juegos de una amplia variedad de plataformas.

## Características

- Registro y autenticación de usuarios
- Búsqueda de juegos por título, género, protagonistas, productor, etc.
- Catálogo de juegos
- Gestion para alquilar
- Administración de usuarios, juegos, clientes, precios y Alquileres desde una interfaz

## Tecnologías utilizadas

- C#
- ASP.NET
- SQL Server

## Cómo empezar

1. Clona este repositorio.
2. Abre la solución en Visual Studio.
3. Ejecuta el proyecto desde Visual Studio o publica la aplicación en un servidor web.
4. Crea la base de datos en SQLSERVER correr el scrip DDL luego el DML que podra encontrar en el siguiente drive: https://drive.google.com/drive/folders/1hnMfDF02WsrieqDRB6YAhMJ37V8cb6wm?usp=sharing.
5. En visual studio instalar paquetes nuget SQLSERVER / TOOLS.
6. Ejecutar Scaffold para conexion con la base de datos y  agregar los modelos de las tablas creadas en SqlServer: Scaffold-DbContext "server="NOMBRE_SERVIDOR"; database="NOMBRE_BASE_DE_DATOS"; integrated security=true;" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models.


## Contribución

Si deseas contribuir a este proyecto, por favor crea un fork y envía un pull request con tus cambios. Nos encantaría recibir tus sugerencias y mejoras.

## Licencia

Este proyecto está bajo la licencia MIT. Consulta el archivo LICENSE para más detalles.

## Contacto

Si tienes alguna pregunta o comentario sobre este proyecto, por favor contáctanos en nuestra dirección de correo electrónico: michaellopez201383@gmail.com / michael.lopez@pi.edu.co
