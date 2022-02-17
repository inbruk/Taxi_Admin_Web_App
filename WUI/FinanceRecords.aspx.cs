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
    using Rapport.AuxiliaryTools.AspNetStoragesInClassLib;
    using Rapport.AuxiliaryTools.GenericsAndTemplates;

    using Rapport.Support.WebApiClient;
    using Rapport.Support.WebApiClient.DTO;

    public partial class FinanceRecords : System.Web.UI.Page
    {
        protected enum OwnerType
        {
            Unknown = 0,
            Driver  = 1,
            Company = 2
        }

        private const String CurrentDriverIdParamName = "driverId";
        private const String CurrentCompanyIdParamName = "companyId";

        private const String CurrentOwnerTypeStoreName = "FinanceRecordsPage_CurrentOwnerType";
        private const String CurrentDriverIdStoreName = "FinanceRecordsPage_CurrentDriverId";
        private const String CurrentCompanyIdStoreName = "FinanceRecordsPage_CurrentCompanyId";
        
        protected OwnerType CurrentOwnerType
        {
            set
            {
                SessionStateWrapperLazy sessWrap = SessionStateWrapperLazy.Instance;
                sessWrap[CurrentOwnerTypeStoreName] = value;
            }
            get
            {
                SessionStateWrapperLazy sessWrap = SessionStateWrapperLazy.Instance;
                OwnerType result = (OwnerType) sessWrap[CurrentOwnerTypeStoreName];
                return result;
            }
        }

        protected int CurrentDriverId
        {
            set
            {
                SessionStateWrapperLazy sessWrap = SessionStateWrapperLazy.Instance;
                sessWrap[CurrentDriverIdStoreName] = value;
            }
            get
            {
                SessionStateWrapperLazy sessWrap = SessionStateWrapperLazy.Instance;
                int result = (int) sessWrap[CurrentDriverIdStoreName];
                return result;
            }
        }

        protected int CurrentCompanyId
        {
            set
            {
                SessionStateWrapperLazy sessWrap = SessionStateWrapperLazy.Instance;
                sessWrap[CurrentCompanyIdStoreName] = value;
            }
            get
            {
                SessionStateWrapperLazy sessWrap = SessionStateWrapperLazy.Instance;
                int result = (int) sessWrap[CurrentCompanyIdStoreName];
                return result;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false) // первый вход на страницу
            {
            }

            CurrentOwnerType = OwnerType.Unknown;

            String strVal = Request.Params[CurrentDriverIdParamName];
            if (String.IsNullOrWhiteSpace(strVal) == false)
            {
                int temp;
                if (int.TryParse(strVal, out temp))
                {
                    CurrentOwnerType = OwnerType.Driver;
                    CurrentDriverId = temp;
                }
            }

            strVal = Request.Params[CurrentCompanyIdParamName];
            if (String.IsNullOrWhiteSpace(strVal) == false)
            {
                int temp;
                if (int.TryParse(strVal, out temp))
                {
                    CurrentOwnerType = OwnerType.Company;
                    CurrentCompanyId = temp;
                }
            }

            // заголовок надо заполнять при каждой перезагрузке страницы

            if( CurrentOwnerType== OwnerType.Driver)
                wlbRight.Title = "Платежи водителя с Id=" + CurrentDriverId.ToString();

            if (CurrentOwnerType == OwnerType.Company)
                wlbRight.Title = "Платежи компании с Id=" + CurrentCompanyId.ToString();
        }

        protected JsonPagedArray<RecordView> LoadDriverData(int webApiPageIndex, int driverId)
        {
            var webApiClient = WebApiClientHandler.Get();
            JsonPagedArray<RecordView> jpArray =
                AsyncHelper.RunSync<JsonPagedArray<RecordView>>
                (
                    () => webApiClient.GetFinanceRecordsListByDriverIdAsync(webApiPageIndex, driverId)
                );

            return jpArray;
        }

        //protected JsonPagedArray<RecordView> LoadCompanyData(int webApiPageIndex, int companyId)
        //{
        //    var webApiClient = WebApiClientHandler.Get();
        //    JsonPagedArray<RecordView> jpArray =
        //        AsyncHelper.RunSync<JsonPagedArray<RecordView>>
        //        (
        //            () => webApiClient.GetFinanceRecordsListByCompanyIdAsync(webApiPageIndex, companyId)
        //        );

        //    return jpArray;
        //}

        protected void SemiRefreshGrid()
        {
            int webApiPageIndex = mainGrid.CurrentPageIndex + 1;

            // здесь фильтром выступают данные переданные в параметрах запроса и сохраненные в сессии
            JsonPagedArray<RecordView> jpArray = null;

            if (CurrentOwnerType == OwnerType.Driver)
            {
                jpArray = LoadDriverData(webApiPageIndex, CurrentDriverId);
            }

            //if (CurrentOwnerType == OwnerType.Company)
            //{
            //    jpArray = LoadCompanyData(webApiPageIndex, CurrentCompanyId);
            //}
            
            if (jpArray != null)
            {
                // задаем количество страниц таким странным образом
                mainGrid.VirtualItemCount = jpArray.PageCount * mainGrid.PageSize;

                // конвертим 
                List<RecordView> data = jpArray.Items.ToList();

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

        protected void mainGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            SemiRefreshGrid();
        }
    }

}