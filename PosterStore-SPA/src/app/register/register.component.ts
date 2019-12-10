import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
   model: any = {};
  constructor(private accountService: AccountService, private alertify: AlertifyService ) { }

  ngOnInit() {
  }
  register() {
    this.accountService.register(this.model).subscribe(() => {
     this.alertify.success('Регистрация прошла успешно');
    }, error => this.alertify.error(error));
  }
  cancel() {
    this.cancelRegister.emit(false);
  }

}
