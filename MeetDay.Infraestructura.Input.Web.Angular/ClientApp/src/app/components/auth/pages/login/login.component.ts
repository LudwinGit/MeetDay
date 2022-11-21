import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

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
      this.validateAllFormFields(this.loginForm)
    }
  }

  onSubmitSignUp() {
    if(this.sigupForm.valid){

    }
    else{
      this.validateAllFormFields(this.loginForm)
    }
  }

  private validateAllFormFields(formGroup: FormGroup){
    Object.keys(formGroup.controls).forEach(field=>{
      const control = formGroup.get(field);
      if(control instanceof FormControl){
        control.markAsDirty({onlySelf: true});
      }
      else if(control instanceof FormGroup){
        this.validateAllFormFields(control)
      }
    })
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
