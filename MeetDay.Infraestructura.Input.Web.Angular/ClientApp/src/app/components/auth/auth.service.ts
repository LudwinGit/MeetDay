import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}
  signUp(userObj: any) {
    return this.http.post<any>(`${this.baseUrl}/register`,userObj)
  }

  login(loginObj: any){
    return this.http.post<any>(`${this.baseUrl}/authenticate`,loginObj)
  }
}
