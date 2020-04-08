using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeb.Pages
{
    public class ListEditBase:ComponentBase,IDisposable
    {
        [Parameter]public string PageType { get; set; }
        [Inject]AppState AppState { get; set; }


        public RenderFragment EditContent { get; set; }
        public RenderFragment ListContent { get; set; }


        protected override async Task OnInitializedAsync()
        {
            var pageType = PageType.ToLower();

            var editPage = $"BlazorWeb.Pages.{pageType}.Edit";
            var listPage = $"BlazorWeb.Pages.{pageType}.List";
            
            AppState.CurrentPageType = pageType;

            EditContent = CreateBasicContent(editPage);
            ListContent = CreateBasicContent(listPage);

            await SetData();
        }

        RenderFragment CreateBasicContent(string ptype) => builder =>
        {
            builder.OpenComponent(1, Type.GetType(ptype));
            builder.CloseComponent();

        };

        public async Task<bool> SetData()
        {

            AppState.SetListData();

            StateHasChanged();

            return true;
        }

        protected override void OnInitialized()
        {
            AppState.ModelUpdated += SetData;
        }

        public void Dispose()
        {
            AppState.ModelUpdated -= SetData;
        }
    }
}
