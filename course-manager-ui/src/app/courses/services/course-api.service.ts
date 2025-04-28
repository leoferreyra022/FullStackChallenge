import { Injectable } from '@angular/core';
import { Observable, of, delay } from 'rxjs';
import { Course } from '../models/course.model';
import { CourseState } from '../models/course-state.enum';

@Injectable({
  providedIn: 'root'
})
export class CourseApiService {

  private mockCourses: Course[] = [
    { id: 1, title: 'Angular Basics', platform: 'YouTube', createdAt: new Date().toISOString(), state: CourseState.Finished },
    { id: 2, title: 'NGRX Deep Dive', platform: 'Udemy', createdAt: new Date().toISOString(), state: CourseState.InProgress },
    { id: 3, title: '.NET Core API', platform: 'Pluralsight', createdAt: new Date().toISOString(), state: CourseState.Paused },
  ];
  private nextId = 4;

  constructor() { }

  getAll(): Observable<Course[]> {
    console.log('CourseApiService: getAll called');
    return of(this.mockCourses).pipe(delay(50));
  }

  create(courseData: Omit<Course, 'id' | 'createdAt'>): Observable<Course> {
    console.log('CourseApiService: create called', courseData);
    const newCourse: Course = {
      ...courseData,
      id: this.nextId++,
      createdAt: new Date().toISOString()
    };
    this.mockCourses = [...this.mockCourses, newCourse];
    return of(newCourse).pipe(delay(300));
  }

  // TODO: Implementar update(id, data): Observable<Course>
  // TODO: Implementar delete(id): Observable<void>
}
