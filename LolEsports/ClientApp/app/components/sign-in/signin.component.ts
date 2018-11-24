import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../shared/dataservice';

@Component({
    selector: 'signin',
    templateUrl: './signin.component.html',
    styleUrls: ['./signin.component.css']
})
export class SignInComponent implements OnInit{
    username: any;
    password: any;
    error: boolean = false;
    error_login: boolean = false;
    error_login_message: string = "";

    constructor(private dataService: DataService, private router: Router) {

    }

    ngOnInit() {

    }

    submit() {
        if (this.username != "" && this.username != null && this.password != "" && this.password != null) {
            this.error = false;
            this.dataService.getAccount(this.username, this.password)
                .subscribe((data) => {
                    var d = data.json();
                    if (d.error == 1) {
                        this.error_login = true;
                        this.error_login_message = d.message;
                    } else {
                        this.error_login = false;
                        this.router.navigate(['/home']);
                    }
                });
        } else {
            this.error_login = false;
            this.error = true;
        }
    }
}
