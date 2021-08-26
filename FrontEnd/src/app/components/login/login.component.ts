import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { NgbModal, NgbModalConfig, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  @ViewChild('loginModal') loginModal!: TemplateRef<any>;
  constructor(config: NgbModalConfig,private modalService: NgbModal) {
    // config.backdrop = 'static';
    // config.keyboard = false;
  }

  ngOnInit(): void {
  }

  open(){
    this.modalService.open(this.loginModal, { centered: true });
  }

  close(){

  }

}
