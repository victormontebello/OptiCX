import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  menuItems = [
    { name: "Features", route: "/features" },
    { name: "Pricing", route: "/pricing" },
    { name: "About", route: "/about" },
    { name: "Contact", route: "/contact" },
  ]
}
