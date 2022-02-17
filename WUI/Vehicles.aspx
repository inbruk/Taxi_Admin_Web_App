<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Global.master" Inherits="Rapport.Support.WUI.Vehicles" CodeBehind="Vehicles.aspx.cs" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="auxctrls" TagName="WindowLikeBorderPanel" Src="~/AuxiliaryWebUserControls/WindowLikeBorderPanel.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
        Rapport.Support: Автомобили
    </asp:Content>

    <asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">     
        <auxctrls:WindowLikeBorderPanel ID="wlbRight"  Title="Автомобили"  Width="1100" Height="640" runat="server" >
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
                                        <a href="VehicleForm.aspx?vehicleId=<%# DataBinder.Eval(Container.DataItem, "Id") %>" >
                                            <span class="griditem_clickable">
                                                <%# DataBinder.Eval(Container.DataItem, "Id") %>
                                            </span>
                                        </a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn UniqueName="ModelFullName" HeaderText="Марка и модель" 
                                    HeaderStyle-Width="150" ItemStyle-HorizontalAlign="Right" 
                                >
                                    <ItemTemplate>
                                        <a href="VehicleForm.aspx?vehicleId=<%# DataBinder.Eval(Container.DataItem, "Id") %>" >
                                            <span class="griditem_clickable">
                                                <%# DataBinder.Eval(Container.DataItem, "Model.FullName") %>
                                            </span>
                                        </a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridBoundColumn UniqueName="ModelClassName" DataField="Model.Class.Name" HeaderText="Класс машины" HeaderStyle-Width="100" />
                                <telerik:GridBoundColumn UniqueName="RegistrationNumber" DataField="RegistrationNumber" HeaderText="Регистрационный номер" HeaderStyle-Width="130" />
                                <telerik:GridBoundColumn UniqueName="ColorName" DataField="Color.Name" HeaderText="Цвет" HeaderStyle-Width="100" />
                                <telerik:GridBoundColumn UniqueName="BodyName" DataField="Body.Name" HeaderText="Корпус" HeaderStyle-Width="100" />
                                <telerik:GridBoundColumn UniqueName="ManufactureYear" DataField="ManufactureYear" HeaderText="Год производства" HeaderStyle-Width="100" />
                                <telerik:GridBoundColumn UniqueName="Owner" DataField="Owner" HeaderText="Владелец" HeaderStyle-Width="200" />

                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>

            </Contents>            
        </auxctrls:WindowLikeBorderPanel>        
    </asp:Content>