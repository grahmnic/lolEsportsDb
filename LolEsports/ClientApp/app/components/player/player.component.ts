import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from '../shared/dataservice';
import { CurrencyPipe } from '@angular/common';

@Component({
    selector: 'player',
    templateUrl: './player.component.html',
    styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {
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

            this.dataService.getPlayer(this.id)
                .subscribe((data) => {
                    var d = data.json();
                    if (d.error == 1) {
                        this.error = 1;
                        this.error_message = d.message;
                    } else {
                        this.error = 0;

                        this.player.PlayerID = d.playerID;
                        this.player.PlayerIGN = d.playerIGN.toUpperCase();
                        this.player.PlayerRole = d.playerRole;
                        this.player.TotalScore = d.totalScore;
                        this.player.TotalKills = d.totalKills;
                        this.player.TotalDeaths = d.totalDeaths;
                        this.player.TotalAssists = d.totalAssists;
                        this.player.Quote = d.quote;
                        this.player.PlayerRole = d.playerRole;
                        this.player.PersonName = d.personName;
                        this.player.Hometown = d.hometown;
                        this.player.Biography = d.biography;
                        this.player.Age = d.age;
                        this.player.Salary = d.salary;
                        this.player.PlayerImage = d.playerImage;
                        this.player.TeamImage = d.teamImage;
                        this.player.TeamName = d.teamName;

                        if (this.player.PlayerRole == "BOT") {
                            this.role = "https://elo-boost.net/images/roles/ad.png";
                        } else if (this.player.PlayerRole == "SUP") {
                            this.role = "https://elo-boost.net/images/roles/support.png";
                        } else if (this.player.PlayerRole == "MID") {
                            this.role = "https://elo-boost.net/images/roles/mid.png";
                        } else if (this.player.PlayerRole == "JUG") {
                            this.role = "https://elo-boost.net/images/roles/jungle.png";
                        } else if (this.player.PlayerRole == "TOP") {
                            this.role = "https://elo-boost.net/images/roles/top.png";
                        }
                    }
                });
        });
    }


}
