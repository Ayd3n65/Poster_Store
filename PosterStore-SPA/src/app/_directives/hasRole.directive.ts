import { Directive, OnInit, Input, ViewContainerRef, TemplateRef } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Directive({
  selector: '[appHasRole]'
})
export class HasRoleDirective implements OnInit {
  @Input() appHasRole: string[];
  isVisible = false;
  constructor(
    private viewContainerRef: ViewContainerRef,
    private templateRef: TemplateRef<any>,
    private authService: AccountService) { }

  ngOnInit() {
    const userRoles = this.authService.decodedToken.role as Array<string>;
    // if no roles clear the view container ref
    if (!userRoles) {
      this.viewContainerRef.clear();
    }

    // if user has role needed then render the element
    if (this.authService.roleMatch(this.appHasRole)) {
      if (!this.isVisible) {
        this.isVisible = true;
        this.viewContainerRef.createEmbeddedView(this.templateRef);
      } else {
        this.isVisible = false;
        this.viewContainerRef.clear();
      }
    }
  }
}
