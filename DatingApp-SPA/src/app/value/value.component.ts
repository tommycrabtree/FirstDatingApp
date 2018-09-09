// 2:15

// Configure the Angular application so that it can make HTTP requests.  The HTTP
// requests will fetch data from the API.

// Now I’m going to go and get the values from my API and display them on my browser.
// To do this, I’ll create a new Component in the app folder of my src folder by right-
// clicking the app folder and selecting ‘Generate Component’ to generate an Angular
// Component.  By convention, Angular Components start with a lower case letter, so I'll
// give it a name of ‘value’, which creates my value Component (and its four files).

// I open value.component.ts to start, and I see that it’s importing ‘Component’ and
// ‘OnInit’.  My ‘@Component’ has automatically given me a ‘selector’ of ‘app-value’,
// as well as ‘template’ files (‘templateUrl’) and my component.css.  Whenever I add a
// Component, I also need to add it to my app.module.ts.  Looking in the app.module.ts,
// I see that my Component (ValueComponent – yes, it now has a capital ‘V’) has already
// been declared in the ‘declarations’ of ‘@NgModule’ (this is where Components are
// declared inside my Module).  My ValueComponent has also been imported (this is also
// required) at the top of app.module.ts with the other imports.

// I also need to import the HttpClientModule from Angular.  Looking at the Dependencies
// in the package.json file, I see that one of the Dependencies is the deprecated
// “@angular/http”.  Instead, the Http Service that I want to use is called ‘HttpClient’
// and is found in the “@angular/common” package.  In order to go and get the values
// from my API, my ValueComponent needs the Http Service that the “@angular/common”
// provides.  I import the “@angular/common” package into my app.module.ts because I
// want to be able to use the “@angular/common” package inside my ValueComponent.  I
// type ‘HttpClientModule’ to add ‘HttpClient’ (and its Module) in the ‘imports’ area of
// my app.module.ts.  Although VS Code has its own automatic importer, it doesn’t index
// the node_modules folder (which contains ‘angular/common/http’) because the
// node_modules folder has literally thousands of files.  So, I need to manually import
// the Module by typing ‘import { HttpClientModule } from ‘@angular/common/http’;’ at
// the top of app.module.ts.

// Now that I’ve imported the HttpClientModule, my ValueComponent can use its Services.
// One of the Services it provides is HttpClient.  HttpClient allows me to make an Http
// GET Request in order to retrieve my values from the Server.

// Now I go to my value.component.ts.  First, I declare a Property inside my
// ValueComponent class.  I give the Property a name of ‘values’ and I’ll give it a type
// of ‘any’ (this JavaScript-esque “catch-all” type is just for Walking Skeleton testing
// purposes) by typing ‘values: any’.

// Just like in a C# / .NET project, I can inject Services into the Constructors of my
// Angular classes.  I inject my newly imported Http Client Service into the Constructor
// of value.component.ts so that I can make use of this Service inside my class.  The
// code is: ‘constructor(private http:HttpClient).  There are two options for HttpClient;
// I want ‘@angular/common/http’.  Angular automatically provides the ‘import’ statement
// at the top of the file: ‘import { HttpClient } from ‘@angular/common/http’;.

// Next, under the ngOnInit( ), I create another method called getValues( ).  Referencing
// the Http Service, I type: ‘this.http.’ and then I choose from the options that are
// provided with this Service.  I’ll choose .get because I want to make an Http GET
// Request in order to go out to my API.  Here’s the code: ‘this.http.get( ).  This first
// parameter of the get( ) is the URL (just as it was in Postman).  Now my code looks
// like this: ‘this.http.get(‘http://localhost:5000/api/values’)’.

// What will I get back from the Server when I use this method?  If I hover over the
// get( ), I see that the ‘url’ is a required parameter.  Anything with a ‘?’ is an
// optional parameter.  In this case, an object (I can tell it’s an object because it
// has an opening { }) called “options” has different options that I case use.  After
// the object, at the bottom of the information window, I see @return, which describes
// what this method will return.  This method returns an Observable of the body
// as an Object.

// An Observable is a stream of data that is coming back from the Server.  In order to
// get this “observable data”, I need to subscribe to it (since the method on its own
// will not give me the values I want).  Basically, I’ll send the GET request to the
// Server, the response will be returned as an Observable, and the only way I can see
// the Observable is if I’m subscribed to it.  Here’s my code once I start to subscribe:
// ‘this.http.get(‘http://localhost:5000/api/values’).subscribe( )’.  The subscribe( )
// has two overloads and I typically use the second overload.  The first parameter of
// the second overload takes a “callback” (a function to tell me what I want to do when
// these results come back).  The second parameter is what to do in the event of an
// error (which also takes a function).  The third parameter is what to do when the
// “subscription” is complete; in other words: what to do after I’ve received all the data.

// I want to pass the response into my ‘values’ Property.  To do this, my subscribe( )
// now looks like this: ‘subscribe(response => { this.values = response; } ).

// Now I add my “error condition” code as follows: ‘ },  error => { console.log(error); } );.

// Now I have my getValues( ) and I want to call my getValues( ) when my Component loads.
// There are a few different “life cycle events” that happen when an Angular Components
// loads.  The ‘constructor’ is “early” and is considered too early to go and get data
// from an API.  The appropriate method to use is ‘ngOnInit’, which occurs after the
// Component is initialized, and it happens after the “constructor”.  Here’s the code to
// use: ‘ngOnInit( ) { this.getValues( ); }.

// Now, on initialization, the ‘getValues( ) will be called.  It goes off to the API, gets
// the values, and stores the values inside the ‘values’ Property.

// Now I want to add my ValueComponent to my AppComponent, so I switch to app.component.html.


import { Component, OnInit } from '@angular/core';
import { HttpClient } from '../../../node_modules/@angular/common/http';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
  values: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getValues();
  }

  getValues() {
    this.http.get('http://localhost:5000/api/values').subscribe(response => {
      this.values = response;
    }, error => {
      console.log(error);
    });
  }

}
