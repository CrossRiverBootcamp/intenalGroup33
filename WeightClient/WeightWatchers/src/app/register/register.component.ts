import { compileDeclarePipeFromMetadata } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Form, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscriber } from '../Models/Subscriber';
import { RegisterService } from './register.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  
  registerForm:FormGroup;

  constructor(private formBuilder:FormBuilder, private registerService:RegisterService) {
    this.registerForm=this.createFormGroup(formBuilder);
   }

  createFormGroup(formBuilder:FormBuilder){
    return  formBuilder.group({
        email:[,[Validators.email,Validators.required],],
        password:[,[Validators.required],],
        firstName:[,[Validators.required],],
        lastName:[,[Validators.required],],
        height:[,[Validators.required,Validators.pattern('[0-9]*')],],
    });
  }

  ngOnInit(): void {
  }

  onSubmit(){
 const newSubscriber:Subscriber=
 Object.assign({},this.registerForm.value);
 this.registerService.AddSubscriber(newSubscriber);
 console.log(newSubscriber);
 this.registerForm.reset();
 }
 }
 

