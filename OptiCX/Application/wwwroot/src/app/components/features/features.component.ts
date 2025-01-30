import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

interface Feature {
  icon: string
  title: string
  description: string
}
@Component({
  selector: 'app-features',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './features.component.html',
  styleUrl: './features.component.css'
})

export class FeaturesComponent {
  heroTitle = "Elevate Your Customer Experience"
  heroDescription =
    "Our cutting-edge CX application helps you understand, engage, and delight your customers like never before."
  features: Feature[] = [
    {
      icon: "👥",
      title: "Customer Insights",
      description: "Gain deep understanding of your customers' needs and behaviors.",
    },
    {
      icon: "📊",
      title: "Analytics Dashboard",
      description: "Visualize key metrics and trends to make data-driven decisions.",
    },
    {
      icon: "💬",
      title: "Omnichannel Support",
      description: "Provide seamless support across multiple communication channels.",
    },
    {
      icon: "⚡",
      title: "AI-Powered Automation",
      description: "Streamline processes and enhance efficiency with intelligent automation.",
    },
  ]
}
