import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { PrivacyComponent } from './components/privacy/privacy.component';
import { DegreeListComponent } from './components/degree/degree-list/degree-list.component';
import { DegreeDetailsComponent } from './components/degree/degree-details/degree-details.component';
import { DegreeAddComponent } from './components/degree/degree-add/degree-add.component';
import { DegreeUpdateComponent } from './components/degree/degree-update/degree-update.component';
import { StreamListComponent } from './components/stream/stream-list/stream-list.component';
import { StreamDetailsComponent } from './components/stream/stream-details/stream-details.component';
import { StreamAddComponent } from './components/stream/stream-add/stream-add.component';
import { StreamUpdateComponent } from './components/stream/stream-update/stream-update.component';
import { GraduatetraineeListComponent } from './components/graduatetrainee/graduatetrainee-list/graduatetrainee-list.component';
import { GraduatetraineeDetailsComponent } from './components/graduatetrainee/graduatetrainee-details/graduatetrainee-details.component';
import { GraduatetraineeAddComponent } from './components/graduatetrainee/graduatetrainee-add/graduatetrainee-add.component';
import { GraduatetraineeUpdateComponent } from './components/graduatetrainee/graduatetrainee-update/graduatetrainee-update.component';

const routes: Routes = [
  {path:'', redirectTo:'home', pathMatch:'full'},
  {path:'home', component:HomeComponent},
  {path:'privacy', component:PrivacyComponent},
  {path:'degrees', component:DegreeListComponent},
  {path:'degree/add', component:DegreeAddComponent},
  {path:'degree/update/:id', component:DegreeUpdateComponent},
  {path:'degrees/details/:id', component:DegreeDetailsComponent},
  {path:'streams', component:StreamListComponent},
  {path:'stream/add', component:StreamAddComponent},
  {path:'stream/update/:id', component:StreamUpdateComponent},
  {path:'stream/details/:id', component:StreamDetailsComponent},
  {path:'trainees', component:GraduatetraineeListComponent},
  {path:'graduate-trainee/details/:id', component:GraduatetraineeDetailsComponent},
  {path:'trainee/add', component:GraduatetraineeAddComponent},
  {path:'graduate-trainee/update/:id', component:GraduatetraineeUpdateComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
