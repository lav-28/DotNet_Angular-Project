import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { HomeComponent } from './components/home/home.component';
import { PrivacyComponent } from './components/privacy/privacy.component';
import { DegreeListComponent } from './components/degree/degree-list/degree-list.component';
import { DegreeDetailsComponent } from './components/degree/degree-details/degree-details.component';
import { DegreeAddComponent } from './components/degree/degree-add/degree-add.component';
import { FormsModule } from '@angular/forms';
import { DegreeUpdateComponent } from './components/degree/degree-update/degree-update.component';
import { CapitalizePipe } from './pipes/capitalize.pipe';
import { StreamListComponent } from './components/stream/stream-list/stream-list.component';
import { StreamDetailsComponent } from './components/stream/stream-details/stream-details.component';
import { StreamAddComponent } from './components/stream/stream-add/stream-add.component';
import { StreamUpdateComponent } from './components/stream/stream-update/stream-update.component';
import { GraduatetraineeListComponent } from './components/graduatetrainee/graduatetrainee-list/graduatetrainee-list.component';
import { GraduatetraineeDetailsComponent } from './components/graduatetrainee/graduatetrainee-details/graduatetrainee-details.component';
import { GraduatetraineeAddComponent } from './components/graduatetrainee/graduatetrainee-add/graduatetrainee-add.component';
import { GraduatetraineeUpdateComponent } from './components/graduatetrainee/graduatetrainee-update/graduatetrainee-update.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    PrivacyComponent,
    DegreeListComponent,
    DegreeDetailsComponent,
    DegreeAddComponent,
    DegreeUpdateComponent,
    CapitalizePipe,
    StreamListComponent,
    StreamDetailsComponent,
    StreamAddComponent,
    StreamUpdateComponent,
    GraduatetraineeListComponent,
    GraduatetraineeDetailsComponent,
    GraduatetraineeAddComponent,
    GraduatetraineeUpdateComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
