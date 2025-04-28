import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'ceil',
  standalone: true
})
export class CeilPipe implements PipeTransform {

  transform(value: number): number {
    if (value === null || value === undefined || isNaN(value)) {
      return 1; // Devolver 1 por defecto
    }
    return Math.ceil(value);
  }

} 