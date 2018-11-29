import { Component, OnInit } from '@angular/core';
import { DataService } from '../shared/dataservice';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    boxes1: any = [];
    boxes2: any = [];
    boxes3: any = [];

    constructor(private dataService: DataService) {

    }

    navigateTo(link) {
        window.open(link, "_blank");
    }

    randomHeight() {
        return (Math.random() * 15) + 20;
    }

    ngOnInit() {
        this.dataService.getMedia()
            .subscribe((data) => {
                var d = data.json();
                console.log(d.length);
                for (var i = 0; i < d.length; i++) {
                    if (i % 3 == 0) {
                        this.boxes1.push(d[i]);
                    } else if (i % 2 == 0) {
                        this.boxes2.push(d[i]);
                    } else {
                        this.boxes3.push(d[i]);
                    }
                }
            })
    }
}
