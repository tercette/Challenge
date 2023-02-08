import { Component } from '@angular/core';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';
import { LoginService } from 'src/app/services/loginservice';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-movimentation',
  templateUrl: './movimentation.component.html',
  styleUrls: ['./movimentation.component.scss']
})
export class MovimentationComponent implements ErrorStateMatcher {
  value = 1;
  operationType : any = 'Credit';
  types: string[] = ['Credit', 'Debit']
  inputValue = null

  constructor(
    public loginService : LoginService,
    private authService: AuthService
    ) {}

  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }

  getValue(inputValue:number){
    this.operationType==='Credit'? this.operationType = 1: this.operationType=0
    let operation = {valueOperation: inputValue, typeOperation: this.operationType};
    this.inputValue = null;
    this.operationType = 'Credit';
    this.loginService.OpertationType(operation).subscribe(
      res => {
        if(res){
         let totalBalance = res.dailyTotal;
         this.authService.updateBalance(totalBalance);
         let list = res.dailyOperations.map((val: any) => {
          return [val.valueOperation, new Date(val.date).toLocaleDateString('en-GB', {
            day: '2-digit',
            month: '2-digit',
            year: 'numeric'
          })];
        });
          console.log(list)
          this.authService.updateList(list)
        }
      },error => {
        console.log("movimentation process failed")
      }
    )
  }

}
