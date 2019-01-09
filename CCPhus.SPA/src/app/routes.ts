import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ScriptsComponent } from './scripts/scripts.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from './_guards/auth.guard';
import { CompanyComponent } from './company/company.component';
import { MemberDetailComponent } from './member-detail/member-detail.component';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'dashboard', component: DashboardComponent },
            { path: 'company', component: CompanyComponent },
            { path: 'company/member/:id', component: MemberDetailComponent },
            { path: 'scripts', component: ScriptsComponent }
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full' }
];
