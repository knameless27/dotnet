# Gestor Personal de Tareas (.NET 8 Web API + Blazor Server)

Proyectos incluidos:
- TaskApi: API REST en .NET 8 con Entity Framework InMemory, AutoMapper y Swagger.
- TaskFront: Blazor Server que consume la API.

Instrucciones rápidas:
1. Tener .NET 8 SDK instalado.
2. Abrir dos terminales.
3. Backend:
   cd TaskApi
   dotnet run
   la API correrá en http://localhost:5000 por defecto (o mirar salida).
4. Frontend:
   cd TaskFront
   dotnet run
   abrir https://localhost:5001 o http://localhost:5000 según launchSettings.
5. En el Frontend la HttpClient está configurado con la clave 'TaskApi' apuntando a http://localhost:5000/api/ — ajustar si la API corre en otro puerto.

Notas:
- DB en memoria para simplicidad y rapidez de evaluación.
- Dockerfile incluido para la API.
