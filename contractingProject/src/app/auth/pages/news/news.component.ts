import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss']
})
export class NewsComponent implements OnInit {
  newsList!: Array<number>;
  today: Date =  new Date();
  balance: any
  list:any

  constructor
  (private authService: AuthService
    ){
    this.authService.actualBalance.subscribe((item:any) =>
    this.balance = item)
    console.log(this.balance)
    this.authService.updatedList.subscribe((item:any) =>
    this.list = item)
    console.log(this.list)

  }


  ngOnInit(): void {
    const list = new Array<number>();
    for (let index = 0; index <1; index++) {
      list.push(index);
    }
    this.newsList = list
  }
}


