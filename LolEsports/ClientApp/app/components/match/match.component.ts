import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from '../shared/dataservice';
import { CurrencyPipe } from '@angular/common';

@Component({
    selector: 'match',
    templateUrl: './match.component.html',
    styleUrls: ['./match.component.css']
})
export class MatchComponent implements OnInit {
    id: any;
    error: any;
    error_message: any;
    match: any = {};
    ChampionImages: any = [];
    PlayerNames: any = [];
    ChampionBans: any = [];
    ChampionImages2: any = [];
    PlayerNames2: any = [];
    ChampionBans2: any = [];

    constructor(private dataService: DataService, private router: Router, private route: ActivatedRoute) {

    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.id = +params['id'];

            this.dataService.getMatch(this.id)
                .subscribe((data) => {
                    var d = data.json();
                    if (d.error == 1) {
                        this.error = 1;
                        this.error_message = d.message;
                    } else {
                        this.match = d;
                        this.ChampionImages = d.championImages;
                        this.PlayerNames = d.playerNames;
                        this.ChampionBans = d.championBans;
                        this.ChampionImages2 = d.championImages2;
                        this.PlayerNames2 = d.playerNames2;
                        this.ChampionBans2 = d.championBans2;
                    }
                });
        });
    }


}
