<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Global.master" Inherits="Rapport.Support.WUI.DriverForm" CodeBehind="DriverForm.aspx.cs" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="auxctrls" TagName="WindowLikeBorderPanel" Src="~/AuxiliaryWebUserControls/WindowLikeBorderPanel.ascx" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
        Rapport.Support: Карточка водителя
    </asp:Content>

    <asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">     
        <auxctrls:WindowLikeBorderPanel ID="wlbRight"  Title="Карточка водителя"  Width="1100" Height="640" runat="server" >
            <Contents>

                <div style="width:1074px;height:590px;overflow-y:scroll;">
                    <telerik:RadTabStrip ID="rtsMain" RenderMode="Lightweight" runat="server" MultiPageID="rmpMain" SelectedIndex="0" >
                        <Tabs>
                            <telerik:RadTab Text="Актуальные значения" Value="1" PageViewID="rpvActualValues" Height="20px" ></telerik:RadTab>
                            <telerik:RadTab Text="Черновые значения" Value="2" PageViewID="rpvDraftValues" Height="20px" ></telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                    <telerik:RadMultiPage runat="server" ID="rmpMain"  SelectedIndex="0" Height="375px" >
                        <telerik:RadPageView runat="server" ID="rpvActualValues">
                            <telerik:RadDataForm ID="RdfActualValues" runat="server" OnNeedDataSource="rdfActualValues_NeedDataSource" >
                                <ItemTemplate>

                                    <table class="filterAndGrid_Table" cellspacing="0" cellpadding="0" style="width:1000px;vertical-align:top;">
                                        <tr>
                                            <td class="filterAndGrid_BufferTd" colspan="6">
                                                <div></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="ID водителя" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rtbId" Text='<%# Bind("Id") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Категория транспорта" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rlFullLicenseClasses" Text='<%# Bind("FullLicenseClasses") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Фамилия Имя Отчество" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rlFullName" Text='<%# Bind("FullName") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Дата выдачи прав" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rlLicenseStartDate" Text='<%# Bind("LicenseStartDate") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Гражданство" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rlCitizenshipCountryName" Text='<%# Bind("CitizenshipCountry.Name") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Права действительны до" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rlLicenseEndDate" Text='<%# Bind("LicenseEndDate") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Номер паспорта" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rlPassportNumber" Text='<%# Bind("PassportNumber") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Дата медицинского освидетельствования" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RadLabel4" Text='<%# Bind("MedicalExaminationDate") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Адрес регистрации" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rlFullResidenceAddress" Text='<%# Bind("FullResidenceAddress") %>' 
                                                    Width="240px" ReadOnly="true" runat="server" Font-Bold="false" 
                                                />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Автомобиль (из смены)" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <span class="griditem_ordinary">
                                                    <%# DataBinder.Eval(Container.DataItem, "Shift.VehicleModel.FullName") %>
                                                    &nbsp;
                                                    <%# DataBinder.Eval(Container.DataItem, "Shift.RegistrationNumber") %>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Баланс / Лимит" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <a href="FinanceRecords.aspx?driverId=<%# DataBinder.Eval(Container.DataItem, "Id") %>" >
                                                    <span class="griditem_clickable">
                                                        <%# DataBinder.Eval(Container.DataItem, "Finance.Balance") %>
                                                        &nbsp;&#47;&nbsp;
                                                        <%# DataBinder.Eval(Container.DataItem, "Finance.Limit") %>
                                                    </span>
                                                </a>
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Текущая смена /состояние" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <a href="ShiftForm.aspx?shiftPhone=<%# DataBinder.Eval(Container.DataItem, "RegistrationPhone") %>">
                                                    <span class="griditem_clickable">
                                                        <%# DataBinder.Eval(Container.DataItem, "Shift.Id") %>
                                                    </span>
                                                </a>
                                                <span class="griditem_ordinary">
                                                    &nbsp;&#47;&nbsp;
                                                    <%# DataBinder.Eval(Container.DataItem, "Shift.State.Name") %>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Имя организации (из смены)" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <span class="griditem_ordinary">
                                                    <%# DataBinder.Eval(Container.DataItem, "Shift.EmployerCompanyName") %>
                                                </span>                                                
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Заказы (активных/всего) *" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <a href="Main.aspx"><span class="griditem_clickable">0</span></a>
                                                <span class="griditem_ordinary">&#47;</span>
                                                <a href="Main.aspx"><span class="griditem_clickable">15</span></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Статус профиля" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RadLabel7" Text='<%# Bind("ProfileState.Name") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Последнее известное положение *" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <span> Совхоз имени Ленина 35, Московская обл. </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Водительское удостоверение" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RadLabel8" Text='<%# Bind("LicenseNumber") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Регистрационный телефон" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RadLabel1" Text='<%# Bind("RegistrationPhone") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Пол" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RadLabel2" Text='<%# Bind("Gender.Name") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Дата рождения" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RadLabel3" Text='<%# Bind("BirthDate") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Год начала стажа" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RadLabel5" Text='<%# Bind("ExperienceFrom") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="ИНН" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RadLabel6" Text='<%# Bind("Tin") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="filterAndGrid_BufferTd" colspan="4">
                                                <div></div>
                                            </td>
                                        </tr> 
                                    </table>  
                                    
                                </ItemTemplate>
                            </telerik:RadDataForm>

                            <table class="filterAndGrid_Table" cellspacing="0" cellpadding="0" style="width:1000px;vertical-align:top;">
                                <tr>
                                    <td class="filterAndGrid_BufferTd" style="width:100%;text-align:right;" >
                                        <telerik:RadButton ID="RbChangeProfileState" Width="300px" OnClick="rbChangeProfileState_Click" runat="server" /> 
                                        &nbsp;
                                        <telerik:RadButton ID="RbRejectIt" Width="150px" Text="Отклонить" OnClick="rbRejectIt_Click" runat="server" /> 
                                    </td>
                                </tr>
                            </table>

                        </telerik:RadPageView>

                        <telerik:RadPageView runat="server" ID="rpvDraftValues">
                            <telerik:RadDataForm ID="RdfDraftValues" runat="server" OnNeedDataSource="rdfDraftValues_NeedDataSource" >
                                <ItemTemplate>

                                    <table class="filterAndGrid_Table" cellspacing="0" cellpadding="0" style="width:1000px;vertical-align:top;">
                                        <tr>
                                            <td class="filterAndGrid_BufferTd" colspan="6">
                                                <div></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Гражданство" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftCitizenshipCountryName" Text='<%# Bind("DraftCitizenshipCountry.Name") %>' Width="240px" 
                                                    ForeColor='<%# Bind("RlDraftCitizenshipCountryNameForeColor") %>' runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >

                                            </td>
                                            <td class="formValueMedium25WithBorder" >

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Номер паспорта" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftPassportNumber" Text='<%# Bind("DraftPassportNumber") %>' Width="240px" 
                                                    ForeColor='<%# Bind("RlDraftPassportNumberForeColor") %>' runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Адрес регистрации" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftFullResidenceAddress" Text='<%# Bind("DraftFullResidenceAddress") %>' Width="240px" 
                                                    ForeColor='<%# Bind("RlDraftFullResidenceAddressForeColor") %>' runat="server" Font-Bold="false" 
                                                />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Водительское удостоверение" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftLicenseNumber" Text='<%# Bind("DraftLicenseNumber") %>' Width="240px" 
                                                    ForeColor='<%# Bind("RlDraftLicenseNumberForeColor") %>' runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Категория транспорта" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftFullLicenseClasses" Text='<%# Bind("DraftFullLicenseClasses") %>' Width="240px" 
                                                    ForeColor='<%# Bind("RlDraftFullLicenseClassesForeColor") %>' runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Дата выдачи прав" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftLicenseStartDate" Text='<%# Bind("DraftLicenseStartDate") %>' Width="240px" 
                                                    ForeColor='<%# Bind("RlDraftLicenseStartDateForeColor") %>' runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Права действительны до" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftLicenseEndDate" Text='<%# Bind("DraftLicenseEndDate") %>' Width="240px" 
                                                    ForeColor='<%# Bind("RlDraftLicenseEndDateForeColor") %>' runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Год начала стажа" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftExperienceFrom" Text='<%# Bind("DraftExperienceFrom") %>' Width="240px" 
                                                    ForeColor='<%# Bind("RlDraftExperienceFromForeColor") %>' runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="ИНН" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftTin" Text='<%# Bind("DraftTin") %>' Width="240px" 
                                                    ForeColor='<%# Bind("RlDraftTinForeColor") %>' runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>
                                    </table>  

                                </ItemTemplate>
                            </telerik:RadDataForm>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
                    
                    <div style="width:1000px;height:1px;vertical-align:top;">
                        <asp:HiddenField ID="hfLatitude" ClientIDMode="Static" runat="server" />
                        &nbsp;
                        <asp:HiddenField ID="hfLongitude" ClientIDMode="Static" runat="server" />
                    </div>

                    <div id="map" style="width:970px;height:175px;vertical-align:top;margin:0px;margin-left:30px;">
                    </div>
                </div>

                <script>
                    function initMap()
                    {
                        var hfLatitude  = document.getElementById('hfLatitude');
                        var hfLongitude = document.getElementById('hfLongitude');
                        var latValue = hfLatitude.value.replace(',', '.');
                        var lonValue = hfLongitude.value.replace(',', '.');

                        var uluru = new google.maps.LatLng( latValue, lonValue );

                        var map = new google.maps.Map
                        (
                            document.getElementById('map'),
                            {
                              zoom: 12,
                              center: uluru
                            }
                        );

                        var marker = new google.maps.Marker
                        (
                            {
                                position: uluru,
                                map: map
                            }
                        );
                      }
                </script>
                <script async defer
                    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCDGRfZ9kGs63wGnuvyHrmBuOoIk3kGkbg&callback=initMap">
                </script>

            </Contents>            
        </auxctrls:WindowLikeBorderPanel>        
    </asp:Content>