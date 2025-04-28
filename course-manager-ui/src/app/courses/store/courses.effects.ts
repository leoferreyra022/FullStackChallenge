import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { map, catchError, mergeMap, switchMap } from 'rxjs/operators'; // Asegúrate de importar switchMap si lo usas
import { CourseApiService } from '../services/course-api.service';
import * as CoursesActions from './courses.actions'; // Namespace import

@Injectable()
export class CoursesEffects {

  // Declare effects properties without initializing here
  loadCourses$;
  createCourse$;

  constructor(
    private actions$: Actions,
    private courseApiService: CourseApiService
  ) {
    console.log('CourseApiService in Effects constructor:', this.courseApiService);

    // Initialize effects inside the constructor
    this.loadCourses$ = createEffect(() => this.actions$.pipe(
      ofType(CoursesActions.loadCourses),
      mergeMap(() => {
        // Add a check here just in case
        if (!this.courseApiService) {
            console.error('CourseApiService is still undefined in mergeMap!');
            return of(CoursesActions.loadCoursesFailure({ error: 'Service not available' }));
        }
        return this.courseApiService.getAll().pipe(
            map(courses => CoursesActions.loadCoursesSuccess({ courses })),
            catchError(error => of(CoursesActions.loadCoursesFailure({ error })))
          );
        }
      )
    ));

    this.createCourse$ = createEffect(() => this.actions$.pipe(
        ofType(CoursesActions.createCourse),
        mergeMap(action => {
          if (!this.courseApiService) {
            console.error('CourseApiService is still undefined in mergeMap for create!');
            return of(CoursesActions.createCourseFailure({ error: 'Service not available' }));
          }
          return this.courseApiService.create(action.courseData).pipe(
                map(course => CoursesActions.createCourseSuccess({ course })),
                catchError(error => of(CoursesActions.createCourseFailure({ error })))
            );
          }
        )
    ));
  }
}
