# Setup Grpc Service and Client

1. Create a Sample Grpc Service using the template

2. In the web application, copy the Protos folder from the grpc service to the Protos folder of the web app

3. Add the nuget package Grpc.AspNetCore to the web application

4. Add the following file to the csproj file of the web application:-
    ```xml
       <ItemGroup>
           <Protobuf Include="Protos\greet.proto" GrpcServices="Client" />
       </ItemGroup>
    ```
   
5. Make sure the GrpcServices value is set to Client.

6. The service should now be accessible to client. Use the following code to test:-
    ```c#
        var channel = GrpcChannel.ForAddress("https://localhost:5001");  
        Greeter.GreeterClient greeterClient = new Greeter.GreeterClient(channel);  
        HelloReply helloReply = greeterClient.SayHello(new HelloRequest(){Name = "Trelston"});  
        Console.WriteLine("Given Name is " + helloReply.Message); 
    ```