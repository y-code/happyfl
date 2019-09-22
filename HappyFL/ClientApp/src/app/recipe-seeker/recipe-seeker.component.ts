import { Component, OnInit, Input, Output, Inject, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WebSeekerService, LinkInfo, RecipeSeekResult, Recipe, Ingredient, IngredientsSection } from '../service/web-seeker.service';
import { Store } from '@ngrx/store';
import { requestRecipeSeek, cancelRecipeSeek } from '../service/recipe-management/recipe-management.actions';

@Component({
  selector: 'app-recipe-seeker',
  templateUrl: './recipe-seeker.component.html',
  styleUrls: ['./recipe-seeker.component.css']
})
export class RecipeSeekerComponent implements OnInit {

  @Input()
  @Output()
  public url: string;

  public links: LinkInfo[];
  public imageLinks: LinkInfoPlus[];

  @Input()
  @Output()
  public recipeName: string;

  public sectionName: string;

  public recipe: Recipe = new Recipe();

  recipeSeekResult$ = this.store.select(state => state.recipeManagement.recipeSeekResult);

  constructor(
    private webSeekerService: WebSeekerService,
    @Inject("BASE_URL") public baseUrl: string,
    private store: Store<{
      recipeManagement: {
        recipeSeekResult: {
          isLoading: boolean,
          url: string,
          data: RecipeSeekResult
        }
      }
    }>,
    private route: ActivatedRoute,
  ) {
    this.recipe = new Recipe();
    for (let n = 0; n < 10; n++) {
      let s = new IngredientsSection();
      for (let m = 0; m < 100; m++) {
        s.ingredients.push(new Ingredient());
      }
      this.recipe.ingredientsSections.push(s);
    }

  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.url = params.url;

      this.findRecipe(this.url);
    });

    this.recipeSeekResult$.subscribe(state => {
      if (!state.data || !state.data.names)
        return;
      this.recipeName = state.data.names.length ? state.data.names[0] : '';

      this.recipe = new Recipe();
      for (let section of state.data.ingredientsSections) {
        let s = new IngredientsSection();
        for (let ingredient of section.ingredients) {
          let i = ingredient.candidates.length
            ? { ...ingredient.candidates[0] }
            : new Ingredient();
          s.ingredients.push(i);
        }
        this.recipe.ingredientsSections.push(s);
      }
    });
  }

  getSiteDomain(): string {
    var parts = this.url.split('/');
    if (parts.length < 3)
      return "";
    else
      return parts[2];
  }

  test() {
    console.log(this.recipe);
  }

  findRecipe(url: string) {
    this.links = undefined;
    this.imageLinks = undefined;

    this.store.dispatch(requestRecipeSeek({url}));
  }

  onCancel() {
    this.store.dispatch(cancelRecipeSeek({ url: this.url }));
  }
}

class LinkInfoPlus extends LinkInfo {
  public encodedUrl: string;
}
