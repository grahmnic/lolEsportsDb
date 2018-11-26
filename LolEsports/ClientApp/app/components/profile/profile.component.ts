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

    constructor(private dataService: DataService, private router: Router, private route: ActivatedRoute) {

    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.id = +params['id'];
            this.dataService.getProfile(this.id)
                .subscribe((data) => {
                    var json = data.json();
                    if (json.error == 0) {
                        this.userName = json.userName;
                        this.championImage = json.championImage;
                    } else {
                        this.error = 1;
                        this.error_message = json.message;
                    }
                });

        });
    }


}
