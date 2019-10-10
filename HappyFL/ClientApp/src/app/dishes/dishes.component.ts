import { Component, OnInit, Output } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { requestDishes } from '../service/recipe-management/recipe-management.actions';
import { Dish } from '../model/recipe-management';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dishes',
  templateUrl: './dishes.component.html',
  styleUrls: ['./dishes.component.scss']
})
export class DishesComponent implements OnInit {
  @Output()
  dishes$ = this.store.select(state => state.recipeManagement.dishes);

  constructor(
    private store: Store<{
      recipeManagement: {
        dishes: {
          isLoading: boolean,
          data: Dish[],
        },
      }
    }>,
    private router: Router
  ) {}

  ngOnInit() {
    this.store.dispatch(requestDishes());
  }

  goToRecipesPage(dishId: number) {
    this.router.navigate(["/recipes"], { queryParams: { dishId } });
  }
}
