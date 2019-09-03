import { Component, OnInit, Input, Output, Inject, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WebSeekerService, LinkInfo, RecipeSeekResult } from '../service/web-seeker.service';
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

  public historyCursor: number = -1;
  public history: (() => string)[] = [];

  public links: LinkInfo[];
  public imageLinks: LinkInfoPlus[];

  recipeSeekResult$ = this.store.select(state => state.recipeManagement.recipeSeekResult);

  constructor(
    private webSeekerService: WebSeekerService,
    @Inject("BASE_URL") public baseUrl: string,
    private store: Store<{
      recipeManagement: {
        recipeSeekResult: {
          isLoading: boolean,
          url: string,
          data: RecipeSeekResult[]
        }
      }
    }>,
    private route: ActivatedRoute,
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.url = params.url;

      this.findRecipe(this.url);
    });
  }

  onFindRecipe()  {
    this.runWithHistory(this.url, u => this.findRecipe(u));
  }

  onFindImages() {
    this.runWithHistory(this.url, u => this.findImages(u));
  }

  runWithHistory(url: string, run: (url: string) => void) {
    this.historyCursor++;
    while (this.history.length > this.historyCursor)
      this.history.pop();
    let execRun = () => {
      run(url);
      return url;
    }
    this.history.push(execRun);
    execRun();
  }

  findRecipe(url: string) {
    this.links = undefined;
    this.imageLinks = undefined;

    this.store.dispatch(requestRecipeSeek({url}));
  }

  findImages(url: string) {
    this.links = undefined;
    this.imageLinks = undefined;
    this.webSeekerService.FindLinksWithImage(url).subscribe(result => {
      this.links = result;
    })
    this.webSeekerService.FindImageLinks(url).subscribe(result => {
      this.imageLinks = result as LinkInfoPlus[];
      this.imageLinks.map(l => l.encodedUrl = encodeURIComponent(l.url));
    });
  }

  seekWeb(url: string) {
    this.url = url;
    this.onFindImages();
  }

  onGoBack() {
    if (this.historyCursor == 0)
      return;
    this.historyCursor--;
    let run = this.history[this.historyCursor];
    this.url = run();
  }

  onGoForeward() {
    if (this.historyCursor + 1 >= this.history.length)
      return;
    this.historyCursor++;
    let run = this.history[this.historyCursor];
    this.url = run();
  }

  onCancel() {
    this.store.dispatch(cancelRecipeSeek({ url: this.url }));
  }
}

class LinkInfoPlus extends LinkInfo {
  public encodedUrl: string;
}
