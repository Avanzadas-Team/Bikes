import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientAverageComponent } from './client-average.component';

describe('ClientAverageComponent', () => {
  let component: ClientAverageComponent;
  let fixture: ComponentFixture<ClientAverageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClientAverageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClientAverageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
