import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { CountryDto, CountryServiceProxy, StateDto, StateServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-edit-state-dialog',
  templateUrl: './edit-state-dialog.component.html'
})
export class EditStateDialogComponent extends AppComponentBase
implements OnInit {
saving = false;
state = new StateDto();
id: string;
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
  this.getCounties();
  this._stateService.get(this.id).subscribe((result) => {
    this.state = result;
  });
}

getCounties(){
  this._countryService.getAll().subscribe(
    (result) => {
      this.countries = result;
    });
}

save(): void {
  this.saving = true;

  this._stateService.update(this.state).subscribe(
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
