import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { CoursesRoutingModule } from './courses-routing.module';
import { CourseFormComponent } from './components/course-form/course-form.component';

import { coursesFeatureKey, coursesReducer } from './store/courses.reducer';
import { CoursesEffects } from './store/courses.effects';

@NgModule({
  declarations: [
    CourseFormComponent
  ],
  imports: [
    CommonModule,
    CoursesRoutingModule,
    ReactiveFormsModule,
    StoreModule.forFeature(coursesFeatureKey, coursesReducer),
    EffectsModule.forFeature([CoursesEffects]),
  ],
  providers: []
})
export class CoursesModule { }
