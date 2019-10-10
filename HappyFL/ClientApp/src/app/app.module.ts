import { BrowserModule } from '@angular/platform-browser';
// import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { StoreModule } from '@ngrx/store'

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { DishesComponent } from './dishes/dishes.component';
import { WebSeekerComponent } from './web-seeker/web-seeker.component';
import { RecipeSeekerComponent } from './recipe-seeker/recipe-seeker.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import * as RecipeManagementReducer from './service/recipe-management/recipe-management.reducer';
import { EffectsModule } from '@ngrx/effects';
import { RecipeManagementEffects } from './service/recipe-management/recipe-management.effects';
import { RecipesComponent } from './recipes/recipes.component';
import { RecipeSeekerIndexComponent } from './recipe-seeker-index/recipe-seeker-index.component';
import { DishComboboxComponent } from './recipe-seeker/dish-combobox.component';
import { IngredientSectionComboboxComponent } from './recipe-seeker/ingredient-section-combobox.component';
import { IngredientComboboxComponent } from './recipe-seeker/ingredient-combobox.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    DishesComponent,
    WebSeekerComponent,
    RecipeSeekerComponent,
    RecipeSeekerIndexComponent,
    RecipesComponent,
    DishComboboxComponent,
    IngredientSectionComboboxComponent,
    IngredientComboboxComponent,
    FooterComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    // BrowserAnimationsModule,
    HttpClientModule,
    FormsModule, ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: RecipeSeekerIndexComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'dishes', component: DishesComponent },
      { path: 'recipes', component: RecipesComponent },
      { path: 'web-seeker', component: WebSeekerComponent },
      { path: 'recipe-seeker-index', component: RecipeSeekerIndexComponent },
      {
        path: 'recipe-seeker',
        children: [
          { path: 'recipe/:id', component: RecipeSeekerComponent },
          { path: ':url', component: RecipeSeekerComponent },
        ],
      },
    ]),
    NgbModule,
    StoreModule.forRoot({
      recipeManagement: RecipeManagementReducer.reducer
    }),
    EffectsModule.forRoot([
      RecipeManagementEffects,
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
