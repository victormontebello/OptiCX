import { Component } from '@angular/core';

@Component({
  selector: 'app-hero',
  standalone: true,
  imports: [],
  templateUrl: './hero.component.html',
  styleUrl: './hero.component.css'
})
export class HeroComponent {
  heroTitle = "Elevate Your Customer Experience"
  heroDescription =
    "Our cutting-edge CX application helps you understand, engage, and delight your customers like never before."
}
