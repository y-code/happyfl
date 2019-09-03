import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-recipe-seeker-index',
  templateUrl: './recipe-seeker-index.component.html',
  styleUrls: ['./recipe-seeker-index.component.css']
})
export class RecipeSeekerIndexComponent implements OnInit {

  readonly URL_BBCGoodFood: string = "https://www.bbcgoodfood.com/";
  readonly URL_allrecipes: string = "https://www.allrecipes.com/";
  readonly URL_JamieOliver: string = "https://www.jamieoliver.com/";
  readonly URL_delish: string = "https://www.delish.com/";

  customSiteForm: FormGroup;

  @ViewChild('modalContent', { static: false })
  modalContent;

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    @Inject(DOCUMENT) public document: Document,
    private sanitizer: DomSanitizer,
    private modalService: NgbModal
  ) {
    this.customSiteForm = this.formBuilder.group({
      url: '',
    });
  }

  ngOnInit() {
  }

  onIconClick(url: string) {
    this.modalService.open(this.modalContent, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      console.log(`Closed with: ${result}`);
      if (result === 'Open click') {
        this.openUrl(url);
      }
    }, (reason) => {
      console.log(`Dismissed ${this.getDismissReason(reason)}`);
    });
  }

  openUrl(url: string) {
    window.open(url, '_blank');
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }

  onSubmit() {
    var url = this.customSiteForm.value.url;
    this.router.navigate([ '/recipe-seeker', url ]);
    this.customSiteForm.reset();
  }

  sanitize(url: string): SafeUrl {
    return this.sanitizer.bypassSecurityTrustUrl(url);
  }

  getLauncherScript(): SafeUrl {
    return this.sanitize(`javascript:(function(){var url='${this.document.location.origin}/RecipeSeekerLauncher/main.js';if(!url.match(/\\?/))url+='?t='+(new Date()).getTime();var d=document;var e=d.createElement('script');e.charset='utf-8';e.src=url;d.getElementsByTagName('head')[0].appendChild(e);})();`);
  }
}
