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

    public partial class DriverForm : System.Web.UI.Page
    {
        private const String CurrentDriverIdParamName     = "driverId";
        private const String CurrentDriverIdStoreName     = "DriverFormPage_CurrentDriverId";
        private const String CurrentFormDataStoreName     = "DriverFormPage_CurrentFormData";
        private const String ProfileStateValuesStoreName  = "DriverFormPage_ProfileStateValues";
        private const String NextProfileStateIdStoreName  = "DriverFormPage_NextProfileStateId";
        private const String IsMapperInitializedStoreName = "DriverFormPage_IsMapperInitialized";

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
                int result = (int)sessWrap[CurrentDriverIdStoreName];
                return result;
            }
        }

        private List<DriverView> _currentFormData = null;
        protected List<DriverView> CurrentFormData // не храним в сессии чтобы не прозевать изменения в БД
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
                long? result = (long?)sessWrap[NextProfileStateIdStoreName];
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
                cfg.CreateMap<DriverView, DriverViewWithColors>();
            });

            // вытащим ид из параметров и кэшируем его
            String strVal = Request.Params[CurrentDriverIdParamName];
            if (String.IsNullOrWhiteSpace(strVal) == false)
            {
                int temp;
                if (int.TryParse(strVal, out temp))
                {
                    CurrentDriverId = temp;
                }
            }
        }

        protected List<DriverView> CheckStorageAndLoadData()
        {
            List<DriverView> bindData = null;

            // здесь фильтром выступают данные переданные в параметрах запроса и сохраненные в сессии
            int? driverId = CurrentDriverId;

            if (driverId == null) // если нет ида, то вернем пустоту
            {
                bindData = null;
            }
            else // если ид есть
            {
                bindData = CurrentFormData; // пытаемся загрузить данные из кэша
                if (bindData == null) // если данных в кэше нет 
                {
                    // то грузим данные из веб апи сервиса
                    var webApiClient = WebApiClientHandler.Get();
                    DriverView data =
                        AsyncHelper.RunSync<DriverView>
                        (
                            () => webApiClient.GetDriverByIdAsync(driverId)
                        );

                    bindData = new List<DriverView>();
                    bindData.Add(data);

                    // сохраняем данные в кэш для следующего раза
                    CurrentFormData = bindData;
                }
            }

            return bindData;
        }

        protected void RefreshChangeProfileStateButtons()
        {
            if (CurrentFormData != null && CurrentFormData[0] != null)
            {
                long? nextProfStateId = null;
                String nextProfStateName = null;

                ProfileState currProfileState = (ProfileState)CurrentFormData[0].ProfileState.Id;

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

                if (currProfileState == ProfileState.Updated ||
                    currProfileState == ProfileState.Verificating ||
                    currProfileState == ProfileState.Approved)
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


        protected class DriverViewWithColors : DriverView
        {
            public Color RlDraftCitizenshipCountryNameForeColor { get; set; }
            public Color RlDraftPassportNumberForeColor { get; set; }
            public Color RlDraftFullResidenceAddressForeColor { get; set; }
            public Color RlDraftLicenseNumberForeColor { get; set; }
            public Color RlDraftFullLicenseClassesForeColor { get; set; }
            public Color RlDraftLicenseStartDateForeColor { get; set; }
            public Color RlDraftLicenseEndDateForeColor { get; set; }
            public Color RlDraftExperienceFromForeColor { get; set; }
            public Color RlDraftTinForeColor { get; set; }
        }

        protected void RefreshDraftValuesForm()
        {
            // покрасим красным те черновые поля, которые отличаются от чистовых
            List<DriverView> bindData = (List<DriverView>)CurrentFormData;
            if (bindData != null)
            {
                // перенесем данные в расширенную версию данных
                DriverView drvView = bindData[0];
                DriverViewWithColors drvViewWithColors = Mapper.Map<DriverViewWithColors>(drvView);

                // заполним поля отвечающие за цвет строк черновика
                if( drvViewWithColors.CitizenshipCountry == null || 
                    ( drvViewWithColors.DraftCitizenshipCountry != null && drvViewWithColors.CitizenshipCountry.Name != drvViewWithColors.DraftCitizenshipCountry.Name ) 
                  )
                    drvViewWithColors.RlDraftCitizenshipCountryNameForeColor = Color.Red;
                else
                    drvViewWithColors.RlDraftCitizenshipCountryNameForeColor = Color.Black;

                if( drvViewWithColors.PassportNumber == null || 
                    ( drvViewWithColors.DraftPassportNumber != null && drvViewWithColors.PassportNumber != drvViewWithColors.DraftPassportNumber )
                  )
                    drvViewWithColors.RlDraftPassportNumberForeColor = Color.Red;
                else
                    drvViewWithColors.RlDraftPassportNumberForeColor = Color.Black;

                if( drvViewWithColors.FullResidenceAddress == null || 
                    ( drvViewWithColors.DraftFullResidenceAddress != null && drvViewWithColors.FullResidenceAddress != drvViewWithColors.DraftFullResidenceAddress )
                  )
                    drvViewWithColors.RlDraftFullResidenceAddressForeColor = Color.Red;
                else
                    drvViewWithColors.RlDraftFullResidenceAddressForeColor = Color.Black;

                if( drvViewWithColors.LicenseNumber == null || 
                    ( drvViewWithColors.DraftLicenseNumber != null && drvViewWithColors.LicenseNumber != drvViewWithColors.DraftLicenseNumber )
                  )
                    drvViewWithColors.RlDraftLicenseNumberForeColor = Color.Red;
                else
                    drvViewWithColors.RlDraftLicenseNumberForeColor = Color.Black;

                if( drvViewWithColors.FullLicenseClasses == null ||
                    ( drvViewWithColors.DraftFullLicenseClasses != null && drvViewWithColors.FullLicenseClasses != drvViewWithColors.DraftFullLicenseClasses )
                  )
                    drvViewWithColors.RlDraftFullLicenseClassesForeColor = Color.Red;
                else
                    drvViewWithColors.RlDraftFullLicenseClassesForeColor = Color.Black;

                if( drvViewWithColors.LicenseStartDate == null || 
                    ( drvViewWithColors.DraftLicenseStartDate != null && drvViewWithColors.LicenseStartDate != drvViewWithColors.DraftLicenseStartDate )
                  )
                    drvViewWithColors.RlDraftLicenseStartDateForeColor = Color.Red;
                else
                    drvViewWithColors.RlDraftLicenseStartDateForeColor = Color.Black;

                if( drvViewWithColors.LicenseEndDate == null || 
                    ( drvViewWithColors.DraftLicenseEndDate != null && drvViewWithColors.LicenseEndDate != drvViewWithColors.DraftLicenseEndDate )
                  )
                    drvViewWithColors.RlDraftLicenseEndDateForeColor = Color.Red;
                else
                    drvViewWithColors.RlDraftLicenseEndDateForeColor = Color.Black;

                if( drvViewWithColors.ExperienceFrom == null || 
                    ( drvViewWithColors.DraftExperienceFrom != null && drvViewWithColors.ExperienceFrom != drvViewWithColors.DraftExperienceFrom )
                  )
                    drvViewWithColors.RlDraftExperienceFromForeColor = Color.Red;
                else
                    drvViewWithColors.RlDraftExperienceFromForeColor = Color.Black;

                if( drvViewWithColors.Tin == null || 
                    ( drvViewWithColors.DraftTin != null && drvViewWithColors.Tin != drvViewWithColors.DraftTin )
                  )
                    drvViewWithColors.RlDraftTinForeColor = Color.Red;
                else
                    drvViewWithColors.RlDraftTinForeColor = Color.Black;

                // подготовим новые данные для привязки
                var draftBindingData = new List<DriverViewWithColors>();
                draftBindingData.Add(drvViewWithColors);

                RdfDraftValues.DataSource = draftBindingData;
            }
        }

        protected void RefreshTabsVisibility()
        {
            ProfileState currProfileState = (ProfileState)CurrentFormData[0].ProfileState.Id;
            if (currProfileState == ProfileState.Updated ||
                currProfileState == ProfileState.Approved ||
                currProfileState == ProfileState.Verificating ||
                currProfileState == ProfileState.Rejected)
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

        protected void RefreshMap()
        {
            List<DriverView> bindData = (List<DriverView>)CurrentFormData;
            if (bindData != null)
            {
                DriverView dataItem = bindData[0];
                if (dataItem.Shift != null)
                {
                    hfLatitude.Value = dataItem.Shift.Location.Latitude.ToString();
                    hfLongitude.Value = dataItem.Shift.Location.Longitude.ToString();
                }
                else
                {
                    hfLatitude.Value = "55.822456"; 
                    hfLongitude.Value = "37.639675";
                }
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
            RefreshMap();
        }

        protected void RefreshAllForms()
        {
            RefreshActualValuesForm();
            RefreshChangeProfileStateButtons();

            RefreshDraftValuesForm();
            RefreshTabsVisibility();
            RefreshMap();
        }

        protected void rbChangeProfileState_Click(object sender, EventArgs e)
        {
            long? nextPorfStateId = NextProfileStateId;
            int? driverId = CurrentDriverId;
            if (nextPorfStateId != null && driverId != null)
            {
                ProfileState nextProfileState = (ProfileState)nextPorfStateId;
                var webApiClient = WebApiClientHandler.Get();
                Boolean complete = false;
                switch (nextProfileState)
                {
                    case ProfileState.Verificating:
                        complete =
                            AsyncHelper.RunSync<Boolean>
                            (
                                () => webApiClient.DriverVerifyAsync(driverId)
                            );
                        if (complete == true)
                        {
                            CurrentFormData = null; // для перезагрузки данных форм
                            RefreshAllForms();
                        }
                        break;
                    case ProfileState.Approved:
                        complete =
                            AsyncHelper.RunSync<Boolean>
                            (
                                () => webApiClient.DriverApproveAsync(driverId)
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
                                () => webApiClient.DriverConfirmAsync(driverId)
                            );
                        if (complete == true)
                        {
                            CurrentFormData = null; // для перезагрузки данных форм
                            RefreshAllForms();
                        }
                        break;
                    default: break;
                }
            }
        }

        protected void rbRejectIt_Click(object sender, EventArgs e)
        {
            int? driverId = CurrentDriverId;
            long? nextPorfStateId = NextProfileStateId;
            if (nextPorfStateId != null && driverId != null)
            {
                var webApiClient = WebApiClientHandler.Get();
                ProfileState nextProfileState = (ProfileState)nextPorfStateId;
                Boolean complete = false;
                if (nextPorfStateId == (long)ProfileState.Confirmed) // именно при таком раскладе можно отклонять
                {
                    complete =
                        AsyncHelper.RunSync<Boolean>
                        (
                            () => webApiClient.DriverRejectAsync(driverId)
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