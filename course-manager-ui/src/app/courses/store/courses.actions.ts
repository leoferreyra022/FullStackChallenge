import { createAction, props } from '@ngrx/store';
import { Course } from '../models/course.model';

// Load Actions
export const loadCourses = createAction('[Courses API] Load Courses');
export const loadCoursesSuccess = createAction(
  '[Courses API] Load Courses Success',
  props<{ courses: Course[] }>()
);
export const loadCoursesFailure = createAction(
  '[Courses API] Load Courses Failure',
  props<{ error: any }>()
);

// Create Actions
export const createCourse = createAction(
    '[Courses Page] Create Course',
    props<{ courseData: Omit<Course, 'id' | 'createdAt'> }>()
);
export const createCourseSuccess = createAction(
    '[Courses API] Create Course Success',
    props<{ course: Course }>()
);
export const createCourseFailure = createAction(
    '[Courses API] Create Course Failure',
    props<{ error: any }>()
);

// TODO: Add actions for Update and Delete
// export const updateCourse = createAction(...);
// export const updateCourseSuccess = createAction(...);
// export const updateCourseFailure = createAction(...);

// export const deleteCourse = createAction(...);
// export const deleteCourseSuccess = createAction(...);
// export const deleteCourseFailure = createAction(...);
