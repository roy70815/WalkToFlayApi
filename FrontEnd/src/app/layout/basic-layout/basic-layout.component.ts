import { MemberService } from './../../services/member.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-basic-layout',
  templateUrl: './basic-layout.component.html',
  styleUrls: ['./basic-layout.component.scss']
})
export class BasicLayoutComponent implements OnInit {
  get member(){return MemberService.member;}
  constructor(public memberService:MemberService) { }

  ngOnInit(): void {
  }


  logout(){
    this.memberService.logout();
  }

}
