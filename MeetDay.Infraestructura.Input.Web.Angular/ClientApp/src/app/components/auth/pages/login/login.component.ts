import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { FunctionsService } from 'src/app/utilities/functions.service';
import ValidateForm from 'src/helpers/validateForm';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  login: Boolean = true;
  loginForm!: FormGroup;
  sigupForm!: FormGroup;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private _service: AuthService,
    private _utils: FunctionsService
  ) {}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
    this.sigupForm = this.fb.group({
      firstname: ['', Validators.required],
      lastname: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      username: ['',Validators.required]
    });
  }

  onSubmitLogin() {
    if (this.loginForm.valid) {
      this._utils.loading(1, 'Autenticando usuario...');
      this._service.login(this.loginForm.value).subscribe({
        next: (res) => {
          this._utils.loading(0);
          
        },
        error: (err) => {
          this._utils.loading(0);
          alert(err?.error.message);
        },
      });
    } else {
      ValidateForm.validateAllFormFields(this.loginForm);
    }
  }

  onSubmitSignUp() {
    if (this.sigupForm.valid) {
      this._utils.loading(1, 'Creación de usuario');
      this._service.signUp(this.sigupForm.value).subscribe({
        next: (res) => {
          this._utils.loading(0);
          this.sigupForm.reset();
          this.router.navigate(['auth'])
        },
        error: (err) => {
          this._utils.loading(0);
          alert(err?.error.message);
        },
      });
    } else {
      ValidateForm.validateAllFormFields(this.loginForm);
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
