import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EcashListComponent } from './ecash-list.component';

describe('EcashListComponent', () => {
  let component: EcashListComponent;
  let fixture: ComponentFixture<EcashListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EcashListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EcashListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
