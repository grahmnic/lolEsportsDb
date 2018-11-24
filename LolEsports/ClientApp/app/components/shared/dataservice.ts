import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { map } from 'rxjs/operators';

@Injectable()
export class DataService {
    myAppUrl: string = "";

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    addAccount(account) {
        return this.http.post(this.myAppUrl + 'api/AddAccount', account);
    }

    getAccount(username, password) {
        return this.http.get(this.myAppUrl + 'api/signin/' + username + '/' + password);
    }
} 
