﻿using System;
using System.Data.Entity;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using WingtipToys.Models;

namespace WingtipToys
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize the product database.
            Database.SetInitializer(new ProductDatabaseInitializer());
        }
    }
}