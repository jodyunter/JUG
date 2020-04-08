using Microsoft.AspNetCore.Components;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWeb.Pages.team
{
    public class ListBase:ComponentBase
    {
        public TeamViewModel[] data;
        [Inject]AppState AppState { get; set; }
        [Inject]HttpClient Http { get; set; }
        protected override async Task OnInitializedAsync()
        {

            await SetData();
        }

        public async Task<bool> SetData()
        {
            data = await Http.GetJsonAsync<TeamViewModel[]>($"{AppState.ListURL}");

            StateHasChanged();

            return true;
        }
        public async Task<bool> DeleteClick(long id)
        {
            var deleteObject = new ViewModel() { Id = id };

            await HttpClientJsonExtensions.PostJsonAsync(Http, $"{AppState.DeleteURL}", deleteObject);

            await SetData();

            return true;
        }

        public async Task<bool> EditClick(long id)
        {
            var selectedObject = await Http.GetJsonAsync<TeamViewModel>($"{AppState.FindURL}/{id}");

            AppState.SetModelForEdit(selectedObject);

            return true;
        }

        protected override void OnInitialized()
        {
            AppState.ReloadListData += SetData;
        }

        public void Dispose()
        {
            AppState.ReloadListData -= SetData;
        }
    }
}
