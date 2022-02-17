namespace Rapport.Support.WUI
{
    using System;
    using System.Data;
    using System.Drawing;
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
    using AutoMapper;

    using Rapport.AuxiliaryTools.AsyncHelper;
    using Rapport.AuxiliaryTools.ConfigurationEngine;
    using Rapport.AuxiliaryTools.WabApiTools;
    using Rapport.BusinessTools.DirectoryEngine;
    using Rapport.AuxiliaryTools.AspNetStoragesInClassLib;
    using Rapport.AuxiliaryTools.GenericsAndTemplates;

    using Rapport.Support.WebApiClient;
    using Rapport.Support.WebApiClient.DTO;
    using Rapport.Support.WebApiClient.DirectoryValues;

    public partial class VehicleForm : System.Web.UI.Page
    {
        private const String CurrentVehicleIdParamName = "vehicleId";
        private const String CurrentVehicleIdStoreName = "VehicleFormPage_CurrentVehicleId";
        private const String CurrentFormDataStoreName = "VehicleFormPage_CurrentFormData";
        private const String ProfileStateValuesStoreName = "VehicleFormPage_ProfileStateValues";
        private const String NextProfileStateIdStoreName = "VehicleFormPage_NextProfileStateId";
        private const String IsMapperInitializedStoreName = "VehicleFormPage_IsMapperInitialized";

        protected int CurrentVehicleId
        {
            set
            {
                SessionStateWrapperLazy sessWrap = SessionStateWrapperLazy.Instance;
                sessWrap[CurrentVehicleIdStoreName] = value;
            }
            get
            {
                SessionStateWrapperLazy sessWrap = SessionStateWrapperLazy.Instance;
                int result = (int)sessWrap[CurrentVehicleIdStoreName];
                return result;
            }
        }

        private List<VehicleView> _currentFormData = null;
        protected List<VehicleView> CurrentFormData // не храним в сессии чтобы не прозевать изменения в БД
        {
            set
            {
                _currentFormData = value;
            }
            get
            {
                return _currentFormData;
            }
        }

        protected List<DirectoryItem> ProfileStateValues
        {
            get
            {
                List<DirectoryItem> result = DirectoryPool.GetDirectoryValuesById(DirectoryIds.ProfileState);
                return result;
            }
        }

        protected long? NextProfileStateId
        {
            set
            {
                SessionStateWrapperLazy sessWrap = SessionStateWrapperLazy.Instance;
                sessWrap[NextProfileStateIdStoreName] = value;
            }
            get
            {
                SessionStateWrapperLazy sessWrap = SessionStateWrapperLazy.Instance;
                long? result = (long?) sessWrap[NextProfileStateIdStoreName];
                return result;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false) // первый вход на страницу
            {
            }

            // инициализируем маппер для черновых данных с цветами
            Mapper.Reset();
            Mapper.Initialize(cfg => {
                cfg.CreateMap<VehicleView, VehicleViewWithColors>();
            });

            // вытащим ид из параметров и кэшируем его
            String strVal = Request.Params[CurrentVehicleIdParamName];
            if (String.IsNullOrWhiteSpace(strVal) == false)
            {
                int temp;
                if (int.TryParse(strVal, out temp))
                {
                    CurrentVehicleId = temp;
                }
            }
        }

        protected List<VehicleView> CheckStorageAndLoadData()
        {
            List<VehicleView> bindData = null;

            // здесь фильтром выступают данные переданные в параметрах запроса и сохраненные в сессии
            int? vehicleId = CurrentVehicleId;

            if (vehicleId == null) // если нет ида, то вернем пустоту
            {
                bindData = null;
            }
            else // если ид есть
            {
                bindData = CurrentFormData; // пытаемся загрузить данные из кэша
                if (bindData == null ) // если данных в кэше нет 
                {
                    // то грузим данные из веб апи сервиса
                    var webApiClient = WebApiClientHandler.Get();
                    VehicleView data =
                        AsyncHelper.RunSync<VehicleView>
                        (
                            () => webApiClient.GetVehicleByIdAsync(vehicleId)
                        );

                    bindData = new List<VehicleView>();
                    bindData.Add(data);

                    // сохраняем данные в кэш для следующего раза
                    CurrentFormData = bindData;
                }
            }

            return bindData;
        }

        protected void RefreshChangeProfileStateButtons()
        {
            if ( CurrentFormData!=null && CurrentFormData[0]!=null )
            {
                long? nextProfStateId = null;
                String nextProfStateName = null;

                ProfileState currProfileState = (ProfileState) CurrentFormData[0].ProfileState.Id;

                var webApiClient = WebApiClientHandler.Get();
                webApiClient.GetNextProfileStateIdAndName(currProfileState, out nextProfStateId, out nextProfStateName);
                if (nextProfStateId != null)
                {
                    NextProfileStateId = (long)nextProfStateId;                    
                    RbChangeProfileState.Visible = true;
                    RbChangeProfileState.Text = "Сменить статус на " + nextProfStateName;
                }
                else
                {
                    RbChangeProfileState.Visible = false;
                }

                if( currProfileState == ProfileState.Updated ||
                    currProfileState == ProfileState.Verificating ||
                    currProfileState == ProfileState.Approved )
                {
                    RbRejectIt.Visible = true;
                }
                else
                {
                    RbRejectIt.Visible = false;
                }
            }
        }

        protected void RefreshActualValuesForm()
        {
            RdfActualValues.DataSource = CheckStorageAndLoadData();
        }


        protected class VehicleViewWithColors : VehicleView
        {
            public Color RlDraftColorNameForeColor { set; get; }
            public Color RlDraftBodyNameForeColor { set; get; }
            public Color RlDraftModelFullNameForeColor { set; get; }
            public Color RlDraftManufactureYearForeColor { set; get; }
            public Color RlDraftOwnerForeColor { set; get; }
            public Color RlDraftRegistrationDateForeColor { set; get; }
            public Color RlDraftRegistrationCityNameForeColor { set; get; }
            public Color RlDraftLicenseNumberForeColor { set; get; }
            public Color RlDraftLicenseOwnerNameForeColor { set; get; }
            public Color RlDraftLicenseStartDateForeColor { set; get; }
            public Color RlDraftLicenseEndDateForeColor { set; get; }
            public Color RlDraftLicenseAuthorityIssuedForeColor { set; get; }
            public Color RlDraftPossessionNameForeColor { set; get; }
            public Color RlDraftInsuranceNumberForeColor { set; get; }
            public Color RlDraftInsuranceAuthorityIssuedForeColor { set; get; }
            public Color RlDraftInsuranceEndDateForeColor { set; get; }
            public Color RlDraftInspectionDateForeColor { set; get; }
        }

        protected void RefreshDraftValuesForm()
        {
            // покрасим красным те черновые поля, которые отличаются от чистовых
            List<VehicleView> bindData = (List<VehicleView>)CurrentFormData;
            if (bindData != null)
            {
                // перенесем данные в расширенную версию данных
                VehicleView vehView = bindData[0];
                VehicleViewWithColors vehViewWithColors = Mapper.Map<VehicleViewWithColors>(vehView);

                // заполним поля отвечающие за цвет строк черновика
                if ( vehViewWithColors.Color!=null && vehViewWithColors.DraftColor != null && vehViewWithColors.Color.Id != vehViewWithColors.DraftColor.Id)
                    vehViewWithColors.RlDraftColorNameForeColor = Color.Red;
                else
                    vehViewWithColors.RlDraftColorNameForeColor = Color.Black;

                if (vehViewWithColors.Body != null && vehViewWithColors.DraftBody != null && vehViewWithColors.Body.Id != vehViewWithColors.DraftBody.Id)
                    vehViewWithColors.RlDraftBodyNameForeColor = Color.Red;
                else
                    vehViewWithColors.RlDraftBodyNameForeColor = Color.Black;

                if (vehViewWithColors.Model != null && vehViewWithColors.DraftModel != null && vehViewWithColors.Model.Id != vehViewWithColors.DraftModel.Id)
                    vehViewWithColors.RlDraftModelFullNameForeColor = Color.Red;
                else
                    vehViewWithColors.RlDraftModelFullNameForeColor = Color.Black;

                if (vehViewWithColors.ManufactureYear != null && vehViewWithColors.DraftManufactureYear != null && vehViewWithColors.ManufactureYear != vehViewWithColors.DraftManufactureYear)
                    vehViewWithColors.RlDraftManufactureYearForeColor = Color.Red;
                else
                    vehViewWithColors.RlDraftManufactureYearForeColor = Color.Black;

                if (vehViewWithColors.Owner != null && vehViewWithColors.DraftOwner != null && vehViewWithColors.Owner != vehViewWithColors.DraftOwner)
                    vehViewWithColors.RlDraftOwnerForeColor = Color.Red;
                else
                    vehViewWithColors.RlDraftOwnerForeColor = Color.Black;

                if (vehViewWithColors.RegistrationDate != null && vehViewWithColors.DraftRegistrationDate != null && vehViewWithColors.RegistrationDate != vehViewWithColors.DraftRegistrationDate)
                    vehViewWithColors.RlDraftRegistrationDateForeColor = Color.Red;
                else
                    vehViewWithColors.RlDraftRegistrationDateForeColor = Color.Black;

                if (vehViewWithColors.RegistrationCity != null && vehViewWithColors.DraftRegistrationCity != null && vehViewWithColors.RegistrationCity.Id != vehViewWithColors.DraftRegistrationCity.Id)
                    vehViewWithColors.RlDraftRegistrationCityNameForeColor = Color.Red;
                else
                    vehViewWithColors.RlDraftRegistrationCityNameForeColor = Color.Black;

                if (vehViewWithColors.LicenseNumber != null && vehViewWithColors.DraftLicenseNumber != null && vehViewWithColors.LicenseNumber != vehViewWithColors.DraftLicenseNumber)
                    vehViewWithColors.RlDraftLicenseNumberForeColor = Color.Red;
                else
                    vehViewWithColors.RlDraftLicenseNumberForeColor = Color.Black;

                if (vehViewWithColors.LicenseOwnerName != null && vehViewWithColors.DraftLicenseOwnerName != null && vehViewWithColors.LicenseOwnerName != vehViewWithColors.DraftLicenseOwnerName)
                    vehViewWithColors.RlDraftLicenseOwnerNameForeColor = Color.Red;
                else
                    vehViewWithColors.RlDraftLicenseOwnerNameForeColor = Color.Black;

                if (vehViewWithColors.LicenseStartDate != null && vehViewWithColors.DraftLicenseStartDate != null && vehViewWithColors.LicenseStartDate != vehViewWithColors.DraftLicenseStartDate)
                    vehViewWithColors.RlDraftLicenseStartDateForeColor = Color.Red;
                else
                    vehViewWithColors.RlDraftLicenseStartDateForeColor = Color.Black;

                if (vehViewWithColors.LicenseEndDate != null && vehViewWithColors.DraftLicenseEndDate != null && vehViewWithColors.LicenseEndDate != vehViewWithColors.DraftLicenseEndDate)
                    vehViewWithColors.RlDraftLicenseEndDateForeColor = Color.Red;
                else
                    vehViewWithColors.RlDraftLicenseEndDateForeColor = Color.Black;

                if (vehViewWithColors.LicenseAuthorityIssued != null && vehViewWithColors.DraftLicenseAuthorityIssued != null && vehViewWithColors.LicenseAuthorityIssued != vehViewWithColors.DraftLicenseAuthorityIssued)
                    vehViewWithColors.RlDraftLicenseAuthorityIssuedForeColor = Color.Red;
                else
                    vehViewWithColors.RlDraftLicenseAuthorityIssuedForeColor = Color.Black;

                if (vehViewWithColors.Possession != null && vehViewWithColors.DraftPossession != null && vehViewWithColors.Possession.Name != vehViewWithColors.DraftPossession.Name)
                    vehViewWithColors.RlDraftPossessionNameForeColor = Color.Red;
                else
                    vehViewWithColors.RlDraftPossessionNameForeColor = Color.Black;

                if (vehViewWithColors.InsuranceNumber != null && vehViewWithColors.DraftInsuranceNumber != null && vehViewWithColors.InsuranceNumber != vehViewWithColors.DraftInsuranceNumber)
                    vehViewWithColors.RlDraftInsuranceNumberForeColor = Color.Red;
                else
                    vehViewWithColors.RlDraftInsuranceNumberForeColor = Color.Black;

                if (vehViewWithColors.InsuranceAuthorityIssued != null && vehViewWithColors.DraftInsuranceAuthorityIssued != null && vehViewWithColors.InsuranceAuthorityIssued != vehViewWithColors.DraftInsuranceAuthorityIssued)
                    vehViewWithColors.RlDraftInsuranceAuthorityIssuedForeColor = Color.Red;
                else
                    vehViewWithColors.RlDraftInsuranceAuthorityIssuedForeColor = Color.Black;

                if (vehViewWithColors.InsuranceEndDate != null && vehViewWithColors.DraftInsuranceEndDate != null && vehViewWithColors.InsuranceEndDate != vehViewWithColors.DraftInsuranceEndDate)
                    vehViewWithColors.RlDraftInsuranceEndDateForeColor = Color.Red;
                else
                    vehViewWithColors.RlDraftInsuranceEndDateForeColor = Color.Black;

                if (vehViewWithColors.InspectionDate != null && vehViewWithColors.DraftInspectionDate != null && vehViewWithColors.InspectionDate != vehViewWithColors.DraftInspectionDate)
                    vehViewWithColors.RlDraftInspectionDateForeColor = Color.Red;
                else
                    vehViewWithColors.RlDraftInspectionDateForeColor = Color.Black;

                // подготовим новые данные для привязки
                var draftBindingData = new List<VehicleViewWithColors>();
                draftBindingData.Add(vehViewWithColors);

                RdfDraftValues.DataSource = draftBindingData;
            }
        }

        protected void RefreshTabsVisibility()
        {
            ProfileState currProfileState = (ProfileState)CurrentFormData[0].ProfileState.Id;
            if( currProfileState == ProfileState.Updated ||
                currProfileState == ProfileState.Approved ||
                currProfileState == ProfileState.Verificating ||
                currProfileState == ProfileState.Rejected )
            {
                rtsMain.FindTabByValue("2").Enabled = true;
                rpvDraftValues.Enabled = true;
            }
            else
            {
                rtsMain.FindTabByValue("2").Enabled = false;
                rpvDraftValues.Enabled = false;
            }
        }

        protected void rdfActualValues_NeedDataSource(object sender, RadDataFormNeedDataSourceEventArgs e)
        {
            RefreshActualValuesForm();
            RefreshChangeProfileStateButtons();
        }

        protected void rdfDraftValues_NeedDataSource(object sender, RadDataFormNeedDataSourceEventArgs e)
        {
            RefreshDraftValuesForm();
            RefreshTabsVisibility();
        }

        protected void RefreshAllForms()
        {
            RefreshActualValuesForm();
            RefreshChangeProfileStateButtons();

            RefreshDraftValuesForm();
            RefreshTabsVisibility();
        }

        protected void rbChangeProfileState_Click(object sender, EventArgs e)
        {
            long? nextPorfStateId = NextProfileStateId;
            int? vehicleId = CurrentVehicleId;
            if ( nextPorfStateId!=null && vehicleId!=null )
            {
                ProfileState nextProfileState = (ProfileState) nextPorfStateId;                
                var webApiClient = WebApiClientHandler.Get();
                Boolean complete = false;
                switch (nextProfileState)
                {
                    case ProfileState.Verificating:
                        complete =
                            AsyncHelper.RunSync<Boolean>
                            (
                                () => webApiClient.VehicleVerifyAsync(vehicleId)
                            );
                        if( complete==true )
                        {
                            CurrentFormData = null; // для перезагрузки данных форм
                            RefreshAllForms();
                        }
                        break;
                    case ProfileState.Approved:
                        complete =
                            AsyncHelper.RunSync<Boolean>
                            (
                                () => webApiClient.VehicleApproveAsync(vehicleId)
                            );
                        if (complete == true)
                        {
                            CurrentFormData = null; // для перезагрузки данных форм
                            RefreshAllForms();
                        }
                        break;
                    case ProfileState.Confirmed:
                        complete =
                            AsyncHelper.RunSync<Boolean>
                            (
                                () => webApiClient.VehicleConfirmAsync(vehicleId)
                            );
                        if (complete == true)
                        {
                            CurrentFormData = null; // для перезагрузки данных форм
                            RefreshAllForms();
                        }
                        break;
                    default:break;
                }
            }
        }

        protected void rbRejectIt_Click(object sender, EventArgs e)
        {
            int? vehicleId = CurrentVehicleId;
            long? nextPorfStateId = NextProfileStateId;
            if (nextPorfStateId != null && vehicleId != null)
            {
                var webApiClient = WebApiClientHandler.Get();
                ProfileState nextProfileState = (ProfileState)nextPorfStateId;
                Boolean complete = false;
                if (nextPorfStateId == (long)ProfileState.Confirmed) // именно при таком раскладе можно отклонять
                {
                    complete =
                        AsyncHelper.RunSync<Boolean>
                        (
                            () => webApiClient.VehicleRejectAsync(vehicleId)
                        );
                    if (complete == true)
                    {
                        CurrentFormData = null; // для перезагрузки данных форм
                        RefreshAllForms();
                    }
                }
            }
        }

    }
}