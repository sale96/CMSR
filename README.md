# CMSR

> Web store API project

### Project info

- ##### Packages
     - Microsoft.EntityFrameworkCore
     - AutoMapper
     - SwaggerGen
     - SwaggerUi
- ##### Usefull url's
     - ```/swagger``` Swagger UI for *OpenApi* documentation
- ##### Design patterns
     - ```Generic repository pattern```
     - ```Specification pattern```

### Setup

- In terminal use ``` dotnet restore ``` to restore dependencies in the project.
- Then ``` dotnet build ``` to make sure that everything works as intended and there are no compile time errors.
- Migrations are applied automaticly.
- Copy appsettings.json.example file with ```cp server/API/appsettings.json.example server/API/appsettings.json```.

### Possible changes
- You can change the database you are migrating in by changing ```API/appsettings.json``` file the connection string.

### Future implementations
- Implemening UI, possible with React or Angular
