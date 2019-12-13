import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { AlertifyService } from '../_services/alertify.service';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { User } from '../_models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
   user: User;
   registerForm: FormGroup;
  constructor(private accountService: AccountService,
     private alertify: AlertifyService, private fb: FormBuilder, private router: Router ) { }

  ngOnInit() {
    this.createRegisterForm();
  }
  createRegisterForm() {
    this.registerForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]],
      confirmPassword: ['', Validators.required]

    }, {validator: this.passswordMatchValidator});
  }
  register() {
    if (this.registerForm.valid) {
      this.user = Object.assign({}, this.registerForm.value);
      // копирует данные с registerForm.value в пустой {}  и потом присваиваем его в user
      this.accountService.register(this.user).subscribe(() => {
        this.alertify.success('Регистрация прошла успешно');
      }, error => {
        this.alertify.error(error);
      }, () => {
        this.accountService.login(this.user).subscribe(() => {
          this.router.navigate(['/posters']);
        });
      });
    }

  }
  cancel() {
    this.cancelRegister.emit(false);
  }
  passswordMatchValidator(g: FormGroup) {
    return g.get('password').value === g.get('confirmPassword').value ?  null : {'mismatch' : true};
  }

}
