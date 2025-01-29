import { Component } from '@angular/core';
import { FeaturesComponent } from "../features/features.component";
import { HeroComponent } from "../hero/hero.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [FeaturesComponent, HeroComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
