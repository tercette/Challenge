import { LoginService } from './../../../services/loginservice';
import { LoginModel } from './../../../models/LoginModel';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { Router } from '@angular/router';
import { AuthService } from '../../auth.service';
import * as CryptoJS from 'crypto-js';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  showErrorMessage = false;
  secretKey = "YourSecretKeyForEncryption&Descryption";
  user!: string


  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    public LoginService: LoginService,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      //email: ['', [Validators.required, Validators.email]],
      username: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(5)]],
    });
  }

  encrypt(value: string): string {
    return CryptoJS.AES.encrypt(value, this.secretKey.trim()).toString();
  }

  submitLogin() {
    const dadosLogin = this.loginForm.getRawValue() as LoginModel;

    /* const password = dadosLogin.password;
    const encriptedPass = this.encrypt(password)
    dadosLogin.password = encriptedPass
    console.log('encrptografado =>',dadosLogin)
 */
    this.LoginService.LoginUsuario(dadosLogin)
      .subscribe(
        token => {
          this.user = dadosLogin.email
          if (token) {
            this.authService.SetToken(JSON.stringify(token))
            this.router.navigate(["/news"]);
            this.updateData()
            console.log('login token=> ', token)
            return
          }
        }, error => {
          console.log("login failed")
          this.showErrorMessage = true
        })
  }

  loginAgain() {
    this.showErrorMessage = false
    this.loginForm.reset()
  }

  updateData() {
    let name = this.loginForm.value.username
    console.log(name)
    this.authService.updateData(name)
  }
}
