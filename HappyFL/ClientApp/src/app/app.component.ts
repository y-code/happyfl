import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Notification } from './model/notification';
import { Observable } from 'rxjs';
import { closeSaveRecipeMessage } from './service/recipe-management/recipe-management.actions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';

  saveRecipe$: Observable<{
    message: Notification,
  }>;

  constructor(
    private store: Store<{
      recipeManagement: {
        saveRecipe: {
          message: Notification,
        },
      }
    }>,
  ) {
  }

  ngOnInit(): void {
    this.saveRecipe$ = this.store.select(state => state.recipeManagement.saveRecipe);
  }

  closeSaveRecipeMessage() {
    this.store.dispatch(closeSaveRecipeMessage());
  }
}
