import { createFeatureSelector, createSelector } from '@ngrx/store';
import { CoursesState } from './courses.state';

// Nombre del feature state (debe coincidir con StoreModule.forFeature)
export const coursesFeatureKey = 'courses';

// Selector para el feature state completo
const selectCoursesFeature = createFeatureSelector<CoursesState>(coursesFeatureKey);

// Selector para la lista de cursos
export const selectAllCourses = createSelector(
  selectCoursesFeature,
  (state: CoursesState) => state.list
);

// Selector para el estado de carga
export const selectCoursesLoading = createSelector(
  selectCoursesFeature,
  (state: CoursesState) => state.loading
);

// Selector para errores
export const selectCoursesError = createSelector(
    selectCoursesFeature,
    (state: CoursesState) => state.error
);

// TODO: Add selectors as needed (e.g., selectCourseById)
