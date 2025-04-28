import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { CourseState } from '../../models/course-state.enum';
import * as CoursesActions from '../../store/courses.actions';
import { Observable } from 'rxjs';
import * as CoursesSelectors from '../../store/courses.selectors';

@Component({
  selector: 'app-course-form',
  standalone: false,
  templateUrl: './course-form.component.html',
  styleUrl: './course-form.component.scss'
})
export class CourseFormComponent implements OnInit {
  courseForm!: FormGroup; 
  courseStates = Object.values(CourseState);
  loading$: Observable<boolean>;

  constructor(
    private fb: FormBuilder,
    private store: Store
    ) {
      this.loading$ = this.store.select(CoursesSelectors.selectCoursesLoading);
  }

  ngOnInit(): void {
    this.courseForm = this.fb.group({
      title: ['', Validators.required],
      platform: ['', Validators.required],
      state: [CourseState.Initiated, Validators.required]
    });
  }

  save(): void {
    if (this.courseForm.invalid) {
      console.warn('Formulario inválido. Por favor, completa todos los campos requeridos.');
      this.courseForm.markAllAsTouched();
      return;
    }

    const courseData = this.courseForm.value;
    console.log('Saving course data:', courseData);

    this.store.dispatch(CoursesActions.createCourse({ courseData }));

    console.info('Intentando guardar el curso...');
     this.courseForm.reset({ state: CourseState.Initiated });

  }

  get f() { return this.courseForm.controls; }
}
