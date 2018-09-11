﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


// 2:5

// One of the methods in Startup.cs is the ConfigureServices( ), which is where I can
// implement Dependency Injection.  While I’m building this application, I’ll need to make
// certain Libraries and Classes available to other Classes inside my application, and I
// can inject them into other Classes in my application using ConfigureServices( ).

// If I want to use use the .NET Framework for a WebAPI, then I’ll need a Service for MVC.
// The services.AddMvc( ) is already in ConfigureServices( ) when the API is initially
// scaffolded by the DotNetCLI, so I’m all set. Also in the Program.cs class, the
// Configure( ) configures the HTTP Request pipeline.


// 2:6

// UseMvc( ) is effectively middleware.  Middleware is software
// that connects network-based requests generated by a Client to the backend data that the
// Client is requesting.  app.UseMvc( ) sits in between the Client request and the API
// endpoint(s).  As part of its job, app.UseMvc( ) routes the Client’s requests to the
// correct Controller.


// 2:7

// If I the current environment is the Development Environment (Development Mode), the
// application uses app.UseDeveloperExceptionPage( ), which displays a “developer-friendly”
// exception page (with lots of information) in the event of an exception.  If the current
// environment is not the Development Environment, app.UseHsts( ) is called, and I can see
// a good description of any errors in the Command Prompt.  app.UseHsts( ) is a security
// enhancement that is specified by a web application through the use of a special
// Response Header.  Once a browser receives this Response Header, the browser will
// prevent any communications from being sent over HTTP for the specified domain, and
// it will instead send all communications over HTTPS. This is used in conjunction with
// app.UseHttpsRedirection( ).

// The final method, app.UseMvc( ), is a call to use MVC, which is the Framework that I’m
// using for this application.  MVC gives me the ability to route to the different actions
// that I’m going to build.


// 2:8

// Next, I can use my Startup class to tell my application about my new instance of
// DbContext by adding it as a Service because anything that I add as a Service is
// available to be injected into any other part of my application.  Intellisense has
// an option for AddDbContext, and mine will be of type ‘DataContext’, which requires
// a ‘using’ statement.  In order to give DbContext some options, I pass in an expression
// that includes my Connection String.  For now, I’ll just put “ConnectionString” as a
// placeholder until I get my Connection String.  My code looks like this:
// x => x.UseSqlite(“ConnectionString”).  I might need to use the NuGet Package Manager
// to use Sqlite.  I can access the Nuget Package Manager by pressing CTRL + SHIFT + P
// and searching for Nuget.  I select ‘Nuget Package Manager: Add Package’.  Next, I can
// search for the package I want.  I search for Microsoft.EntityFrameworkCore.Sqlite
// and I select it, and then I select the most current version.  If I see a message
// regarding unresolved dependencies related to my DatingApp.API.csproj file, it’s ok
// to click ‘Restore’ to continue.  DatingApp.API.csproj now includes
// Microsoft.EntityFrameworkCore.Sqlite, so now I can add the ‘using’ statement for
// UseSqlite( ) in my Startup class.


// 2:9

// appsettings.json is always used.  If I’m in Development Mode,
// appSettings.Development.json is also used, and since it’s applied after
// appsettings.json is applied, appSettings.Development.json settings will override
// any equivalent settings in appsettings.json when I’m in Development Mode.  This
// means I can add my Connection String to appsettings.json, and it’ll be available
// regardless of whether I’m in Development Mode or Production Mode.  The code is
// “ConnectionStrings”: {“DefaultConnection”: “Data Source=DatingApp.db”},.  It’s
// standard for the Connection String being used to be called “DefaultConnection”.
// The Sqlite connection is set by typing “Data Source=DatingApp.db”.  This code
// creates a file which will be my database that I can use in my application.

// Now I need to tell my application about the Connection String.  In Startup.cs,
// I have a Constructor that injects IConfiguration into the Startup class (by
// passing it into the Startup method and naming its instance “configuration”) so
// that IConfiguration can be used.  IConfiguration represents a set of Key/Value
// application configuration Properties.
// For example, the “Data Source=DatingApp.db” that I’m using in appsettings.json
// is an example of a Key/Value application configuration Properties.  Now, I can
// replace my placeholder “ConnectionString” text in the UseSqlite( ) of my
// Startup.cs with ‘Configuration.GetConnectionString(“DefaultConnection”).
// GetConnectionString is shorthand for GetSection(“ConnectionStrings”)[name],
// which matches what I’ve put in appsettings.json.  Therefore, “ConnectionStrings”
// is the section that I’ll get with this code from appsettings.json. 
// “DefaultConnection” matches what I put in appsettings.json.  I’m now in a position
// to use EF to scaffold and create my database.


// 2:16

// CORS is a security measure that allows my API to restrict which Clients (the Client
// in this example is my Angular application) are allowed to access my API.  CORS
// accomplishes this by using a ‘header’.  First of all, I’m going across to a different
// domain.  I’m trying to access resources in localhost:5000 from localhost:4200.  If,
// for example, I try to access the resources on localhost:5000 from my browser via
// Google.com (or a similar website), everything works (when I inspect the Console, I can
// see that I’m sending a GET request from Google’s host) and I don’t get a CORS error
// message.  Basically, because the resources are from a different origin, localhost:4200
// wants to know if it’s ok to display the resources in the browser.  So even though I
// can inspect localhost:4200’s Network and see that it is able to get the values via the
// GET request (in fact, I can see the values inside the Network’s Preview tab), the
// browser isn’t displaying the results (and it’s giving me an error in its Console)
// until it sees a ‘header’.  The ‘header’ needs to say that, because these results are
// from a different origin, it wants to know that it’s allowed to display the results in
// the browser.

// I could restrict my API to this domain, but at this stage of the course, my main goal
// is to get things working, so I’ll put a fairly loose CORS policy onto my API.  Back
// in the Startup class of my API, I add CORS as a Service in my ConfigureServices( ) to
// make it available in my Http “pipeline”.  Here’s the code: services.AddCors( );.

// Now I can use CORS in my “pipeline” (the Configure( ) of Startup.cs.  The order of
// things is important in the “pipeline”, and I definitely need to implement CORS before
// I use MVC( ), so I’ll add this code before MVC( ): App.UseCors( ).  Now I need to
// supply App.UseCors( ) with some configuration.  I can either give it a Policy Name
// (which I don’t have now), or I can give it an Action by creating an expression.  I’ll
// create an expression that allows these three (3) methods: ‘AllowAnyHeader’,
// ‘AllowAnyMethod’, and ‘AllowAnyOrigin’.  The important one is ‘AllowAnyOrigin’,
// which allows me to get from my Angular application to my API and get the resources.
// Because it’s early in the course, this will be “weak”; I’ll allow any origin, I’ll
// allow any method, and I’ll allow any header.  This will be my CORS Policy.  Now if
// I refresh localhost:4200 and look at the Headers tab of my Network, I can see
// localhost:5000 (in the General section) and I can see a * (which is a ‘wildcard’)
// in the Response Headers for my Access-Control-Allow-Origin, which basically says:
// “Allow any origin to access resources in this API”.


namespace DatingApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseCors(x => x.WithOrigins("http://localhost:4200")
                .AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
