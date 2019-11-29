import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
   model: any = {}; // сохраняем сюда наш placeholder username and password
  constructor(private accountService: AccountService, private alertify: AlertifyService) { }

  ngOnInit() {
  }
  login() {
    this.accountService.login(this.model).subscribe(next => {
     this.alertify.success('Вход прошел успешно');
    }, error => this.alertify.error(error));
  }
  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token; // ==  if(token == true) return true;
  }
  logout() {
    localStorage.removeItem('token');
    this.alertify.message('Logged out');
  }
}
