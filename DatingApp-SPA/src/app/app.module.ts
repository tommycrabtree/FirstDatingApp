// 2:12

// To use Angular, it needs to be globally installed.  Node.js, which comes with npm,
// also needs to be installed.  Once Node.js is installed, we have access to the Node
// Package Manager (npm) and we can globally install the Angular CLI by typing ‘npm
// install -g @angular/cli’.  It’s important to make sure I’m in the right directory
// on my Command Prompt when creating my Angular SPA by typing ‘ng new DatingApp-SPA’.
//  For example, I made the Angular-SPA for the DatingApp a sibling of DatingApp.API.


// 2:13

// I get a lot of files ‘out of the box’ for my SPA when I create a new Angular app
// with ng new. The e2e folder is for to testing, which is not covered in this course.

// When I created my Angular application, the Angular CLI went and downloaded a whole
// bunch of different packages that are required as part of the Framework.  These
// packages are in the node_modules folder.

// package.json identifies all of the packages that, when downloaded, go inside the
// node_modules folder.  It includes all of the Angular dependencies that I have.
// Also in package.json are my npm scripts, which are called “scripts”.  These allow
// me to run commands (in this case, ng commands) inside npm.  For example, in order
// to start my application, I can either run ‘npm start’ or ‘ng serve’.

// The src folder is where the code I’ll be writing will live.  Inside the src folder
// is the app folder, which is where any Components that I write in this course will
// all live in the app folder.  Every Angular application must have at least one (1)
// app.module.ts file, which is Decorated with @NgModule.

// There’s Bootstrap information inside @NgModule.  When this Module is loaded, it
// will “Bootstrap” my AppComponent, which is the app.component.ts file.

// In summary, the app.module.ts loads the AppComponent.  The AppComponent has an
// HTML Template which is specified inside indext.html.

// What loads the app.module.ts?  The answer is: main.ts, which has a method called
// platformBrowserDynamic( ).  The platformBrowserDynamic( ) is imported from
// Angular via ‘@angular/platform-browser-dynamic’, which effectively means I’m
// making a web application that runs in a browser.


// 2:14

// Angular v6 Snippets, Angular Files, Angular Language Service, angular2-switcher,
// Auto Rename Tag, Bracket Pair Colorizer, Cobalt2, Debugger for Chrome,
// Material Icon Theme, Path Intellisense, Prettier, TSLint


// 2:18

// Add Bootstrap and Font-Awesome so that I can add styling as I build the application.

// In the Command Prompt, I can “cd” into my DatingApp-SPA and then install Bootstrap
// and Font-Awesome into my SPA by typing: ‘npm install bootstrap font-awesome’.

// Regarding the npm warnings from downloading Bootstrap and Font-Awesome, I’m going to
// use an alternative method to Jquery for Bootstrap (which relies on Jquery for some
// of Bootstrap’s components).  I also don’t need popper.js because I’ll be getting this
// functionality from a package that is more Angular-friendly.

// In angular.json, I have a ‘styles’ array which is an area where I can import styles,
// including Bootstrap and Font-Awesome.  Because CSS, by its name, is “cascading”, I
// can generally override styles based on the order of my styles.  In other words, the
// Bootstrap styles would be first, then the Font-Awesome styles would be second, and
// then I would add my own custom styles to override Bootstrap and Font-Awesome where
// necessary.  However, the ‘styles’ array in angular.json of the current Angular CLI
// doesn’t respect the order of styles.

// The solution is to import the Bootstrap styles into the ‘styles.css’ of my
// angular.json.  If I go to the actual ‘styles.css’ file in my Solution Explorer,
// there’s a comment telling me that I can “add global styles to this file, and also
// import other style files”.  To import Bootstrap and Font-Awesome into my ‘styles.css’
// file, I type:
// “@import ‘. ./node_modules/bootstrap/dist/css/bootsrap.min.css’ ”
// “@import ‘. ./node_modules/font-awesome/css/font-awesome.min.css’ ”


import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';

@NgModule({
   declarations: [
      AppComponent,
      ValueComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
