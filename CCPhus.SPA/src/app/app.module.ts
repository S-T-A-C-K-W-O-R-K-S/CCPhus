import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule, TabsModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { NgxGalleryModule } from 'ngx-gallery';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor.service';
import { AlertifyService } from './_services/alertify.service';
import { appRoutes } from './routes';
import { ScriptsComponent } from './scripts/scripts.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from './_guards/auth.guard';
import { UserService } from './_services/user.service';
import { CompanyComponent } from './company/company.component';
import { MemberCardComponent } from './member/member-card/member-card.component';
import { MemberDetailComponent } from './member/member-detail/member-detail.component';
import { MemberDetailResolver } from './_resolvers/member-detail.resolver';
import { CompanyMemberListResolver } from './_resolvers/company-member-list.resolver';
import { MemberEditComponent } from './member/member-edit/member-edit.component';
import { MemberEditResolver } from './_resolvers/member-edit.resolver';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';

export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      DashboardComponent,
      CompanyComponent,
      ScriptsComponent,
      MemberCardComponent,
      MemberDetailComponent,
      MemberEditComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      NgxGalleryModule,
      JwtModule.forRoot({
         config: {
            tokenGetter: tokenGetter,
            whitelistedDomains: ['localhost:5000', 'localhost:5001'],
            blacklistedRoutes: ['localhost:5000/api/auth', 'localhost:5001/api/auth']
         }
      }),
      TabsModule.forRoot()
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyService,
      AuthGuard,
      UserService,
      MemberDetailResolver,
      CompanyMemberListResolver,
      MemberEditResolver,
      PreventUnsavedChangesGuard
   ],
   bootstrap: [
      AppComponent
   ]
})

export class AppModule { }
