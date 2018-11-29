import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from '../shared/dataservice';

@Component({
    selector: 'profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
    id: any;
    error: any;
    error_message: any;
    userName: any;
    championImage: any;
    password: any;
    champions: any;

    constructor(private dataService: DataService, private router: Router, private route: ActivatedRoute) {

    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.id = +params['id'];
            this.dataService.getProfile(this.id)
                .subscribe((data) => {
                    console.log(data);
                    var json = data.json();
                    if (json.error == 0) {
                        this.userName = json.userName;
                        this.championImage = json.championImage;
                        this.getChampionList();
                    } else {
                        this.error = 1;
                        this.error_message = json.message;
                    }
                });

        });
    }

    openPasswordModal() {
        var ele = <HTMLElement>document.getElementById("change");
        ele.click();
    }

    openDeleteModal() {
        var ele = <HTMLElement>document.getElementById("delete");
        ele.click();
    }

    openAvatarModal() {
        var ele = <HTMLElement>document.getElementById("avatar");
        ele.click(); 
    }

    changePassword() {
        this.dataService.changePassword(this.id, this.password)
            .subscribe((data) => {
                var d = data.json();
                if (d.error == 1) {
                    this.error = 1;
                    this.error_message = d.message;
                } else {
                    this.error = 0;
                    this.error_message = d.message;
                }
            });
    }

    deleteAccount() {
        this.dataService.deleteAccount(this.id)
            .subscribe((data) => {
                var d = data.json();
                if (d.error == 1) {
                    this.error = 1;
                    this.error_message = d.message;
                } else {
                    this.error = 0;
                    this.error_message = d.message;
                    this.router.navigateByUrl('/home');
                }
            });
    }

    getChampionList() {
        this.dataService.getChampionList()
            .subscribe((data) => {
                this.champions = data.json();
            });
    }

    changeProfilePicture(image) {
        this.dataService.changeProfilePicture(this.id, image)
            .subscribe((data) => {
                var d = data.json();
                if (d.error == 1) {
                    this.error = 1;
                    this.error_message = d.message;
                } else {
                    this.error = 0;
                    this.error_message = d.message;
                }
            });
    }
}
