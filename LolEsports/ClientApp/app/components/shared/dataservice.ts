import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { map } from 'rxjs/operators';

@Injectable()
export class DataService {
    myAppUrl: string = "";

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    //Account Transactions
    addAccount(account) {
        return this.http.post(this.myAppUrl + 'api/AddAccount', account);
    }

    getAccount(username, password) {
        return this.http.get(this.myAppUrl + 'api/signin/' + username + '/' + password);
    }

    //Player Transactions
    getPlayer(id) {
        return this.http.get(this.myAppUrl + 'api/GetPlayer/' + id);
    }

    //Team Transactions
    getTeam(id) {
        return this.http.get(this.myAppUrl + 'api/GetTeam/' + id);
    }

    //Profile Transactions
    getProfile(id) {
        return this.http.get(this.myAppUrl + 'api/GetProfile/' + id);
    }

    changePassword(id, password) {
        return this.http.put(this.myAppUrl + 'api/changePassword/' + id + '/' + password, null);
    }

    deleteAccount(id) {
        return this.http.delete(this.myAppUrl + 'api/deleteAccount/' + id);
    }

    //Match Transaction
    getMatch(id) {
        return this.http.get(this.myAppUrl + 'api/GetMatch/' + id);
    }

    //Tournament Transaction
    getTournament(id) {
        return this.http.get(this.myAppUrl + 'api/GetTournament/' + id);
    }

    //Champion Transaction
    getChampion(id) {
        return this.http.get(this.myAppUrl + 'api/GetChampion/' + id);
    }

    //Change profile Picture Transaction
    changeProfilePicture(id, championId) { 
        return this.http.put(this.myAppUrl + 'api/ChangeProfilePicture/' + id + '/' + championId, null);
    }

    getChampionList() {
        return this.http.get(this.myAppUrl + 'api/getChampions');
    }

    //Home Transaction
    getMedia() {
        return this.http.get(this.myAppUrl + 'api/getMedia');
    }
} 
