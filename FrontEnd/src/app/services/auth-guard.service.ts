import { MemberService } from './member.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router,private memberService: MemberService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    if (!this.memberService.token) { //未通過認證轉換到登入頁面
      this.router.navigate(['/login']);
      return false;
    }
    return true;
  }
}
