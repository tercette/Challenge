
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";


@Injectable({
  providedIn: 'root'
})

export class LoginService {

  constructor(private httpClient: HttpClient) {
  }

  private readonly baseURL = environment["endpoint"]

  LoginUsuario(object: any) {
    return this.httpClient.post<any>(`${this.baseURL}/auth/signin`, object);
  }

  OpertationType(object:any) {
    return this.httpClient.post<any>(`${this.baseURL}/operation/addoperation`, object)
  }
}
