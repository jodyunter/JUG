using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.ViewModels;

namespace BlazorWeb
{
    public class AppState
    {
        public string ServerURL { get { return "https://localhost:44304"; } }
        public string TeamListURL { get { return $"{ServerURL}/api/Team"; } }
        public string TeamFindURL { get { return $"{ServerURL}/api/Team/find"; } }
        public string TeamUpdateURL { get { return $"{ServerURL}/api/Team"; } }
        public string TeamDeleteURL { get { return $"{ServerURL}/api/Team/delete"; } }

        public ViewModel EditModel { get; set; }        

        public event Action ModelSelected;
        public event Func<Task<bool>> ModelUpdated;
        public event Func<Task<bool>> ReloadListData;               

        public void SetModelForEdit(ViewModel model)
        {
            EditModel = model;
            NotifyModelSelected();
        }

        public void SetListData()
        {
            NotifyReloadListData();
        }        

        public void UpdateModel()
        {
            NotifyModelUpdated();
        }

        private void NotifyModelSelected() => ModelSelected?.Invoke();
        private void NotifyModelUpdated() => ModelUpdated?.Invoke();                
        private void NotifyReloadListData() => ReloadListData?.Invoke();
        
    }
}
