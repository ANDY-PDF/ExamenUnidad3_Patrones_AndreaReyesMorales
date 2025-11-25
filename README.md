# ExamenUnidad3_Patrones_AndreaReyesMorales
**Examen Unidad 3 - Patrones de Diseño**                       
**Nombre de proyecto asignado: App de lectura con marcadores inteligentes - Andrea Reyes Morales - 21212358** 

Este proyecto es una aplicación de lectura interactiva que permite al usuario personalizar textos de manera dinámica. La aplicación carga un documento de ejemplo ("El Principito") y ofrece un menú con diversas opciones: cambiar el tamaño y color de la fuente, resaltar líneas con colores de fondo, añadir comentarios con fecha y hora, crear marcadores para secciones importantes, y ver estadísticas de uso de memoria. Todo esto se realiza seleccionando el número de línea que se desea modificar y aplicando los cambios deseados, que se reflejan inmediatamente en pantalla.

El proyecto implementa tres patrones de diseño que trabajan en conjunto. El patrón Singleton garantiza que solo exista una instancia de la fábrica de formatos en toda la aplicación, evitando duplicación de recursos. El patrón Peso Ligero optimiza la memoria reutilizando objetos de formato idénticos; si 100 líneas tienen el mismo formato, solo se guarda un objeto en memoria en lugar de 100. El patrón Decorador permite añadir funcionalidades como resaltado, comentarios y marcadores sin modificar el código original, y estos decoradores se pueden combinar en una misma línea.

**Cómo ejecutar el programa Requisitos:**
- Visual Studio 2022 o superior
- .NET 6.0 o superior

**Desde Visual Studio:**
- Abre el proyecto en Visual Studio
- Insertar codigo y ejecutar
