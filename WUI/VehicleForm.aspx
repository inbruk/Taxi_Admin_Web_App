<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Global.master" Inherits="Rapport.Support.WUI.VehicleForm" CodeBehind="VehicleForm.aspx.cs" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="auxctrls" TagName="WindowLikeBorderPanel" Src="~/AuxiliaryWebUserControls/WindowLikeBorderPanel.ascx" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
        Rapport.Support: Карточка транспортного средства
    </asp:Content>

    <asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">     
        <auxctrls:WindowLikeBorderPanel ID="wlbRight"  Title="Карточка транспортного средства"  Width="1100" Height="640" runat="server" >
            <Contents>

                <div style="width:1074px;height:590px;overflow-y:scroll;">
                    <telerik:RadTabStrip ID="rtsMain" RenderMode="Lightweight" runat="server" MultiPageID="rmpMain" SelectedIndex="0" >
                        <Tabs>
                            <telerik:RadTab Text="Актуальные значения" Value="1" PageViewID="rpvActualValues" Height="20px" ></telerik:RadTab>
                            <telerik:RadTab Text="Черновые значения" Value="2" PageViewID="rpvDraftValues" Height="20px" ></telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                    <telerik:RadMultiPage runat="server" ID="rmpMain"  SelectedIndex="0" >

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
                                                <asp:Label Text="ID автомобиля" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rtbId" Text='<%# Bind("Id") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Регистрационный номер" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rtbRegistrationNumber" Text='<%# Bind("RegistrationNumber") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Город регистрации" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rtbRegistrationCity" Text='<%# Bind("RegistrationCity.Name") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Дата регистрации" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rtbRegistrationDate" Text='<%# Bind("RegistrationDate") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Марка и модель" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RadLabel12" Text='<%# Bind("Model.FullName") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Год выпуска" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rtbManufactureYear" Text='<%# Bind("ManufactureYear") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Цвет" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rtbColorName" Text='<%# Bind("Color.Name") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Тип кузова" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rtbBody" Text='<%# Bind("Body.Name") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Номер лицензии такси" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rtbLicenseNumber" Text='<%# Bind("LicenseNumber") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Наименование органа, выдавшего лицензию такси" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RadLabel9" Text='<%# Bind("InsuranceAuthorityIssued") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Дата окончания действия страхового полиса" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rtbInsuranceEndDate" Text='<%# Bind("InsuranceEndDate") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Дата прохождения тех. осмотра" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rtbInspectionDate" Text='<%# Bind("InspectionDate") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Наименование собственника" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rtbOwner" Text='<%# Bind("Owner") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Основание владения" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="rtbPossession" Text='<%# Bind("Possession.Name") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
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
                                                <telerik:RadLabel ID="rtbProfileState" Text='<%# Bind("ProfileState.Name") %>' Width="240px" ReadOnly="true" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td colspan="2" >
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
                                                <asp:Label Text="Цвет" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftColorName" Text='<%# Bind("DraftColor.Name") %>' Width="240px" 
                                                    ForeColor='<%# Bind("RlDraftColorNameForeColor") %>' runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Тип кузова" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftBodyName" Text='<%# Bind("DraftBody.Name") %>' Width="240px" 
                                                    ForeColor='<%# Bind("RlDraftBodyNameForeColor") %>' runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Марка и модель" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftModelFullName" Text='<%# Bind("DraftModel.FullName") %>' Width="240px" 
                                                    ForeColor='<%# Bind("RlDraftModelFullNameForeColor") %>' runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Год выпуска" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftManufactureYear" Text='<%# Bind("DraftManufactureYear") %>' 
                                                    ForeColor='<%# Bind("RlDraftManufactureYearForeColor") %>' Width="240px" runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Наименование собственника" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftOwner" Text='<%# Bind("DraftOwner") %>' Width="240px" 
                                                    ForeColor='<%# Bind("RlDraftOwnerForeColor") %>' runat="server" Font-Bold="false" />
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
                                                <asp:Label Text="Дата регистрации" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftRegistrationDate" Text='<%# Bind("DraftRegistrationDate") %>' 
                                                    ForeColor='<%# Bind("RlDraftRegistrationDateForeColor") %>' Width="240px" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Город регистрации" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftRegistrationCityName" Text='<%# Bind("DraftRegistrationCity.Name") %>' 
                                                    ForeColor='<%# Bind("RlDraftRegistrationCityNameForeColor") %>' Width="240px" runat="server" Font-Bold="false" />
                                            </td>                                        
                                        </tr>

                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Номер лицензии такси" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftLicenseNumber" Text='<%# Bind("DraftLicenseNumber") %>' 
                                                    ForeColor='<%# Bind("RlDraftLicenseNumberForeColor") %>' Width="240px" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Наименование владельца лицензии такси" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftLicenseOwnerName" Text='<%# Bind("DraftLicenseOwnerName") %>' 
                                                    ForeColor='<%# Bind("RlDraftLicenseOwnerNameForeColor") %>' Width="240px" runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Дата начала действия лицензии такси" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftLicenseStartDate" Text='<%# Bind("DraftLicenseStartDate") %>' 
                                                    ForeColor='<%# Bind("RlDraftLicenseStartDateForeColor") %>' Width="240px" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Дата окончания действия лицензии такси" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftLicenseEndDate" Text='<%# Bind("DraftLicenseEndDate") %>' 
                                                    ForeColor='<%# Bind("RlDraftLicenseEndDateForeColor") %>' Width="240px" runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Наименование органа, выдавшего лицензию такси" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftLicenseAuthorityIssued" Text='<%# Bind("DraftLicenseAuthorityIssued") %>' 
                                                    ForeColor='<%# Bind("RlDraftLicenseAuthorityIssuedForeColor") %>' Width="240px" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Основание владения" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftPossessionName" Text='<%# Bind("DraftPossession.Name") %>' 
                                                    ForeColor='<%# Bind("RlDraftPossessionNameForeColor") %>' Width="240px" runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Номер страхового полиса" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftInsuranceNumber" Text='<%# Bind("DraftInsuranceNumber") %>' 
                                                    ForeColor='<%# Bind("RlDraftInsuranceNumberForeColor") %>' Width="240px" runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Наименование организации выдавшей страховой полис" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftInsuranceAuthorityIssued" Text='<%# Bind("DraftInsuranceAuthorityIssued") %>' 
                                                    ForeColor='<%# Bind("RlDraftInsuranceAuthorityIssuedForeColor") %>' Width="240px" runat="server" Font-Bold="false" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Дата окончания действия страхового полиса" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftInsuranceEndDate" Text='<%# Bind("DraftInsuranceEndDate") %>' Width="240px" 
                                                    ForeColor='<%# Bind("RlDraftInsuranceEndDateForeColor") %>' runat="server" Font-Bold="false" />
                                            </td>
                                            <td class="formLabelMedium1" >
                                                <div>&nbsp;</div>
                                            </td>
                                            <td class="formLabelMedium2WithBorder" >
                                                <asp:Label Text="Дата прохождения тех. осмотра" Width="190" runat="server" Font-Bold="true" />
                                            </td>
                                            <td class="formValueMedium25WithBorder" >
                                                <telerik:RadLabel ID="RlDraftInspectionDate" Text='<%# Bind("DraftInspectionDate") %>' 
                                                    ForeColor='<%# Bind("RlDraftInspectionDateForeColor") %>' Width="240px" runat="server" Font-Bold="false" />
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
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>

                </div>
            </Contents>            
        </auxctrls:WindowLikeBorderPanel>        
    </asp:Content>