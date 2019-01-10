import { Injectable } from "@angular/core";
import { User } from "../_models/user";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { AlertifyService } from "../_services/alertify.service";
import { UserService } from "../_services/user.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/Operators";

@Injectable()

export class CompanyMemberListResolver implements Resolve<User[]> {
    constructor(private userService: UserService, private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<User[]> {
        return this.userService.getUsers().pipe(
            catchError(error => {
                this.alertify.error('Problem Retrieving Data');
                this.router.navigate(['']);
                return of(null);
            })
        )
    }
}
