import { Component } from '@angular/core';
import { HeroComponent } from "../hero/hero.component";
import { HeaderComponent } from "../header/header.component";
import { TrustSectionComponent } from "../trust-section/trust-section.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [HeroComponent, HeaderComponent, TrustSectionComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
