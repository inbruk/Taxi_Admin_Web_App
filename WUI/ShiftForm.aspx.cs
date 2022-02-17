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

    public partial class ShiftForm : System.Web.UI.Page
    {
        private const String CurrentShiftPhoneParamName = "shiftPhone";
        private const String CurrentShiftPhoneStoreName = "FinanceRecordsPage_CurrentShiftPhone";

        protected String CurrentShiftPhone
        {
            set
            {
                SessionStateWrapperLazy sessWrap = SessionStateWrapperLazy.Instance;
                sessWrap[CurrentShiftPhoneStoreName] = value;
            }
            get
            {
                SessionStateWrapperLazy sessWrap = SessionStateWrapperLazy.Instance;
                String result = (String) sessWrap[CurrentShiftPhoneStoreName];
                return result;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false) // первый вход на страницу
            {
                String strVal = Request.Params[CurrentShiftPhoneParamName];
                if (String.IsNullOrWhiteSpace(strVal) == false)
                {
                    CurrentShiftPhone = strVal;
                }
                else
                {
                    CurrentShiftPhone = null;
                }
            }
        }

        protected ShiftOrderView LoadData(String shiftPhone)
        {
            var webApiClient = WebApiClientHandler.Get();
            ShiftOrderView result =
                AsyncHelper.RunSync<ShiftOrderView>
                (
                    () => webApiClient.GetShiftOrderByRegistrationPhoneAsync(shiftPhone)
                );

            return result;
        }

        protected void SemiRefreshForm()
        {
            ShiftOrderView data = null;

            // здесь фильтром выступают данные переданные в параметрах запроса и сохраненные в сессии
            String shiftPhone = CurrentShiftPhone;
            if (shiftPhone == null)
            {
                data = null;
            }
            else
            {
                data = LoadData( shiftPhone );
            }

            // сформируем данные, которые можно прибиндить к данному виду форм
            List<ShiftOrderView> bindData = new List<ShiftOrderView>();
            bindData.Add(data);

            RadDataForm1.DataSource = bindData;

            // refresh map
            hfLatitude.Value  = data.Shift.Location.Latitude.ToString();
            hfLongitude.Value = data.Shift.Location.Longitude.ToString();
        }

        protected void RadDataForm1_NeedDataSource(object sender, RadDataFormNeedDataSourceEventArgs e)
        {
            SemiRefreshForm();
        }
    }
}
