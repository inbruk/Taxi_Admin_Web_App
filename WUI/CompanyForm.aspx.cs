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

    public partial class CompanyForm : System.Web.UI.Page
    {
        private const String CurrentCompanyIdParamName = "companyId";
        private const String CurrentCompanyIdStoreName = "FinanceRecordsPage_CurrentCompanyId";

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
                int result = (int)sessWrap[CurrentCompanyIdStoreName];
                return result;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false) // первый вход на страницу
            {
                String strVal = Request.Params[CurrentCompanyIdParamName];
                if (String.IsNullOrWhiteSpace(strVal) == false)
                {
                    int temp;
                    if (int.TryParse(strVal, out temp))
                    {
                        CurrentCompanyId = temp;
                    }
                }
            }
        }

        protected CompanyView LoadData(int? companyId)
        {
            var webApiClient = WebApiClientHandler.Get();
            CompanyView result =
                AsyncHelper.RunSync<CompanyView>
                (
                    () => webApiClient.GetCompanyByIdAsync(companyId)
                );

            return result;
        }

        protected void SemiRefreshForm()
        {            
            CompanyView data = null;

            // здесь фильтром выступают данные переданные в параметрах запроса и сохраненные в сессии
            int? companyId = CurrentCompanyId;
            if (companyId == null)
            {
                data = null;
            }
            else
            {
                data = LoadData( companyId );
            }

            // сформируем данные, которые можно прибиндить к данному виду форм
            List<CompanyView> bindData = new List<CompanyView>();
            bindData.Add(data);

            RadDataForm1.DataSource = bindData;
        }

        protected void RadDataForm1_NeedDataSource(object sender, RadDataFormNeedDataSourceEventArgs e)
        {
            SemiRefreshForm();
        }
    }
}