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
    top: any = {};
    bottom: any = {};
    mid: any = {}
    jungle: any = {};
    support: any = {};
    coach: any = {};
    team_name;
    team_logo;

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
                        this.team_name = d.teamName;
                        this.team_logo = d.teamPicture;
                        this.coach.ign = d.coachIgn;
                        this.coach.name = d.coachName;

                        d.ids.forEach(x => {
                            this.dataService.getPlayer(x)
                                .subscribe((p) => {
                                    var pd = p.json();
                                    if (pd.playerRole == "JUG") {
                                        this.jungle.PlayerIGN = pd.playerIGN;
                                        this.jungle.PlayerID = pd.playerID;
                                        this.jungle.PlayerImage = pd.playerImage;
                                    } else if (pd.playerRole == "BOT") {
                                        this.bottom.PlayerIGN = pd.playerIGN;
                                        this.bottom.PlayerID = pd.playerID;
                                        this.bottom.PlayerImage = pd.playerImage;
                                    } else if (pd.playerRole == "SUP") {
                                        this.support.PlayerIGN = pd.playerIGN;
                                        this.support.PlayerID = pd.playerID;
                                        this.support.PlayerImage = pd.playerImage;
                                    } else if (pd.playerRole == "TOP") {
                                        this.top.PlayerIGN = pd.playerIGN;
                                        this.top.PlayerID = pd.playerID;
                                        this.top.PlayerImage = pd.playerImage;
                                    } else if (pd.playerRole == "MID") {
                                        this.mid.PlayerIGN = pd.playerIGN;
                                        this.mid.PlayerID = pd.playerID;
                                        this.mid.PlayerImage = pd.playerImage;
                                    }
                                });
                        });
                    }
                })
        });
    }

    
}
