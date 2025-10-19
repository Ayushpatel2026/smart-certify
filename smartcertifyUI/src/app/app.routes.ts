import { Routes } from '@angular/router';

export const routes: Routes = [
    // default route redirects to home
    {
        path: '', redirectTo: 'home', pathMatch: 'full'
    },
    {
        path: 'home', loadChildren: () => import('./components/home/home').then(m => m.HomeComponent)
    },
    {
        path: 'about', loadChildren: () => import('./pages/about/about').then(m => m.AboutComponent)
    },
    {
        path: 'contact-us', loadChildren: () => import('./pages/contact-us/contact-us').then(m => m.ContactUsComponent)
    },
    // redirect to home for any unknown paths
    {
        path: '**', redirectTo: 'home'
    }
];
