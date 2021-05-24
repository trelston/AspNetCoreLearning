# Requiring Https in aspnet core application

1. Create an aspnet core web application from the template

2. By default Https Redirection is enabled.

3. If you check the Configure method in Startup.cs, you will find the following code:-
    ```c#
        app.UseHttpsRedirection();
    ```
4. It is the first in the chain of configured middlewares.

5. You can also configure the HttpsRedirection in Startup.cs, in the ConfigureServices method:-
    ```c#
       services.AddHttpsRedirection(x =>
                   {
                       x.HttpsPort = 443;
                       x.RedirectStatusCode = 123;
                   });
    ```

6. In the above code, we can change the default HttpsPort and the default RedirectStatusCode(307 default)

7. Thats it that is all you need to configure and require Https in an asp net core application

8. Source:- _https://app.pluralsight.com/library/courses/https-aspnet-and-aspnet-core/table-of-contents_