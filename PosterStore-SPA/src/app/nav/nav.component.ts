import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
   model: any = {}; // сохраняем сюда наш placeholder username and password
  constructor(private accountService: AccountService) { }

  ngOnInit() {
  }
  login() {
    this.accountService.login(this.model).subscribe(next => {
      console.log('Вход прошел успешно');
    }, error => console.log('Failed to login: ' + error));
  }
  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token; // ==  if(token == true) return true;
  }
  logout() {
    localStorage.removeItem('token');
    console.log('Logged out');
  }


}
