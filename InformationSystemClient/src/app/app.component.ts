import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'InformationSystemClient';

  constructor(private translate: TranslateService) {

    translate.addLangs(['BG', 'EN']);
    translate.setDefaultLang('EN');

    const browserLang = translate.getBrowserLang();
    translate.use(browserLang.match(/EN|BG/) ? browserLang : 'EN');
  }
}