import { MemberService } from './member.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router,private memberService: MemberService) { }

  async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean> {
    let res =await this.memberService.getMember().toPromise();
    if(res?.data){
      MemberService.member=res?.data;
      console.log(MemberService.member)
    }
    if (!MemberService.member) { //未通過認證轉換到登入頁面
      alert('請先登入')
      this.router.navigate(['/login']);
      return false;
    }
    return true;
  }
}
