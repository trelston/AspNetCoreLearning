# Generate client POCO/Service using NSwag command line

1. Download NSwag.exe from https://github.com/RicoSuter/NSwag/wiki/CommandLine

2. Add Newtonsoft.json to the webapp

3. Execute the command 
    ```
    nswag openapi2csclient /input:https://localhost:5001/swagger/v1/swagger.json 
                           /classname:SampleWebApiServiceClient 
                           /namespace:SampleWebApplication.Models 
                           /output:SampleWebApiServiceClient.cs
   ```
   
 4. This should generate the service class file from the webapi swagger json file
 
 5. You can then call the functions in the webapi using this class as follows;-
    ```c#
         var request = new SampleWebApiServiceClient("https://localhost:5001/", new HttpClient());
         var response = await request.OrderDetailsAsync(1234);
    ```
    
 6. The first parameter is the base Url