import { Component, Injector } from '@angular/core';
import { PagedListingComponentBase } from '@shared/paged-listing-component-base';
import { CountryDto, CountryServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CreateCountryDialogComponent } from './create-country/create-country-dialog.component';
import { EditCountryDialogComponent } from './edit-country/edit-country-dialog.component';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html'
})
export class CountryComponent extends PagedListingComponentBase<CountryDto> {
  countries: CountryDto[] = [];

  constructor(
    injector: Injector,
    private _countryService: CountryServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  createCountry(): void {
    this.showCreateOrEditCountryDialog();
  }

  editCountry(country: CountryDto): void {
    this.showCreateOrEditCountryDialog(country.id);
  }

  protected list(): void {

    this._countryService.getAll()
      .pipe(
        finalize(() => {
          this.isTableLoading = false;
        })
      )
      .subscribe((result: CountryDto[]) => {
        this.countries = result;
      });
  }

  protected delete(country: CountryDto): void {
    abp.message.confirm(
      this.l('CountryDeleteWarningMessage', country.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._countryService.delete(country.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  private showCreateOrEditCountryDialog(id?: string): void {
    let createOrEditCountryDialog: BsModalRef;
    if (!id) {
      createOrEditCountryDialog = this._modalService.show(
        CreateCountryDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditCountryDialog = this._modalService.show(
        EditCountryDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditCountryDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
