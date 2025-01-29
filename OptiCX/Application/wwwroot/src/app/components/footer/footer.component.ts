import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css'
})
export class FooterComponent {
  currentYear = new Date().getFullYear()
  quickLinks = [
    { name: "Home", route: "/" },
    { name: "Features", route: "/features" },
    { name: "Pricing", route: "/pricing" },
    { name: "About Us", route: "/about" },
  ]
  socialLinks = [
    { name: "Twitter", href: "#" },
    { name: "LinkedIn", href: "#" },
    { name: "Facebook", href: "#" },
  ]
}
