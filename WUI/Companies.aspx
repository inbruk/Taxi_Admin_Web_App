<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Global.master" Inherits="Rapport.Support.WUI.Companies" CodeBehind="Companies.aspx.cs" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="auxctrls" TagName="WindowLikeBorderPanel" Src="~/AuxiliaryWebUserControls/WindowLikeBorderPanel.ascx" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
        Rapport.Support: Компании
    </asp:Content>

    <asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">     
        <auxctrls:WindowLikeBorderPanel ID="wlbRight"  Title="Компании"  Width="1100" Height="640" runat="server" >
            <Contents>

                    <table class="filterAndGrid_Table" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="filterAndGrid_BufferTd" colspan="6">
                                <div></div>
                            </td>
                        </tr>
                        <tr>
                            <td class="formLabelMedium15" >
                                <asp:Label Text="Статус профиля" AssociatedControlID="rcbProfileStatus" runat="server" />
                            </td>
                            <td class="formValueMedium2" >
                                <telerik:RadComboBox ID="rcbProfileStatus" Width="190px" runat="server" 
                                    CheckBoxes="true" EnableCheckAllItemsCheckBox="true" ToolTip="в WebAPI нет загрузки словаря" 
                                    DataValueField="Id" DataTextField="Name"            
                                >
                                    <Localization CheckAllString="выбрать все" AllItemsCheckedString="все варианты выбраны" ItemsCheckedString="варианта выбрано" />                                    
                                </telerik:RadComboBox>
                            </td>
                            <td class="formLabelMedium15">
                                <asp:Label Text="ИНН" AssociatedControlID="rtbxTIN" runat="server" />
                            </td>
                            <td class="formValueMedium2" >
                                <telerik:RadTextBox ID="rtbxTIN" Width="190px" runat="server" />
                            </td>
                            <td colspan="2" >
                                <telerik:RadButton ID="rbtnClear" runat="server" Width="140px" Text="Очистить фильтры" OnClick="rbtnClear_Click" />
                                &nbsp;
                                <telerik:RadButton ID="rbtnApply" runat="server" Width="190px" Text="Применить фильтры" OnClick="rbtnApply_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="filterAndGrid_BufferTd" colspan="6">
                                <div></div>
                            </td>
                        </tr> 
                    </table>                  
                
                    <telerik:RadGrid ID="mainGrid" Width="1074px" Height="550px" runat="server" ClientSettings-Selecting-AllowRowSelect="False"
                        AllowMultiRowSelection="False" AllowPaging="true" PageSize="10" AllowCustomPaging="True" AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center" 
                        OnNeedDataSource="mainGrid_NeedDataSource" ClientSettings-Resizing-AllowColumnResize="True" ClientSettings-EnablePostBackOnRowClick="false"
                    >
                        <ClientSettings>
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="False"  ></Scrolling>
                        </ClientSettings>
                        
                        <PagerStyle Mode="NextPrevAndNumeric" PageSizeLabelText="Размер страницы в строках:  " PageSizes="10" 
                            PagerTextFormat="{4} Страница {0} из {1}, строки с {2} по {3} из {5}" 
                        />

                        <MasterTableView CommandItemDisplay="None" DataKeyNames="Id" 
                            NoMasterRecordsText="Нет записей для показа" NoDetailRecordsText="Нет записей для показа" 
                        >
                            <Columns>   
                                
                                <telerik:GridTemplateColumn UniqueName="Id" HeaderText="ID" HeaderStyle-Width="50" ItemStyle-HorizontalAlign="Right" >
                                    <ItemTemplate>
                                        <a href="CompanyForm.aspx?companyId=<%# DataBinder.Eval(Container.DataItem, "Id") %>" >
                                            <span class="griditem_clickable">
                                                <%# DataBinder.Eval(Container.DataItem, "Id") %>
                                            </span>
                                        </a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn UniqueName="Name" HeaderText="Название" HeaderStyle-Width="150" ItemStyle-HorizontalAlign="Right" >
                                    <ItemTemplate>
                                        <a href="CompanyForm.aspx?companyId=<%# DataBinder.Eval(Container.DataItem, "Id") %>" >
                                            <span class="griditem_clickable">
                                                <%# DataBinder.Eval(Container.DataItem, "Name") %>
                                            </span>
                                        </a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridBoundColumn UniqueName="LegalFormName" DataField="LegalForm.Name" HeaderText="Форма организационно-правовой собственности" HeaderStyle-Width="200" />
                                <telerik:GridBoundColumn UniqueName="RegistrationCity" DataField="RegistrationCity.Name" HeaderText="Город регистрации" HeaderStyle-Width="150" />
                                <telerik:GridBoundColumn UniqueName="Tin" DataField="Tin" HeaderText="ИНН" HeaderStyle-Width="150" />
                                <telerik:GridBoundColumn UniqueName="BillingPhone" DataField="BillingPhone" HeaderText="Телефон для платежей" HeaderStyle-Width="150" />
                                <telerik:GridBoundColumn UniqueName="ProfileStateName" DataField="ProfileState.Name" HeaderText="Статус профиля" HeaderStyle-Width="150" />

                                <telerik:GridBoundColumn UniqueName="ProfileStateReasonStr" DataField="ProfileStateReasonStr" 
                                    HeaderText="Причина изменения статуса профиля" HeaderStyle-Width="200" />

                                <telerik:GridBoundColumn UniqueName="AggregatorFinanceBalance" DataField="AggregatorFinance.Balance" HeaderText="Баланс агрегатора" HeaderStyle-Width="150" />
                                <telerik:GridBoundColumn UniqueName="AggregatorFinanceLimit" DataField="AggregatorFinance.Limit" HeaderText="Лимит агрегатора" HeaderStyle-Width="150" />
                                <telerik:GridBoundColumn UniqueName="EmployerFinanceBalance" DataField="EmployerFinance.Balance" HeaderText="Баланс работодателя" HeaderStyle-Width="150" />
                                <telerik:GridBoundColumn UniqueName="EmployerFinanceLimit" DataField="EmployerFinance.Limit" HeaderText="Лимит работодателя" HeaderStyle-Width="150" />

                                <telerik:GridBoundColumn UniqueName="RegistrationCityRegionCountryName" DataField="RegistrationCity.Region.Country.Name" 
                                    HeaderText="Страна" HeaderStyle-Width="100" />

                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>

            </Contents>            
        </auxctrls:WindowLikeBorderPanel>        
    </asp:Content>