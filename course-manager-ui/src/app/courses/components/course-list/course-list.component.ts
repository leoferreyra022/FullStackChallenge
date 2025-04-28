import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, BehaviorSubject, combineLatest, map } from 'rxjs';
import { Course } from '../../models/course.model';
import * as CoursesSelectors from '../../store/courses.selectors';
import * as CoursesActions from '../../store/courses.actions';
import { CommonModule } from '@angular/common'; 
import { CeilPipe } from '../../../shared/pipes/ceil.pipe';

@Component({
  selector: 'app-course-list',
  standalone: true,
  imports: [CommonModule, CeilPipe],
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.scss']
})
export class CourseListComponent implements OnInit {
  private allCourses$: Observable<Course[]>;
  loading$: Observable<boolean>;
  error$: Observable<any>;

  courses$: Observable<Course[]>;
  totalItems$: Observable<number>;
  private filterSubject = new BehaviorSubject<string>('');
  filter$ = this.filterSubject.asObservable();
  private currentPageSubject = new BehaviorSubject<number>(1);
  currentPage$ = this.currentPageSubject.asObservable();
  itemsPerPage: number = 5;

  constructor(private store: Store) {
    console.log('>>> CourseListComponent CONSTRUCTOR EXECUTED <<<');
    console.log('CourseListComponent constructor loaded');
    this.allCourses$ = this.store.select(CoursesSelectors.selectAllCourses);
    this.loading$ = this.store.select(CoursesSelectors.selectCoursesLoading);
    this.error$ = this.store.select(CoursesSelectors.selectCoursesError);

    const filteredCourses$ = combineLatest([this.allCourses$, this.filter$]).pipe(
      map(([courses, filter]) => {
        const normalizedFilter = filter.toLowerCase().trim();
        if (!normalizedFilter) {
          return courses;
        }
        return courses.filter(course =>
          course.title.toLowerCase().includes(normalizedFilter) ||
          course.platform.toLowerCase().includes(normalizedFilter) ||
          course.state.toLowerCase().includes(normalizedFilter)
        );
      })
    );

    this.totalItems$ = filteredCourses$.pipe(
      map(courses => courses.length)
    );

    this.courses$ = combineLatest([filteredCourses$, this.currentPage$, this.totalItems$]).pipe(
      map(([courses, currentPage, totalItems]) => {
        const totalPages = Math.ceil(totalItems / this.itemsPerPage);
        const page = (currentPage > totalPages && totalPages > 0) ? totalPages : currentPage < 1 ? 1 : currentPage;
        if (page !== currentPage) {
             setTimeout(() => this.currentPageSubject.next(page), 0);
        }
        const startIndex = (page - 1) * this.itemsPerPage;
        return courses.slice(startIndex, startIndex + this.itemsPerPage);
      })
    );
  }

  ngOnInit(): void {
    console.log('CourseListComponent ngOnInit');
    this.store.dispatch(CoursesActions.loadCourses());

    this.error$.subscribe(error => {
      if (error) {
        console.error('Error loading courses:', error);
      }
    });
  }

  onFilterGlobal(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.filterSubject.next(filterValue);
    this.currentPageSubject.next(1);
  }

  nextPage(): void {
    this.currentPageSubject.next(this.currentPageSubject.value + 1);
  }

  previousPage(): void {
    if (this.currentPageSubject.value > 1) {
      this.currentPageSubject.next(this.currentPageSubject.value - 1);
    }
  }

  edit(course: Course): void {
    console.log('Edit course:', course);
    console.info(`Editar curso ${course.id} (no implementado)`);
  }

  delete(courseId: number | null): void {
    if (courseId === null) return;
    console.log('Delete course ID:', courseId);
    console.warn(`Borrar curso ${courseId} (no implementado)`);
  }
}
