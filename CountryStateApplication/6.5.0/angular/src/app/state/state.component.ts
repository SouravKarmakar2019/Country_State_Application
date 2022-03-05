import { Component, Injector } from '@angular/core';
import { PagedListingComponentBase } from '@shared/paged-listing-component-base';
import { StateDto, StateServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CreateStateDialogComponent } from './state-create/create-state-dialog.component';
import { EditStateDialogComponent } from './state-edit/edit-state-dialog.component';

@Component({
  selector: 'app-state',
  templateUrl: './state.component.html'
})
export class StateComponent extends PagedListingComponentBase<StateDto> {
  states: StateDto[] = [];

  constructor(
    injector: Injector,
    private _stateService: StateServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  createState(): void {
    this.showCreateOrEditStateDialog();
  }

  editState(state: StateDto): void {
    this.showCreateOrEditStateDialog(state.id);
  }

  protected list(): void {

    this._stateService.getAll()
      .pipe(
        finalize(() => {
          this.isTableLoading = false;
        })
      )
      .subscribe((result: StateDto[]) => {
        this.states = result;
      });
  }

  protected delete(state: StateDto): void {
    abp.message.confirm(
      this.l('StateDeleteWarningMessage', state.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._stateService.delete(state.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  private showCreateOrEditStateDialog(id?: string): void {
    let createOrEditStateDialog: BsModalRef;
    if (!id) {
      createOrEditStateDialog = this._modalService.show(
        CreateStateDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditStateDialog = this._modalService.show(
        EditStateDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditStateDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
