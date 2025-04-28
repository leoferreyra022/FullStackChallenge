import { Course } from "../models/course.model";

export interface CoursesState {
  list: Course[];
  loading: boolean;
  error: any | null; // Para manejo de errores
}

export const initialState: CoursesState = {
  list: [],
  loading: false,
  error: null
};
