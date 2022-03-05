import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { CountryServiceProxy, CreateCountryDto } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-create-country-dialog',
  templateUrl: './create-country-dialog.component.html'
})
export class CreateCountryDialogComponent extends AppComponentBase {
saving = false;
country = new CreateCountryDto();

@Output() onSave = new EventEmitter<any>();

constructor(
  injector: Injector,
  public _countryService: CountryServiceProxy,
  public bsModalRef: BsModalRef
) {
  super(injector);
}

save(): void {
  this.saving = true;

  this._countryService.create(this.country).subscribe(
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
