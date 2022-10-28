import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  login : Boolean = true;
  constructor(private router: Router) { }

  ngOnInit(): void {
    
  }

  setSignUp(){
    this.login = false
  }
  setSignIn(){
    this.login = true
  }

  signIn(){
    this.router.navigate(['dashboard']);
  }
}
