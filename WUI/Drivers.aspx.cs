namespace Rapport.Support.WUI
{
    using System;
    using System.Data;
    using System.Threading.Tasks;
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Security;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;

    using Telerik.Web.UI;

    using Rapport.AuxiliaryTools.AsyncHelper;
    using Rapport.AuxiliaryTools.ConfigurationEngine;
    using Rapport.AuxiliaryTools.WabApiTools;
    using Rapport.BusinessTools.DirectoryEngine;

    using Rapport.Support.WebApiClient;
    using Rapport.Support.WebApiClient.DTO;

    public partial class Drivers : System.Web.UI.Page
    {
        protected struct FilterValues
        {
            public int[] profileStateIds;
            public String tin;
        }

        protected FilterValues GetFilterValuesInUsefulFormat()
        {
            // получаем значение фильтра по состоянию водителя            
            int[] profStateIds = rcbProfileStatus.CheckedItems.Select(x => int.Parse(x.Value)).ToArray<int>();
            if (profStateIds.Length <= 0)
            {
                profStateIds = null;
            }

            // получаем ИНН из фильтра
            String tin = rtbxTIN.Text;

            // набиваем значениями из фильтров результат
            FilterValues result = 
                new FilterValues()
                {
                    profileStateIds = profStateIds
                };

            return result;
        }

        protected JsonPagedArray<DriverView> LoadGridData(int webApiPageIndex, int[] profileStateIds, String tin)
        {
            var webApiClient = WebApiClientHandler.Get();
            JsonPagedArray<DriverView> jpArray =
                AsyncHelper.RunSync<JsonPagedArray<DriverView>>
                (
                    () => webApiClient.GetDriversListAsync(webApiPageIndex, profileStateIds, tin)
                );

            return jpArray;
        }

        protected void SemiRefreshGrid()
        {
            int webApiPageIndex = mainGrid.CurrentPageIndex + 1;
            FilterValues filterValues = GetFilterValuesInUsefulFormat();
            
            JsonPagedArray<DriverView> jpArray = 
                LoadGridData(webApiPageIndex, filterValues.profileStateIds, filterValues.tin);

            if (jpArray != null)
            {
                // задаем количество страниц таким странным образом
                mainGrid.VirtualItemCount = jpArray.PageCount * mainGrid.PageSize;

                // конвертим 
                List<DriverView> data = jpArray.Items.ToList();

                // биндим их в грид
                mainGrid.DataSource = data;
            }
        }

        protected void RrefreshGridAfterFiltersChanges()
        {
            mainGrid.CurrentPageIndex = 0;
            SemiRefreshGrid();
            mainGrid.DataBind();
        }

        protected void RefreshFilters()
        {
            List<DirectoryItem> profileStateValues = DirectoryPool.GetDirectoryValuesById( DirectoryIds.ProfileState );
            rcbProfileStatus.DataSource = profileStateValues;
            rcbProfileStatus.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

            }
        }

        protected void mainGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RefreshFilters();
            SemiRefreshGrid();
        }

        protected void rbtnApply_Click(object sender, EventArgs e)
        {
            RrefreshGridAfterFiltersChanges();
        }

        protected void rbtnClear_Click(object sender, EventArgs e)
        {
            rcbProfileStatus.ClearCheckedItems();
            rcbProfileStatus.ClearSelection();
            rtbxTIN.Text = "";

            RrefreshGridAfterFiltersChanges();
        }
    }
}