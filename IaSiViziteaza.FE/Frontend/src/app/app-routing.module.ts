import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { AdminComponent } from './admin/admin.component';
import { UpdateComponent } from './update/update.component';

const routes: Routes = [
  {path: '', component: HomepageComponent},
  {path: 'attrtype', loadChildren: () => import('./atype/atype.module').then(m => m.ATypeModule)},
  {path: 'attractions', loadChildren: () => import('./attraction/attraction.module').then(m => m.AttractionModule)},
  {path: 'register' , component: RegisterComponent},
  {path: 'login' , component: LoginComponent},
  {path: 'admin' , component: AdminComponent},
  {path: 'update', component: UpdateComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
