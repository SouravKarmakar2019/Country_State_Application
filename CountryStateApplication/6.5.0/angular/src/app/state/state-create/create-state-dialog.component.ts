import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { CountryDto, CountryServiceProxy, CreateStateDto, StateServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-create-state-dialog',
  templateUrl: './create-state-dialog.component.html'
})
export class CreateStateDialogComponent  extends AppComponentBase implements OnInit {
  saving = false;
  state = new CreateStateDto();
  countries: CountryDto[] = [];
  
  @Output() onSave = new EventEmitter<any>();
  
  constructor(
    injector: Injector,
    public _stateService: StateServiceProxy,
    public _countryService: CountryServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._countryService.getAll().subscribe(
      (result) => {
        this.countries = result;
      });
  }
  
  save(): void {
    this.saving = true;
  
    this._stateService.create(this.state).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
  