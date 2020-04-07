using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeb
{
    public class AppState
    {
        public object EditModel { get; set; }

        public event Action ModelSelected;
        public event Func<Task<bool>> ModelReadyToSave;

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

        private void NotifyModelSelected() => ModelSelected?.Invoke();
        private void NotifyModelReadyForUpdate() => ModelReadyToSave?.Invoke();
    }
}
