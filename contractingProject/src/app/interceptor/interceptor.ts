import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable, map } from 'rxjs'
import { AuthService } from "../auth/auth.service";

@Injectable(
  {providedIn: 'root'}
)

export class Interceptor implements HttpInterceptor {

constructor(private authService: AuthService) {

}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    let headers;

    if(req.body instanceof FormData)
    {
      headers: new HttpHeaders(
        {
          contentType : 'false',
          processData : 'false',
          Authorization: 'Bearer' + this.authService.GetToken()
        }
      )
    }
    else{
      headers: new HttpHeaders()
      .append("accept", "application/json")
      .append("Content-Type", "application/json")
      .append("Authorization", "Bearer" + this.authService.GetToken());
    }

    let request = req.clone({ headers });

    return next.handle(request).pipe(
      map((event) => {
        return event
      })
    );

  }

}
