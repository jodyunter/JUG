using Microsoft.AspNetCore.Components;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWeb.Pages.team
{
    public partial class EditBase:ComponentBase,IDisposable
    {

        [Parameter] public TeamViewModel EditObject { get; set; } = new TeamViewModel();
        [Inject] AppState AppState { get; set; }
        [Inject] HttpClient Http { get; set; }


        public  async Task<bool> CreateNew()
        {
            EditObject = new TeamViewModel();

            return true;
        }

        public async Task<bool> CreateOrUpdateModel()
        {

            await HttpClientJsonExtensions.PostJsonAsync(Http, $"{AppState.UpdateURL}", EditObject);

            AppState.UpdateModel();

            return true;

        }

        public void ModelSelected()
        {
            EditObject = (TeamViewModel)AppState.EditModel;
            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            AppState.ModelSelected += ModelSelected;
        }

        public void Dispose()
        {
            AppState.ModelSelected -= ModelSelected;
        }
    }
}
