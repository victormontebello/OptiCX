import { Component } from '@angular/core';
import { Feature } from '../../interfaces/feature';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-trust-section',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './trust-section.component.html',
  styleUrl: './trust-section.component.css'
})
export class TrustSectionComponent {
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
