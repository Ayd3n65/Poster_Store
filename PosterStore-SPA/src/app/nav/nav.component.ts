import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
   model: any = {}; // сохраняем сюда наш placeholder username and password
  constructor(private accountService: AccountService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }
  login() {
    this.accountService.login(this.model).subscribe(next => {
     this.alertify.success('Вход прошел успешно');
    }, error => { this.alertify.error(error); }
     , () => {
      this.router.navigate(['/posters']);
      });
  }
  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token; // ==  if(token == true) return true;
  }
  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.accountService.decodedToken = null;
    this.accountService.currentUser = null;
    this.alertify.message('logged out');
    this.router.navigate(['/home']);
  }
}
