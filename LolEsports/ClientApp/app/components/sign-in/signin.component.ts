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
    error_signup: boolean = false;
    error_signup_message: string = "";

    constructor(private dataService: DataService, private router: Router) {

    }

    ngOnInit() {

    }

    signup() {
        if (this.username != "" && this.username != null && this.password != "" && this.password != null) {
            this.error = false;
            this.error_login = false;
            var account = {
                UserName: this.username,
                Password: this.password
            }
            this.dataService.addAccount(account)
                .subscribe((data) => {
                    var d = data.json();
                    if (d.error == 1) {
                        this.error_signup = true;
                        this.error_signup_message = d.message;
                    } else {
                        this.error_signup = false;
                        var element = <HTMLElement>document.getElementById("modal-btn");
                        element.click();
                    }
                });
        } else {
            this.error_signup = false;
            this.error_login = false;
            this.error = true;
        }
    }

    submit() {
        if (this.username != "" && this.username != null && this.password != "" && this.password != null) {
            this.error = false;
            this.error_signup = false;
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
            this.error_signup = false;
            this.error = true;
        }
    }
}
