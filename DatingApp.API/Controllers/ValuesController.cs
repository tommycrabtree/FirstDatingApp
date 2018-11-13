using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// 2:6

// I’m using “Attribute Routing” in this application.  The DotNetCLI gives me a
// Controllers folder called ‘Controllers’.  Inside the Controllers folder is a sample
// Controller called ‘ValuesController.cs’, which was also provided by the DotNetCLI.

// At the top of the ValuesController is a Route that specifies api/[controller].  When
// someone is browsing to my application, they’re going to be using ‘http://localhost:5000’
// because the Kestrel Web Server, by default, listens on Port 5000.  In order to use
// this particular Controller, I need to specify ‘api’, which matches the first part
// of the Route.  I also need to specify the first part of the name of the Controller.
// In this case, the Controller is called ‘ValuesController’.  Therefore, I specify
// ‘values’ (even though it’s lower case) as the second part of the Route as follows:
// ‘http://localhost:5000/api/values’.  Now, when I call UseMvc( ), MVC routes the
// request for ‘http://localhost:5000/api/values’ to this particular Controller.

// The methods inside a Controller are known as Actions.  A REST API uses HTTP verbs
// to identify the Action that it’s going to return.  When a request comes in, it’s
// the Framework’s job to get the request to the appropriate Controller.  Once inside
// the Controller, the request needs to match a particular Action.  For example, if
// the URL specified is a GET request for ‘http://localhost:5000/api/values’, it will
// connect with the [HttpGet] method because it matches the Route that has been
// provided.  Naturally, it will then return the values inside of this method, and
// these values will then be displayed in the browser.  However, if the URL specified
// is a GET request for ‘http://localhost:5000/api/values/5’, it will connect with the
// [HttpGet(“{id}”)] method because this request includes an id (in this case, the id
// is 5).  I’ll be building my own Controllers during this course.

// How does the Kestrel Server know to start on Port 5000?  The configuration for
// ‘http://localhost:5000’ is set in the DatingApp.API Profile.  This Profile is
// found in the launchSettings.json file that resides in the Properties folder of the
// Solution Explorer.  When I launch from the Command Prompt, I specify this Profile
// by typing DatingApp.API.  The ‘launchBrowser’ should be set to ‘false’ because
// I don’t want to launch a browser when I start this API.  Therefore, ‘launchUrl’
// doesn’t do anything.  I can specify multiple ports in “applicationUrl”, although
// I only need ‘http://localhost:5000’ at this point.  Also, ASPNETCORE_ENVIRONMENT
// starts as “Development”.  I can change “Development” to “Production” if I want
// to work in Production Mode.


// 2:7

// Checking "Preserve Log" and then refreshing the browser lets me see the Values
// in the Headers, as well as a Preview, when debugging.

// CTRL + ~ opens PowerShell.  ‘dotnet run’ runs the application, launches the Kestrel
// Web Server, and starts the application on Port 5000.  Since I’m in Development, I
// see my logging information in a file called appsettings.Development.json.  The items
// in this file tell me that I’ll get additional information put into the log, which I
// can see in PowerShell.  If I use ‘dotnet watch run’, I don’t need to stop and restart
// the Kestrel Web Server every time I make a change to the code because ASP.NET Core
// will now watch my files for any changes.  As soon as it sees a change, it will stop
// the Kestrel Web Server and automatically restart it so that when I refresh the page
// in the browser, the change is reflected in the code.  AutoSave is handy here.


// 2:10

// Now I have some values in my database that I can extract.  I’ll connect my Controller
// to my DataContext class in order to retrieve these values from the database and
// return them to the Client.  When I’m testing my API, the Client is Postman.  In order
// to retrieve the values from the database, I first need to inject DataContext into the
// ValuesController class.  I create a Constructor named ValuesController at the top of
// the ValuesController class, and I inject DataContext by typing it into the parameters
// of the ValuesController Constructor.  Adding a ‘using’ statement for DataContext
// gives me access to DataContext within my ValuesController, and I give this instance
// of DataContext the name: ‘context’.  I then press CTRL + . on ‘context’ and select
// ‘Initialize Field from Parameter’ to create a private, read-only field that I can now
// use within the class.  As a good naming convention, I put a _ in front of the
// ‘context’, which allows me to replace the ‘this’ keyword with _ in the Constructor.

