import { Router } from '@angular/router';
import { Component } from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  name : any

  constructor(
    private router: Router,
    private authService: AuthService
    ) {
     this.authService.currentData.subscribe((item:any) =>
        this.name = item)
    }

  logout() {
    this.router.navigate(["/login"])
  }

}
