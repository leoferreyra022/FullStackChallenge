import { createReducer, on } from '@ngrx/store';
import * as CoursesApiActions from './courses.actions'; // Import using namespace
import { initialState } from './courses.state';

// Define and export the feature key
export const coursesFeatureKey = 'courses';

// Cambiado el nombre para evitar conflicto con el tipo CoursesState
const _coursesReducer = createReducer(
  initialState,

  // Load Reducers
  on(CoursesApiActions.loadCourses, (state) => ({
     ...state,
     loading: true,
     error: null // Reset error on new load attempt
  })),
  on(CoursesApiActions.loadCoursesSuccess, (state, { courses }) => ({
    ...state,
    list: courses,
    loading: false
  })),
  on(CoursesApiActions.loadCoursesFailure, (state, { error }) => ({
     ...state,
     loading: false,
     error: error
  })),

  // Create Reducers
  on(CoursesApiActions.createCourse, (state) => ({ // Marcar loading al intentar crear
    ...state,
    loading: true, // O un flag específico como 'creating'
    error: null
  })),
  on(CoursesApiActions.createCourseSuccess, (state, { course }) => ({
    ...state,
    list: [...state.list, course], // Añadir el nuevo curso a la lista
    loading: false
  })),
  on(CoursesApiActions.createCourseFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error: error
  }))

  // TODO: Add reducers for Update and Delete actions
);

// Exporta la función reducer
export function coursesReducer(state: any, action: any) {
  return _coursesReducer(state, action);
}
