<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Global.master" Inherits="Rapport.Support.WUI.CompanyForm" CodeBehind="CompanyForm.aspx.cs" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="auxctrls" TagName="WindowLikeBorderPanel" Src="~/AuxiliaryWebUserControls/WindowLikeBorderPanel.ascx" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
        Rapport.Support: Карточка компании
    </asp:Content>

    <asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">     
        <auxctrls:WindowLikeBorderPanel ID="wlbRight"  Title="Карточка компании"  Width="1100" Height="640" runat="server" >
            <Contents>
                <div style="width:1074px;height:590px;overflow-y:scroll;">
                    <telerik:RadDataForm ID="RadDataForm1" runat="server" OnNeedDataSource="RadDataForm1_NeedDataSource" >
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
                                        <asp:Label Text="ID" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbId" Text='<%# Bind("Id") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Расчетный счет" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbCheckingAccount" Text='<%# Bind("CheckingAccount") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Краткое наименование" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbName" Text='<%# Bind("Name") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Полное наименование" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbFullName" Text='<%# Bind("FullName") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="ОГРН" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbPsrn" Text='<%# Bind("Psrn") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="ОГРН2" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbPsrnsp" Text='<%# Bind("Psrnsp") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Является ИП" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbIsSoleProprietor" Text='<%# Bind("IsSoleProprietorStr") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Корреспондирующий счёт" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbCorrespondingAccount" Text='<%# Bind("CorrespondingAccount") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Форма организационно-правовой собственности" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbLegalForm" Text='<%# Bind("LegalForm.Name") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="БИК" AssociatedControlID="rtbBIC" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbBIC" Text='<%# Bind("Bic") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Страна регистрации" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbRegCountry" 
                                            Text='<%# Bind("RegistrationCity.Region.Country.Name") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Наименование банка" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbBankName" Text='<%# Bind("BankName") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Регион регистрации" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbRegRegion" 
                                            Text='<%# Bind("RegistrationCity.Region.Name") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Должность подписанта" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbSignatoryPosition" 
                                            Text='<%# Bind("SignatoryPosition") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Город регистрации" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbRegCity" 
                                            Text='<%# Bind("RegistrationCity.Name") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Полное имя подписанта" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbSignatoryFullName" 
                                            Text='<%# Bind("SignatoryFullName") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Юридический адрес" Width="190" runat="server" Font-Bold="true" />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbLegalAddress" 
                                            Text='<%# Bind("LegalAddress") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Номер паспорта подписанта" Width="190" runat="server" Font-Bold="true" />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbSignatoryPassportNumber" 
                                            Text='<%# Bind("SignatoryPassportNumber") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Фактический адрес" Width="190" runat="server" Font-Bold="true" />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbActualAddress" 
                                            Text='<%# Bind("ActualAddress") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Наименование документа, предоставляющего право подписи" Width="190" runat="server" Font-Bold="true" />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbSignaturePermission"
                                            Text='<%# Bind("SignaturePermission") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Почтовый индекс" Width="190" runat="server" Font-Bold="true" />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbPostCode" 
                                            Text='<%# Bind("PostCode") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Электронная почта" Width="190" runat="server" Font-Bold="true" />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbEmail" 
                                            Text='<%# Bind("Email") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Телефон для связи" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbContactPhone"
                                            Text='<%# Bind("ContactPhone") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Номер телефона для платежей" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbBillingPhone" 
                                            Text='<%# Bind("BillingPhone") %>' Width="240px" ReadOnly="true" runat="server" />
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
                                        <telerik:RadLabel ID="rtbProfileState" 
                                            Text='<%# Bind("ProfileState.Name") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Причина изменения статуса профиля" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbProfileStateReason" 
                                            Text='<%# Bind("ProfileStateReasonStr") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="ИНН" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbTin" 
                                            Text='<%# Bind("Tin") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="КПП" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbTaxRegistrationReasonCode" 
                                            Text='<%# Bind("TaxRegistrationReasonCode") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Баланс компании, как агрегатора" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbAgregatorBalance" 
                                            Text='<%# Bind("AggregatorFinance.Balance") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Лимит компании, как агрегатора" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbAgregatorLimit" 
                                            Text='<%# Bind("AggregatorFinance.Limit") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Баланс компании, как работодателя" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbEmployerBalance" 
                                            Text='<%# Bind("EmployerFinance.Balance") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Лимит компании, как работодателя" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbEmployerLimit" 
                                            Text='<%# Bind("EmployerFinance.Limit") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>

                                <tr>
                                    <td class="filterAndGrid_BufferTd" colspan="4">
                                        <div></div>
                                    </td>
                                </tr> 
                            </table>                  

                        </ItemTemplate>
                        <EditItemTemplate>
                            <table class="filterAndGrid_Table" cellspacing="0" cellpadding="0" style="width:1000px;vertical-align:top;">
                                <tr>
                                    <td class="filterAndGrid_BufferTd" colspan="4">
                                        <div></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="ID" AssociatedControlID="rtbId" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbId" Text='<%# Bind("Id") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Расчетный счет" AssociatedControlID="rtbCheckingAccount" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbCheckingAccount" Text='<%# Bind("CheckingAccount") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Краткое наименование" AssociatedControlID="rtbName" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbName" Text='<%# Bind("Name") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Полное наименование" AssociatedControlID="rtbFullName" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbFullName" Text='<%# Bind("FullName") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="ОГРН" AssociatedControlID="rtbPsrn" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbPsrn" Text='<%# Bind("Psrn") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="ОГРН2" AssociatedControlID="rtbPsrnsp" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbPsrnsp" Text='<%# Bind("Psrnsp") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Является ИП" AssociatedControlID="rtbIsSoleProprietor" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbIsSoleProprietor" Text='<%# Bind("IsSoleProprietorStr") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Корреспондирующий счёт" AssociatedControlID="rtbCorrespondingAccount" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbCorrespondingAccount" Text='<%# Bind("CorrespondingAccount") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>

                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Форма организационно-правовой собственности" AssociatedControlID="rtbLegalForm" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbLegalForm" Text='<%# Bind("LegalForm") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="БИК" AssociatedControlID="rtbBIC" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbBIC" Text='<%# Bind("Bic") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Страна регистрации" AssociatedControlID="rtbRegCountry" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbRegCountry" 
                                            Text='<%# Bind("RegistrationCity.Region.Country.Name") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Наименование банка" AssociatedControlID="rtbBankName" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbBankName" Text='<%# Bind("BankName") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Регион регистрации" AssociatedControlID="rtbRegRegion" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbRegRegion" 
                                            Text='<%# Bind("RegistrationCity.Region.Name") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Должность подписанта" AssociatedControlID="rtbSignatoryPosition" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbSignatoryPosition" 
                                            Text='<%# Bind("SignatoryPosition") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Город регистрации" AssociatedControlID="rtbRegCity" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbRegCity" 
                                            Text='<%# Bind("RegistrationCity.Name") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Полное имя подписанта" AssociatedControlID="rtbSignatoryFullName" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbSignatoryFullName" 
                                            Text='<%# Bind("SignatoryFullName") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Юридический адрес" AssociatedControlID="rtbLegalAddress" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbLegalAddress" 
                                            Text='<%# Bind("LegalAddress") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Номер паспорта подписанта" AssociatedControlID="rtbSignatoryPassportNumber" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbSignatoryPassportNumber" 
                                            Text='<%# Bind("SignatoryPassportNumber") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Фактический адрес" AssociatedControlID="rtbActualAddress" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbActualAddress" 
                                            Text='<%# Bind("ActualAddress") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Наименование документа, предоставляющего право подписи" 
                                            AssociatedControlID="rtbSignaturePermission" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbSignaturePermission"
                                            Text='<%# Bind("SignaturePermission") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Почтовый индекс" AssociatedControlID="rtbPostCode" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbPostCode" 
                                            Text='<%# Bind("PostCode") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Электронная почта" AssociatedControlID="rtbEmail" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbEmail" 
                                            Text='<%# Bind("Email") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Телефон для связи" AssociatedControlID="rtbContactPhone" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbContactPhone"
                                            Text='<%# Bind("ContactPhone") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Номер телефона для платежей" AssociatedControlID="rtbBillingPhone" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbBillingPhone" 
                                            Text='<%# Bind("BillingPhone") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Статус профиля" AssociatedControlID="rtbProfileState" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbProfileState" 
                                            Text='<%# Bind("ProfileState.Name") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Причина изменения статуса профиля" AssociatedControlID="rtbProfileStateReason" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbProfileStateReason" 
                                            Text='<%# Bind("ProfileStateReason.Name") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="ИНН" AssociatedControlID="rtbTin" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbTin" 
                                            Text='<%# Bind("Tin") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="КПП" AssociatedControlID="rtbTaxRegistrationReasonCode" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbTaxRegistrationReasonCode" 
                                            Text='<%# Bind("TaxRegistrationReasonCode") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Баланс компании, как агрегатора" AssociatedControlID="rtbAgregatorBalance" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbAgregatorBalance" 
                                            Text='<%# Bind("AggregatorFinance.Balance") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Лимит компании, как агрегатора" AssociatedControlID="rtbAgregatorLimit" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbAgregatorLimit" 
                                            Text='<%# Bind("AggregatorFinance.Limit") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Баланс компании, как работодателя" AssociatedControlID="rtbEmployerBalance" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbEmployerBalance" 
                                            Text='<%# Bind("EmployerFinance.Balance") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2" >
                                        <asp:Label Text="Лимит компании, как работодателя" AssociatedControlID="rtbEmployerLimit" Width="190" runat="server" />
                                    </td>
                                    <td class="formValueMedium25" >
                                        <telerik:RadLabel ID="rtbEmployerLimit" 
                                            Text='<%# Bind("EmployerFinance.Limit") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>

                                <tr>
                                    <td class="filterAndGrid_BufferTd" colspan="6">
                                        <div></div>
                                    </td>
                                </tr> 
                            </table>                  
                        </EditItemTemplate>
                    </telerik:RadDataForm>
                </div>
            </Contents>            
        </auxctrls:WindowLikeBorderPanel>        
    </asp:Content>