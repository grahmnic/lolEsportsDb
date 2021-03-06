import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { SignInComponent } from './components/sign-in/signin.component';
import { DataService } from './components/shared/dataservice';
import { SigninService } from './components/shared/signinservice';
import { PlayerComponent } from './components/player/player.component';
import { AboutComponent } from './components/about/about.component';
import { ProfileComponent } from './components/profile/profile.component';
import { TeamComponent } from './components/team/team.component';
import { MatchComponent } from './components/match/match.component';
import { TournamentComponent } from './components/tournament/tournament.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        SignInComponent,
        AboutComponent,
        PlayerComponent,
        ProfileComponent,
        TeamComponent,
        MatchComponent,
        TournamentComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'about', component: AboutComponent },
            { path: 'sign-in', component: SignInComponent },
            { path: 'player/:id', component: PlayerComponent },
            { path: 'profile/:id', component: ProfileComponent },
            { path: 'team/:id', component: TeamComponent },
            { path: 'match/:id', component: MatchComponent },
            { path: 'tournament/:id', component: TournamentComponent}
        ])
    ],
    providers: [
        DataService,
        SigninService
    ]
})
export class AppModuleShared {
}
