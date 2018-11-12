import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ScriptsComponent } from './scripts/scripts.component';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'scripts', component: ScriptsComponent },
    { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
