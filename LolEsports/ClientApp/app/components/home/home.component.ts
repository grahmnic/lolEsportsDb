import { Component, OnInit, AfterViewInit } from '@angular/core';
import { DataService } from '../shared/dataservice';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, AfterViewInit {
    boxes1: any = [];
    boxes2: any = [];
    boxes3: any = [];
    random_heights1: any = [];
    random_heights2: any = [];
    random_heights3: any = [];
    length1: any = 0;
    length2: any = 0;
    length3: any = 0;

    constructor(private dataService: DataService) {

    }

    navigateTo(link) {
        window.open(link, "_blank");
    }

    ngAfterViewInit() {

    }

    randomHeight() {
        var arr: number[] = new Array(this.length1);
        for (var i = 0; i < this.length1; i++) {
            arr[i] = (Math.random() * 10) + 20;
        }
        this.random_heights1 = arr;
        var arr1: number[] = new Array(this.length2);
        for (var i = 0; i < this.length2; i++) {
            arr1[i] = (Math.random() * 10) + 20;
        }
        this.random_heights2 = arr1;
        var arr2: number[] = new Array(this.length3);
        for (var i = 0; i < this.length3; i++) {
            arr2[i] = (Math.random() * 10) + 20;
        }
        this.random_heights3 = arr2;
    }

    ngOnInit() {
        this.dataService.getMedia()
            .subscribe((data) => {
                var d = data.json();
                for (var i = 0; i < d.length; i++) {
                    if (i % 3 == 0) {
                        this.boxes1.push(d[i]);
                        this.length1++;
                    } else if (i % 2 == 0) {
                        this.boxes2.push(d[i]);
                        this.length2++;
                    } else {
                        this.boxes3.push(d[i]);
                        this.length3++;
                    }
                }
                this.randomHeight();
            })
    }
}
