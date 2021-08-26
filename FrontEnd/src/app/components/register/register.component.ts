import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  @ViewChild('registerModal') registerModal!: TemplateRef<any>;
  birthDay={};
  constructor(config: NgbModalConfig,private modalService: NgbModal) {
    // config.backdrop = 'static';
    // config.keyboard = false;
   }

  ngOnInit(): void {
  }

  open(){
    this.modalService.open(this.registerModal, { centered: true,size:'lg' });
  }

  close(){

  }
}
