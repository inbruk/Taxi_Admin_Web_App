<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Global.master" Inherits="Rapport.Support.WUI.FinanceRecords" CodeBehind="FinanceRecords.aspx.cs" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="auxctrls" TagName="WindowLikeBorderPanel" Src="~/AuxiliaryWebUserControls/WindowLikeBorderPanel.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
        Rapport.Support: Платежи
    </asp:Content>

    <asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">     
        <auxctrls:WindowLikeBorderPanel ID="wlbRight"  Title="Платежи"  Width="1100" Height="640" runat="server" >
            <Contents>

                    <telerik:RadGrid ID="mainGrid" Width="1074px" Height="590px" runat="server" ClientSettings-Selecting-AllowRowSelect="False"
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

                                <telerik:GridBoundColumn UniqueName="CreatedAt" DataField="CreatedAt" 
                                    HeaderText="Дата и время обработки операции" HeaderStyle-Width="120" />

                                <telerik:GridBoundColumn UniqueName="PaymentSystemStr" DataField="PaymentSystemStr" 
                                    HeaderText="Дата и время обработки операции" HeaderStyle-Width="120" />

                                <telerik:GridBoundColumn UniqueName="RecordTypeStr" DataField="RecordTypeStr" 
                                    HeaderText="Тип записи" HeaderStyle-Width="100" />

                                <telerik:GridBoundColumn UniqueName="Source.Name" DataField="Source.Name" 
                                    HeaderText="Контрагент отправитель" HeaderStyle-Width="200" />

                                <telerik:GridBoundColumn UniqueName="Destination.Name" DataField="Destination.Name" 
                                    HeaderText="Контрагент получатель" HeaderStyle-Width="200" />

                                <telerik:GridBoundColumn UniqueName="Comment" DataField="Comment" 
                                    HeaderText="Комментарий" HeaderStyle-Width="200" />

                                <telerik:GridBoundColumn UniqueName="Amount" DataField="Amount" 
                                    HeaderText="Сумма" HeaderStyle-Width="100" />

                                <telerik:GridBoundColumn UniqueName="Commission" DataField="Commission" 
                                    HeaderText="Комиссия (сбор) платежной системы" HeaderStyle-Width="100" />

                                <telerik:GridBoundColumn UniqueName="Balance" DataField="Balance" 
                                    HeaderText="Сальдо" HeaderStyle-Width="100" />

                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>

            </Contents>            
        </auxctrls:WindowLikeBorderPanel>        
    </asp:Content>
