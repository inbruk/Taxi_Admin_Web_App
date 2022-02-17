<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Global.master" Inherits="Rapport.Support.WUI.ShiftForm" CodeBehind="ShiftForm.aspx.cs" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="auxctrls" TagName="WindowLikeBorderPanel" Src="~/AuxiliaryWebUserControls/WindowLikeBorderPanel.ascx" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
        Rapport.Support: Карточка смены
    </asp:Content>

    <asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">     
        <auxctrls:WindowLikeBorderPanel ID="wlbRight"  Title="Карточка смены"  Width="1100" Height="640" runat="server" >
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
                                        <asp:Label Text="Фамилия Имя Отчество *" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="RadLabel1" Text='Нет в ответе web api' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Текущий баланс водителя *" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="RadLabel2" Text='Нет в ответе web api' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="ID смены" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbId" Text='<%# Bind("Shift.Id") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Состояние" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="rtbCheckingAccount" Text='<%# Bind("Shift.State.Name") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Марка и модель автомобиля" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="RadLabel3" Text='<%# Bind("Shift.VehicleModel.FullName") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Регистрационный номер автомобиля" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="RadLabel4" Text='<%# Bind("Shift.RegistrationNumber") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Заказ (идентификатор)" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="RadLabel5" Text='<%# Bind("Order.Id") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Статус заказа" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="RadLabel6" Text='<%# Bind("Order.State.Name") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Начальный адрес" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="RadLabel7" Text='<%# Bind("Order.Start.Address") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Конечный адрес" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="RadLabel8" Text='<%# Bind("Order.End.Address") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Расчетная стоимость" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="RadLabel9" Text='<%# Bind("Order.EstimatedPrice") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Последнее известное положение" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formValueMedium25WithBorder" >
                                        <telerik:RadLabel ID="RadLabel10" Text='<%# Bind("Shift.LastKnownAddress") %>' Width="240px" ReadOnly="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formLabelMedium1" >
                                        <div>&nbsp;</div>
                                    </td>
                                    <td class="formLabelMedium2WithBorder" >
                                        <asp:Label Text="Последний комментарий пассажира" Width="190" runat="server" Font-Bold="true"  />
                                    </td>
                                    <td class="formLabelMedium2WithBorder" colspan="4" >
                                        <telerik:RadLabel ID="RadLabel11" Text='<%# Bind("Order.LastPassengersComment") %>' Width="790px" runat="server" />
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
                            <td style="width:50%;text-align:center;" >
                                <telerik:RadButton ID="RbOrderState" Width="450px" Text="Сменить статус заказа на XXX *" runat="server" /> 
                            </td>
                            <td style="width:50%;text-align:center;" >
                                <telerik:RadButton ID="RbShowOrdersRoute" Width="450px" Text="Просмотреть маршрут заказа *" runat="server" /> 
                            </td>
                        </tr>
                    </table>
                    
                    <div style="width:1000px;height:1px;vertical-align:top;">
                        <asp:HiddenField ID="hfLatitude" ClientIDMode="Static" runat="server" />
                        &nbsp;
                        <asp:HiddenField ID="hfLongitude" ClientIDMode="Static" runat="server" />
                    </div>

                    <div id="map" style="width:992px;height:315px;vertical-align:top;margin:0px;margin-left:8px;margin-top:5px;">
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