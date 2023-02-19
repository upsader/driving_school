import { Component } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { StorageService } from '../../services/storage.service';

@Component({
  selector: 'app-header',
  templateUrl: './app-header.component.html',
  styleUrls: ['./app-header.component.scss']
})
export class AppHeaderComponent {

  constructor(public authService: AuthenticationService, public storage: StorageService) {}

  logoutClicked(event: any) {
    event.preventDefault();
    this.logout();
  }

  logout() {
    this.authService.logout();
  }
}
