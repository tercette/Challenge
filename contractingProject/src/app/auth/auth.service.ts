import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';


@Injectable(
  {providedIn: 'root'}
)

export class AuthService {
  private data = new BehaviorSubject<any>(null);
  currentData:any = this.data.asObservable();

  private balance = new BehaviorSubject<any>(null);
  actualBalance:any = this.balance.asObservable();

  private list = new BehaviorSubject<any>(null);
  updatedList:any = this.list.asObservable();

  public SetToken( token: string) {
    sessionStorage.setItem('token', token);
  }

  public GetToken() {
    sessionStorage.getItem('token');
  }

  public ClearToken() {
    sessionStorage.removeItem('token');
  }

  updateData(data: any) {
    this.data.next(data);
  }

  updateBalance(data:any) {
    this.balance.next(data);
  }

  updateList(data:any) {
    this.list.next(data)
  }

}
