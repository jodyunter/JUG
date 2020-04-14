using BlazorWeb.Shared.Services.DTO;
using Microsoft.AspNetCore.Components;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWeb.Pages.game
{
    public partial class EditBase:ComponentBase,IDisposable
    {

        [Parameter] public GameCreateViewModel EditObject { get; set; } = new GameCreateViewModel();
        [Inject] AppState AppState { get; set; }
        [Inject] HttpClient Http { get; set; }


        public  async Task<bool> CreateNew()
        {
            EditObject = new GameCreateViewModel();

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
            //need to edit the model appropriately
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
