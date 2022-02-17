<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Global.master" Inherits="Rapport.Support.WUI.Drivers" CodeBehind="Drivers.aspx.cs" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="auxctrls" TagName="WindowLikeBorderPanel" Src="~/AuxiliaryWebUserControls/WindowLikeBorderPanel.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
        Rapport.Support: Водители
    </asp:Content>

    <asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">     
        <auxctrls:WindowLikeBorderPanel ID="wlbRight"  Title="Водители"  Width="1100" Height="640" runat="server" >
            <Contents>

                    <table class="filterAndGrid_Table" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="filterAndGrid_preBufferTd" colspan="6">
                                <div></div>
                            </td>
                        </tr>
                        <tr>
                            <td class="formLabelMedium15" >
                                <asp:Label Text="Сортировка по " AssociatedControlID="ddlSorting" runat="server" />
                            </td>
                            <td class="formValueMedium2" >
                                <telerik:RadDropDownList ID="ddlSorting" Width="190px" runat="server">
                                    <Items>
                                        <telerik:DropDownListItem Text="нет в Web Api"/>
                                    </Items>
                                </telerik:RadDropDownList>
                            </td>
                            <td class="formLabelMedium15">
                            </td>
                            <td class="formValueMedium2" >
                            </td>
                            <td colspan="2" >
                                <telerik:RadButton ID="rbtnClear" runat="server" Width="140px" Text="Очистить фильтры" OnClick="rbtnClear_Click" />
                                &nbsp;
                                <telerik:RadButton ID="rbtnApply" runat="server" Width="190px" Text="Применить фильтры" OnClick="rbtnApply_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formLabelMedium15" >
                                <asp:Label Text="ФИО" AssociatedControlID="rtbxNames" runat="server" />
                            </td>
                            <td class="formValueMedium2" >
                                <telerik:RadTextBox ID="rtbxNames" Width="190px" Text="нет в Web Api" runat="server" />
                            </td>
                            <td class="formLabelMedium15" >
                                <asp:Label Text="Телефон рег." AssociatedControlID="rtbxRegistrationPhone" runat="server" />
                            </td>
                            <td class="formValueMedium2" >
                                <telerik:RadTextBox ID="rtbxRegistrationPhone" Width="190px" Text="нет в Web Api" runat="server" />
                            </td>
                            <td class="formLabelMedium15" >
                                <asp:Label Text="Статус профиля" AssociatedControlID="rcbProfileStatus" runat="server" />
                            </td>
                            <td class="formValueMedium2">
                                <telerik:RadComboBox ID="rcbProfileStatus" Width="190px" runat="server" 
                                    CheckBoxes="true" EnableCheckAllItemsCheckBox="true" ToolTip="в WebAPI нет загрузки словаря" 
                                    DataValueField="Id" DataTextField="Name"            
                                >
                                    <Localization CheckAllString="выбрать все" AllItemsCheckedString="все варианты выбраны" ItemsCheckedString="варианта выбрано" />                                    
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="formLabelMedium15" >
                                <asp:Label Text="ИНН" AssociatedControlID="rtbxTIN" runat="server" />
                            </td>
                            <td class="formValueMedium2" >
                                <telerik:RadTextBox ID="rtbxTIN" Width="190px" runat="server" />
                            </td>
                            <td class="formLabelMedium15" >
                                <asp:Label Text="Тип занятости" AssociatedControlID="rddlTypeOfEmployment" runat="server" />
                            </td>
                            <td class="formValueMedium2" >
                                <telerik:RadDropDownList ID="rddlTypeOfEmployment" Width="190px" runat="server" >
                                    <Items>
                                        <telerik:DropDownListItem Text="нет в Web Api" />
                                    </Items>
                                </telerik:RadDropDownList>
                            </td>
                            <td class="formLabelMedium15" >
                                <asp:Label Text="Состояние смены" AssociatedControlID="ddlShiftState" runat="server" />
                            </td>
                            <td class="formValueMedium2">
                                <telerik:RadDropDownList ID="ddlShiftState" Width="190px" runat="server" >
                                    <Items>
                                        <telerik:DropDownListItem Text="нет в Web Api" />
                                    </Items>
                                </telerik:RadDropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="filterAndGrid_preBufferTd" colspan="6">
                                <div></div>
                            </td>
                        </tr> 
                    </table>                   

                    <telerik:RadGrid ID="mainGrid" Width="1074px" Height="490px" runat="server" ClientSettings-Selecting-AllowRowSelect="False"
                        AllowMultiRowSelection="False" AllowPaging="true" PageSize="10" AllowCustomPaging="True" AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center" 
                        OnNeedDataSource="mainGrid_NeedDataSource" ClientSettings-Resizing-AllowColumnResize="true" ClientSettings-EnablePostBackOnRowClick="false"
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
                                <telerik:GridTemplateColumn UniqueName="Id" HeaderText="ID" 
                                    HeaderStyle-Width="50" ItemStyle-HorizontalAlign="Right"
                                >
                                    <ItemTemplate>
                                        <a href="DriverForm.aspx?driverId=<%# DataBinder.Eval(Container.DataItem, "Id") %>" >
                                            <span class="griditem_clickable">
                                                <%# DataBinder.Eval(Container.DataItem, "Id") %>
                                            </span>
                                        </a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridBoundColumn UniqueName="RegistrationPhone" DataField="RegistrationPhone" 
                                    HeaderText="Телефон" HeaderStyle-Width="100" />

                                <telerik:GridTemplateColumn UniqueName="FullName" HeaderText="Фамилия Имя Отчество" 
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="250"
                                >
                                    <ItemTemplate>
                                        <a href="DriverForm.aspx?driverId=<%# DataBinder.Eval(Container.DataItem, "Id") %>" >
                                            <span class="griditem_clickable">
                                                <%# DataBinder.Eval(Container.DataItem, "FullName") %>
                                            </span>
                                        </a>

                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn UniqueName="CompanyName" HeaderText="Имя организации (из смены)" 
                                    HeaderStyle-Width="150" ItemStyle-HorizontalAlign="Left" 
                                >
                                    <ItemTemplate>
                                        <span class="griditem_ordinary">
                                            <%# DataBinder.Eval(Container.DataItem, "Shift.EmployerCompanyName") %>
                                        </span>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn UniqueName="Balance" HeaderText="Баланс/Лимит" 
                                    HeaderStyle-Width="100" ItemStyle-HorizontalAlign="Right" 
                                >
                                    <ItemTemplate>
                                        <a href="FinanceRecords.aspx?driverId=<%# DataBinder.Eval(Container.DataItem, "Id") %>" >
                                            <span class="griditem_clickable">
                                                <%# DataBinder.Eval(Container.DataItem, "Finance.Balance") %>
                                                &nbsp;&#47;&nbsp;
                                                <%# DataBinder.Eval(Container.DataItem, "Finance.Limit") %>
                                            </span>
                                        </a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn UniqueName="Cars" HeaderText="Автомобиль (из смены)" 
                                    HeaderStyle-Width="150" ItemStyle-HorizontalAlign="Center" 
                                >
                                    <ItemTemplate>
                                        <span class="griditem_ordinary">
                                            <%# DataBinder.Eval(Container.DataItem, "Shift.VehicleModel.FullName") %>
                                            &nbsp;
                                            <%# DataBinder.Eval(Container.DataItem, "Shift.RegistrationNumber") %>
                                        </span>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn UniqueName="Orders" DataField="Orders" HeaderText="Заказы (активных/всего) *" 
                                    HeaderStyle-Width="150" ItemStyle-HorizontalAlign="Center"  
                                >
                                    <ItemTemplate>
                                        <a href="Main.aspx"><span class="griditem_clickable">0</span></a>
                                        <span class="griditem_ordinary">&#47;</span>
                                        <a href="Main.aspx"><span class="griditem_clickable">15</span></a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn UniqueName="Shift" DataField="Shift" HeaderText="Смена /состояние" 
                                    HeaderStyle-Width="100" ItemStyle-HorizontalAlign="Center" 
                                >
                                    <ItemTemplate>
                                        <a href="ShiftForm.aspx?shiftPhone=<%# DataBinder.Eval(Container.DataItem, "RegistrationPhone") %>">
                                            <span class="griditem_clickable">
                                                <%# DataBinder.Eval(Container.DataItem, "Shift.Id") %>
                                            </span>
                                        </a>
                                        <span class="griditem_ordinary">
                                            &nbsp;&#47;&nbsp;
                                            <%# DataBinder.Eval(Container.DataItem, "Shift.State.Name") %>
                                        </span>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>

            </Contents>            
        </auxctrls:WindowLikeBorderPanel>        
    </asp:Content>