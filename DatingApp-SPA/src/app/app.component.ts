// 2:13

// The app.component.ts file is Decorated with @Component, and it has imported the
// Component from @angular/core.  A class that is Decorated with a Component is a
// TypeScript Class that has extra Angular Component features.  Inside the @Component
// Decorator, a ‘selector’ (in this case, ‘app-root’) is specified.  A ‘templateUrl’
// references the ‘./app.component.html’ Template, which will be the HTML that will
// be generated on my page.  The ‘./app.component.html’ Template is standard HTML
// with one exception: the interpolation for ‘title’, which is basically a variable
// that holds the value of the ‘title’ Property in the AppComponent class.

// Inside the @Component Decorator, a ‘styleUrl’ is referenced as well.

// app.module.ts “Bootstraps” the AppComponent.  The AppComponent has a Selector,
// which is basically a tag that’s put inside an HTML page.  Since I’m building a SPA,
// there’s only one single HTML page: index.html.  In the body of index.html, I have
// <app-root></app-root>.  This is my AppComponent Selector.  The contents of
// <app-root></app-root> will be replaced by whatever is inside app.component.html.

// In summary, the app.module.ts loads the AppComponent.  The AppComponent has an
// HTML Template which is specified inside indext.html.

import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'DatingApp SPA';
}
