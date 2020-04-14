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
        public string ListURL { get { return $"{ServerURL}/api/{CurrentPageType}"; } }
        public string FindURL { get { return $"{ServerURL}/api/{CurrentPageType}/find"; } }
        public string UpdateURL { get { return $"{ServerURL}/api/{CurrentPageType}"; } }
        public string DeleteURL { get { return $"{ServerURL}/api/{CurrentPageType}/delete"; } }
        public string DataForCreateURL { get { return $"{ServerURL}/api/{CurrentPageType}/dataforcreate"; } }

        public string CurrentPageType { get; set; }
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
