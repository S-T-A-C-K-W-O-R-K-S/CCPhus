import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ScriptsComponent } from './scripts/scripts.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from './_guards/auth.guard';
import { CompanyComponent } from './company/company.component';
import { MemberDetailComponent } from './member/member-detail/member-detail.component';
import { MemberDetailResolver } from './_resolvers/member-detail.resolver';
import { CompanyMemberListResolver } from './_resolvers/company-member-list.resolver';
import { MemberEditComponent } from './member/member-edit/member-edit.component';
import { MemberEditResolver } from './_resolvers/member-edit.resolver';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'dashboard', component: DashboardComponent },
            { path: 'company', component: CompanyComponent, resolve: {users: CompanyMemberListResolver} },
            { path: 'company/member/edit', component: MemberEditComponent, resolve: {user: MemberEditResolver} },
            { path: 'company/member/:id', component: MemberDetailComponent, resolve: {user: MemberDetailResolver} },
            { path: 'scripts', component: ScriptsComponent }
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full' }
];
