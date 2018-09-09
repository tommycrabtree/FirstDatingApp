// 2:13

// What loads the app.module.ts?  The answer is: main.ts, which has a method called
// platformBrowserDynamic( ).  The platformBrowserDynamic( ) is imported from
// Angular via ‘@angular/platform-browser-dynamic’, which effectively means I’m
// making a web application that runs in a browser.

// index.html doesn’t have a “script” tag inside of it that refers to TypeScript,
// so what calls main.ts?  There is some “behind the scenes Angular magic” that uses
// a “module bundler” and a “task runner” called WebPack.  WebPack bundles my
// application into JavaScript.  At the same time, WebPack will inject this JavaScript
// into my index.html file when it builds it.  The configuration (actually it’s Angular
// abstracting the functionality from WebPack because WebPack can be complex to
// configure) for WebPack can be found in angular.json.  In other words, angular.json
// has the settings that WebPack needs to bundle my application.  These settings
// include a reference to src/main.ts and the index (src/index.html) into which it will
// then inject my JavaScript files.

import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.log(err));
