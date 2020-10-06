# Generate POCO using NSwag command line

1. Download NSwag.exe from https://github.com/RicoSuter/NSwag/wiki/CommandLine

2. Add Newtonsoft.json to the webapp

3. Execute the command 
    ```
    nswag openapi2csclient /input:https://localhost:5001/swagger/v1/swagger.json 
                           /classname:SampleWebApiServiceClient 
                           /namespace:SampleWebApplication.Models 
                           /output:SampleWebApiServiceClient.cs
   ```
   
 4. This should generate the POCO file from the webapi swagger json file