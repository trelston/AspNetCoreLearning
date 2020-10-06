using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleGrpcService;
using SampleWebApplication.Models;

namespace SampleWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            // var request = new SampleWebApiServiceClient("https://localhost:5001/", new HttpClient());
            // var response = await request.OrderDetailsAsync(1234);
            
            var channel = GrpcChannel.ForAddress("https://localhost:5001");  
            Greeter.GreeterClient greeterClient = new Greeter.GreeterClient(channel);  
            HelloReply helloReply = greeterClient.SayHello(new HelloRequest(){Name = "Trelston"});  
            Console.WriteLine("Given Name is " + helloReply.Message); 
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}