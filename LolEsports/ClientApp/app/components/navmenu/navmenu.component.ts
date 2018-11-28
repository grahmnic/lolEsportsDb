import { Component, OnInit } from '@angular/core';
import { SigninService } from '../shared/signinservice';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent implements OnInit{
    signedIn: boolean = false;
    champion: any;
    userId: any;


    constructor(private signinService: SigninService, private router: Router, private route: ActivatedRoute) {
        router.events.subscribe((val) => {
            this.signedIn = this.signinService.getStatus();
            this.champion = this.signinService.getChampion();
            this.userId = this.signinService.getuserId();
        });
    }

    ngOnInit() {
        this.signedIn = this.signinService.getStatus();
        this.champion = this.signinService.getChampion();
        this.userId = this.signinService.getuserId();
    }

    logout() {
        this.signinService.logout();
        this.router.navigate(['/home']);
    }
}
