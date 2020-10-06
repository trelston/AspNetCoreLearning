# Swagger Setup

1. Create a simple asp.net core webapi created from the default template with no authentication

2. Add the Swashbuckle.AspNetCore nuget package.

3. In the ConfigureServices method, add the following:-
    ```c#
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi Catalog", Version = "v1" });
    });
    ```
4. In the Configure method, add the following just before `app.UseRouting();` :-
    ```c#
    app.UseSwagger();
    
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi Catalog");
    
    });
    ```
5. Build the solution and run it.

6. if you go to the endpoint _https://localhost:5001/swagger/v1/swagger.json_, you should see the details of
   the endpoints the webapi exposes

7. _https://localhost:5001/swagger_ gives a nice looking UI
