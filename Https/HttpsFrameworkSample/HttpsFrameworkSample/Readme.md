#Requiring Https and HSTS(Strict-Transport-Security header) in aspnet web application

1. Create an aspnet web application from the template.

2. To configure Https, add the following filter attribute to the RegisterGlobalFilters method of the FilterConfig.cs file:-
    ```c#
         filters.Add(new RequireHttpsAttribute());
    ```

3. Make sure it is the first filter.   

4. To configure HSTS, first add the HSTSAttribute.cs file to the application, preferably under the Filters folder
      
 6. Add the filter attribute to the RegisterGlobalFilters method of the FilterConfig.cs file:- 
     ```c#
          filters.Add(new Filters.HSTSAttribute(
                          System.TimeSpan.FromMinutes(5), true, false));
     ```
 
 7. Make sure it is the first filter.
 
 8. Source:- _https://app.pluralsight.com/library/courses/https-aspnet-and-aspnet-core/table-of-contents_