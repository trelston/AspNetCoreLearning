# Requiring HSTS(Strict-Transport-Security header) in aspnet core application

1. Create an aspnet core web application from the template.

2. Add the following line to the Configure method:-
    ```c#
       app.UseHsts();
    ```

3. Make sure it is one of the first middlewares configured   

4. You can also configure the HttpsRedirection in Startup.cs, in the ConfigureServices method:-
    ```c#
       services.AddHsts(x =>
                   {
                       x.Preload = true;
                       x.IncludeSubDomains = true;
                       x.MaxAge = TimeSpan.FromMinutes(5); //default is 30 days
                       x.ExcludedHosts.Clear();
                   });
    ```
      
 6. A brief description of the above properties:-
    a. IncludeSubdomains:- Enables includeSubDomain parameter of the Strict-Transport-Security header
    b. Preload:- Sets the preload parameter of the Strict-Transport-Security header.
                 Preload is not part of the RFC specification, but is supported by web browsers
                 to preload HSTS sites on fresh install. See https://hstspreload.org/.
    c. MaxAge:- Sets the max-age parameter of the Strict-Transport-Security header.
    d. ExcludedHosts:- A list of host names that will not add the HSTS header. 
                       localhost is one of the host names excluded by default.
                       "localhost", "127.0.0.1", "[::1]" are harcoded as excluded.
 
 7. Thats it that is all you need to configure and require HSTS in an asp net core application
 
 8. Source:- _https://app.pluralsight.com/library/courses/https-aspnet-and-aspnet-core/table-of-contents_