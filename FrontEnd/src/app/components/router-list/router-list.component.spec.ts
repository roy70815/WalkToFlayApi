import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RouterListComponent } from './router-list.component';

describe('RouterListComponent', () => {
  let component: RouterListComponent;
  let fixture: ComponentFixture<RouterListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RouterListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RouterListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
