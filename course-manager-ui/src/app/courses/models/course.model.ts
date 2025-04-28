import { CourseState } from "./course-state.enum";

export interface Course {
  id: number | null; // Nullable for new courses before saving
  title: string;
  platform: string;
  createdAt: string; // Use string for simplicity with JSON transfer
  state: CourseState;
} 