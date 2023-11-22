# Proyecto CRUD de Candidatos con Experiencia Laboral

Este proyecto es un CRUD sencillo desarrollado en .NET Core utilizando los principios de arquitectura DDD (Domain-Driven Design), CQRS (Command Query Responsibility Segregation) y Mediator Pattern. La aplicación gestiona la información de candidatos, incluyendo detalles sobre su experiencia laboral.

## Tecnologías Utilizadas

- **.NET Core:** Plataforma de desarrollo de código abierto y multiplataforma para construir aplicaciones modernas y basadas en la nube.

- **MediatR:** Implementación del patrón Mediator que simplifica la comunicación entre componentes de la aplicación.

- **CQRS (Command Query Responsibility Segregation):** Patrón arquitectónico que separa las operaciones de escritura (comandos) y lectura (consultas) en una aplicación.

- **FluentValidation:** Biblioteca de validación para .NET que utiliza un enfoque fluente para definir reglas de validación.

- **SQL Server:** Sistema de gestión de bases de datos relacional utilizado para almacenar la información de los candidatos y su experiencia laboral.

- **Redis:** Sistema de almacenamiento en caché en memoria utilizado para mejorar el rendimiento de la aplicación.

## Estructura del Proyecto

La estructura del proyecto sigue los principios de DDD, dividiéndolo en capas según las responsabilidades y funcionalidades:

- **Candidatos.API:** Proyecto de la interfaz de usuario y la capa de presentación.

- **Candidatos.Application:** Lógica de aplicación que implementa los casos de uso de la aplicación.

- **Candidatos.Domain:** Definición de entidades, agregados y eventos del dominio.

- **Candidatos.Infrastructure:** Implementaciones concretas de las interfaces de infraestructura, como el acceso a base de datos y la gestión de eventos.
