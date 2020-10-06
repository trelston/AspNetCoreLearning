# The Webapi Service Setup

This is a simple asp.net core webapi created from the default template with no authentication

To this we add the Swashbuckle.AspNetCore nuget package.

Add the following code in the Startup.cs to setup Swagger for the api app.

In the ConfigureServices method, add the following:-
```c#
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi Catalog", Version = "v1" });
});
```
In the Configure method, add the following just before `app.UseRouting();` :-
```c#
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi Catalog");

});
```
Build the solution and run it.

if you go to the endpoint _https://localhost:5001/swagger/v1/swagger.json_, you should see the details of
the endpoints the webapi exposes

_https://localhost:5001/swagger_ gives a nice looking UI
