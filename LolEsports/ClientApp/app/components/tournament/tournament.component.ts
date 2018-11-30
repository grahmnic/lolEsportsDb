import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from '../shared/dataservice';
import { CurrencyPipe } from '@angular/common';

@Component({
    selector: 'tournament',
    templateUrl: './tournament.component.html',
    styleUrls: ['./tournament.component.css']
})
export class TournamentComponent implements OnInit {
    id: any;
    error: any;
    error_message: any;
    t: any = {};
    gif: any;
    random_arr: any = [];

    constructor(private dataService: DataService, private router: Router, private route: ActivatedRoute) {

    }

    random() {
        var arr: boolean[] = new Array(this.t.matches.length);
        var counter = this.t.matches.length;
        for (var i = 0; i < counter; i++) {
            if (Math.random() > 0.5) {
                arr[i] = true;
            } else {
                arr[i] = false;
            }
        }
        this.random_arr = arr;
    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.id = +params['id'];

            this.dataService.getTournament(this.id)
                .subscribe((data) => {
                    var d = data.json();
                    if (d.error == 0) {
                        this.error = 0;
                        this.error_message = d.message;
                        this.t = d;
                        this.random();
                    } else {
                        this.error = 1;
                        this.error_message = d.message;
                    }
                });
        });
        var counter = 0;
        setInterval(() => {
            if (counter == 0) {
                this.gif = 0;
                counter++;
            } else if (counter == 1) {
                this.gif = 1;
                counter++;
            } else if (counter == 2) {
                this.gif = 2;
                counter = 0;
            }
        }, 1500);
    }


}
