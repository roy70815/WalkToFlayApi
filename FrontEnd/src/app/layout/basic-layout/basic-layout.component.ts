import { MemberService } from './../../services/member.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-basic-layout',
  templateUrl: './basic-layout.component.html',
  styleUrls: ['./basic-layout.component.scss']
})
export class BasicLayoutComponent implements OnInit {
  member:any;
  constructor(public memberService:MemberService) { }

  ngOnInit(): void {
    this.getMember();
  }

  getMember(){
    this.memberService.getMember().subscribe(x=>{
      console.log(x.data)
      this.member=x.data;
    })
  }

  logout(){
    this.memberService.logout();
    location.reload();
  }

}
