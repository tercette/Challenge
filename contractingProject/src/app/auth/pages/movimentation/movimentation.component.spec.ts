import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovimentationComponent } from './movimentation.component';

describe('MovimentationComponent', () => {
  let component: MovimentationComponent;
  let fixture: ComponentFixture<MovimentationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovimentationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MovimentationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
