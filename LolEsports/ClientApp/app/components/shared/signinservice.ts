﻿import { Injectable, Inject } from '@angular/core';

@Injectable()
export class SigninService {
    signed: boolean = false;
    userid: any;
    champion: any;

    constructor() {

    }

    getStatus() {
        return this.signed;
    }

    getChampion() {
        return this.champion;
    }

    signIn(userid, championImage) {
        this.signed = true;
        this.userid = userid;
        this.champion = championImage;
    }

    logout() {
        this.userid = "";
        this.signed = false;
    }
} 
