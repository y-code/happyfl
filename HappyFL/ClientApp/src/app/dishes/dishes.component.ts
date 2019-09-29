import { Component, OnInit, Output } from '@angular/core';
// import { RecipeManagementService, Dish } from '../service/recipe-management.service';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { requestDishes } from '../service/recipe-management/recipe-management.actions';
import { Dish } from '../model/recipe-management';

@Component({
  selector: 'app-dishes',
  templateUrl: './dishes.component.html',
  styleUrls: ['./dishes.component.css']
})
export class DishesComponent implements OnInit {
  @Output()
  // dishes: Dish[];
  dishes$ = this.store.select(state => state.recipeManagement.dishes);

  constructor(
    // private recipeManagement: RecipeManagementService,
    private store: Store<{
      recipeManagement: {
        dishes: {
          isLoading: boolean,
          data: Dish[],
        },
      }
    }>
  ) {}

  ngOnInit() {
    // this.recipeManagement.getDishes().subscribe((value: Dish[]) => {
    //   this.dishes = value;
    // });
    this.store.dispatch(requestDishes());
  }

}
