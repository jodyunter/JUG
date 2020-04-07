using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeb
{
    public class AppState
    {
        public object EditModel { get; set; }
        public object[] ListData { get; set; }

        public event Action ModelSelected;
        public event Action ListDataChanged;
        public event Func<Task<bool>> ModelReadyToSave;
        
        public event Func<long, Task<bool>> ModelSelectedToEdit;
        public event Func<long, Task<bool>> ModelSelectedToDelete;

        public void SetModelForEdit(object model)
        {
            EditModel = model;
            NotifyModelSelected();
        }

        public void SetModelForUpdate(object model)
        {
            EditModel = model;
            NotifyModelReadyForUpdate();
        }

        public void ChooseModelForEdit(long id)
        {
            NotifyModelChosenForEdit(id);
        }

        public void ChooseModelForDelete(long id)
        {
            NotifyModelChosenForDelete(id);
        }

        public void SetListData(object[] data)
        {
            ListData = data;            

            NotifyListDataChanged();
        }

        private void NotifyModelSelected() => ModelSelected?.Invoke();
        private void NotifyModelReadyForUpdate() => ModelReadyToSave?.Invoke();
        private void NotifyModelChosenForEdit(long id) => ModelSelectedToEdit?.Invoke(id);
        private void NotifyModelChosenForDelete(long id) => ModelSelectedToDelete?.Invoke(id);
        private void NotifyListDataChanged() => ListDataChanged?.Invoke();
    }
}
