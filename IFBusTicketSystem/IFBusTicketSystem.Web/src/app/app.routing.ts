import { Routes, RouterModule } from '@angular/router';

import { RegistrationComponent } from './registration/index';

const appRoutes: Routes = [
  { path: 'register', component: RegistrationComponent },
  { path: 'home', redirectTo: '' },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);