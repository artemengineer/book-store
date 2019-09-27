import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { JwtModule } from '@auth0/angular-jwt';
import { BsDropdownModule, TabsModule, ButtonsModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { BookListComponent } from './book-list/book-list.component';
import { BookSelectedListComponent } from './book-selected-list/book-selected-list.component';
import { BookDetailComponent } from './book-detail/book-detail.component';
import { BookCardComponent } from './book-card/book-card.component';


export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      HeaderComponent,
      HomeComponent,
      RegisterComponent,
      BookListComponent,
      BookSelectedListComponent,
      BookDetailComponent,
      BookCardComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      RouterModule,
      ReactiveFormsModule,
      BsDropdownModule.forRoot(),
      TabsModule.forRoot(),
      ButtonsModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      JwtModule.forRoot({
        config: {
           tokenGetter: tokenGetter,
           whitelistedDomains: ['localhost:5000'],
           blacklistedRoutes: ['localhost:5000/api/auth']
        }
     })
   ],
  providers: [
    AuthService
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule {
}
