import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from '../shared/dataservice';

@Component({
    selector: 'team',
    templateUrl: './team.component.html',
    styleUrls: ['./team.component.css']
})
export class TeamComponent implements OnInit {
    id: any;
    error: any;
    error_message: any;
    player: any = {};
    role: any;

    constructor(private dataService: DataService, private router: Router, private route: ActivatedRoute) {

    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.id = +params['id'];

            this.dataService.getTeam(this.id)
                .subscribe((data) => {
                    var d = data.json();
                    if (d.error == 1) {
                        this.error = 1;
                        this.error_message = d.message;
                    } else {
                        this.error = 0;
                    }
                })
        });
    }

    
}
