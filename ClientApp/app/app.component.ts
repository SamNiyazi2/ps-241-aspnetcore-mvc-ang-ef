import { Component } from '@angular/core';

@Component({
  selector: 'the-shop',
  template: `
    <!--The content below is only a placeholder and can be replaced.-->
    <div style="text-align:center" class="content">
      <h1>
        Welcome to {{title}}!
      </h1>
    </div>
    
    
  `,
  styles: []
})
export class AppComponent {
  title = 'Dutch Treat';
}
