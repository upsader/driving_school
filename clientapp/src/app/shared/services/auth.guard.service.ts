import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private _authService: AuthenticationService,
    private _router: Router
  ) { }

  canActivate(): boolean {
    if (!this._authService.isLoggedIn()) {
      this._authService.HandleAuthError("Unauthorized");
      this._router.navigate(['/login']);
      return false;
    }
    return true;
  }
}