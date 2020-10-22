import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BestClientsComponent } from './best-clients.component';

describe('BestClientsComponent', () => {
  let component: BestClientsComponent;
  let fixture: ComponentFixture<BestClientsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BestClientsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BestClientsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