// At the moment, ‘// GET api/values’ returns an ActionResult of an IEnumerable of type
// ‘string’.  By replacing the ActionResult<IEnumerable<string>> with an IActionResult,
// I can now return HTTP responses to the Client.  Instead of returning strings, for
// example, I can now return an ‘Ok’, which returns an HTTP 200 response.  I rename the
// Get( ) to GetValues( ).  Now I’m ready to go out to the database and get the values,
// so I’ll start with a variable var called ‘values’ to store my values.  I’ll assign
// var values = _context, and when I put a . after _context, I get access to all the
// Entity Framework methods, and it also gives me access to my DbSet, which in this
// case is ‘Values’.  I want to get my values as a list, and in order to execute this
// query, I need to use the .ToList( ).  This statement will now go out to my database,
// retrieve the values, and put the values into a list that will be stored in my var
// ‘values’.  Next, I type a second line of code that says: return Ok(values);.  Now,
// when a request comes in to api/values, it will go to this IActionResult method.
// The IActionResult method then goes out to the database, gets the values, puts them
// in a list, and stores them in the ‘values’ variable, which I then return to the
// Client with an HTTP 200 Ok response.

// If I want to select a specific value, I can do something similar
// with ‘// GET api/values/5’.  This time, the name of my IActionResult is ‘GetValue( )’.
// Since I want a specific value, I’ll pass the desired value in as a parameter.  I get
// the parameter from the root values.  In this example, the root parameter is
// [HttpGet(“{id}”)], so I can simply pass ‘int id’ into my GetValue( ).  The code is
// var values = _context.Values.FirstOrDefault( ).  I use .FirstOrDefault( ) in case the
// value (in this case, the ‘id’) that is passed in doesn’t exist.  Basically, I’m
// saying to Entity Framework: “Return the first or default value.”  FirstOrDefault( )
// requires a Lambda expression.
// Here’s my lambda expression: FirstOrDefault(x => x.id == id).  Basically , this
// says: return ‘x’ where the value (in this case, the id) equals the value I’m passing
// in.  Once this code is run, the var ‘value’ will be assigned the value that was
// returned.  Now, var ‘value’ has the same value as the value (in this case, the int
// id) that we passed into IActionResult GetValue(int id).  Now I return ‘Ok’ and the
// value as my HTTP 200 response.

// Instead of using the browser to test my IActionResult methods, I use Postman.  Then
// I restart my application with a dotnet watch run.  In Postman, I can choose from the
// list of HTTP verbs.  In this example, I’ll choose GET.  After I type the URL into
// Postman and press ‘Send’, Postman goes to my API and returns the list of values from
// the database.  For example, I can type http://localhost:5000/api/values into Postman
// and it will return all the values in my API, and Postman also shows the 200 OK
// response, which is what I specified.  If I type http://localhost:5000/api/values/2
// into Postman, it will only return the value whose Id is ‘2’, along with the 200 OK
// response.  If I pass in an id that doesn’t exist in my database, then var value will
// be assigned the value of ‘null’, and Postman returns a blank screen with a 204 No
// Content, which is still an OK response.


// 2:11

// Synchronous code: when a request comes in, for example to my GetValues( ), this
// Thread would be blocked until the call has been made to the database and the
// database has returned the values into ‘var values’.  It wouldn’t be able to handle
// any other requests while that’s happening.  I could publish a very simple
// application like this one as it is because Web Servers are generally multi-threaded
// and therefore tend to be able to handle multiple concurrent requests.

// Asynchronous code is preferred when creating scalable applications.  With
// Asynchronous code, the thread is not blocked; it’s kept open to handle other
// requests.  Asynchronous code passes the action of going out to get the data from the
// database to a Delegate.  When the result is returned, it continues on with the request.
// It doesn’t block any of the other requests in that thread while it’s waiting for the
// results to come back.  It’s good practice to use Asynchronous code as much as possible
// because the performance hit is very little.

// To convert my IActionResult methods into Asynchronous methods, I type the word ‘async’
// in front of the word ‘IActionResult’ in order to tell the method that it’s going to
// now be an async method.  Then I convert the IActionResult into a Task by typing
// Task<IActionResult>, which basically means I’m now returning a Task of IActionResult
// instead of simply returning an IActionResult.  A Task represents an Asynchronous
// operation that can return a value.  Now, it will keep the Thread open and not block
// any other requests while I’m waiting for the response to GetValues( ).  I’ll tell
// the methods inside the Task (i.e. the method that’s going out to the database; in
// this example, it’s my call to ‘context’) to wait for the response by adding the
// ‘await’ keyword.  I also need to use the Asynchronous version of ToList( ), which is
// ‘ToListAsync( )’, which might require a ‘using’ statement.  This method is now an
// Asynchronous method.  The Asynchronous version of ‘FirstOrDefault’ is
// ‘FirstOrDefaultAsync’.  Now, I’ll go to Postman to make sure this is working.

// At this point in my Walking Skeleton, I now have values in my database that I’m
// retrieving from my database via my API.

// The next step is adding an Angular application so that I can get the values from my
// database all the way to the end-Client’s browser.

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        // GET api/values
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();

            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
