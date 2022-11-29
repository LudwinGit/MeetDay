import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import ValidateForm from 'src/helpers/validateForm';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  login: Boolean = true;
  loginForm!: FormGroup;
  sigupForm!: FormGroup;
  constructor(private fb: FormBuilder, private router: Router) {}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
    this.sigupForm = this.fb.group({
      firstname: ['', Validators.required],
      lastname: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      telephone: ['',Validators.required],
      password: ['',Validators.required]
    });
  }

  onSubmitLogin() {
    if (this.loginForm.valid) {
    }
    else{
      ValidateForm.validateAllFormFields(this.loginForm)
    }
  }

  onSubmitSignUp() {
    if(this.sigupForm.valid){

    }
    else{
      ValidateForm.validateAllFormFields(this.loginForm)
    }
  }

  setSignUp() {
    this.login = false;
  }
  setSignIn() {
    this.login = true;
  }

  signIn() {
    this.router.navigate(['dashboard']);
  }
}
