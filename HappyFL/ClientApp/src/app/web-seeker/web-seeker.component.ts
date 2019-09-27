import { Component, OnInit, Input, Output, Inject } from '@angular/core';
import { WebSeekerService, LinkInfo } from '../service/web-seeker/web-seeker.service';

@Component({
  selector: 'app-web-seeker',
  templateUrl: './web-seeker.component.html',
  styleUrls: ['./web-seeker.component.css']
})
export class WebSeekerComponent implements OnInit {

  @Input()
  @Output()
  public url: string;

  public historyCursor: number = -1;
  public history: (() => string)[] = [];

  public links: LinkInfo[];
  public imageLinks: LinkInfoPlus[];

  constructor(
    private webSeekerService: WebSeekerService,
    @Inject("BASE_URL") public baseUrl: string
  ) { }

  ngOnInit() {
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
}

class LinkInfoPlus extends LinkInfo {
  public encodedUrl: string;
}