import { Component, OnInit } from '@angular/core';
import { SigninService } from '../shared/signinservice';
import { Router } from '@angular/router';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent implements OnInit{
    signedIn: boolean = false;
    champion: any;

    constructor(private signinService: SigninService, private router: Router) {
        router.events.subscribe((val) => {
            this.signedIn = this.signinService.getStatus();
            this.champion = this.signinService.getChampion();
        });
    }

    ngOnInit() {
        this.signedIn = this.signinService.getStatus();
        this.champion = this.signinService.getChampion();
    }

    logout() {
        this.signinService.logout();
        window.location.reload();
    }
}
