<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Global.master" Inherits="Rapport.Support.WUI.Main" CodeBehind="Main.aspx.cs" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="auxctrls" TagName="WindowLikeBorderPanel" Src="~/AuxiliaryWebUserControls/WindowLikeBorderPanel.ascx" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
        Rapport.Support: Главная страница
    </asp:Content>

    <asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">     
        <auxctrls:WindowLikeBorderPanel ID="wlbMain"  Title="Новости"  Width="1100" Height="640" runat="server" >
            <Contents>
                <div class="wlbMain_Container">
                    <div class="testNewsItem">
                        <div class="testNewsItem_Title">
                            Добро пожаловать в приложение Rapport Support!
                        </div>
                        <div class="testNewsItem_Body">
                            <div style="display:block;float:left;width:850px;padding:0px;">
                                <p> Мы приготовили набор отчетов для вас, чтобы было удобно анализировать вашу работу. 
                                Начните с настройки этих отчетов. </p>
                                <p><b>Шаг 1:</b> <a href="Main.aspx">Выберите шаблон</a> </p>
                                <p><b>Шаг 2:</b> <a href="Main.aspx">Выберите данные</a> </p>
                                <p><b>Шаг 3:</b> <a href="Main.aspx">Сохраните отчет на главной странице</a> </p>
                                <BR>
                                <BR>
                            </div>
                            <div style="display:block;float:left;width:150px;padding:0px;">
                                <img src="Images\testNewsPicture.png" style="display:block;padding:0px;margin:0px;border:0px;"/>
                            </div>
                        </div>
                        <div class="testNewsItem_AuthorAndDate">
                            <div class="testNewsItem_AuthorCaption">
                                Автор:
                            </div>
                            <div class="testNewsItem_Author">
                                admin (Павел Морозов)
                            </div>
                            <div class="testNewsItem_DateCaption">
                                Дата:
                            </div>
                            <div class="testNewsItem_Date">
                                01.11.2017
                            </div>
                        </div>
                    </div>
                    <BR>
                    <BR>
                    <div style="display:block;float:left;padding:0px;padding-left:20px;">
                        &nbsp;&nbsp;&nbsp;Содержимое панели это пример того, как можно сделать новости и, например, <BR>
                        обратную связь (назовем это сообщениями). Для того чтобы их сделать надо будет сделать 2-3 контрола с такой версткой как на примере. <BR>
                        Делать их недолго. Но ! Во-первых это низкоприоритетная задача. <BR>
                        Во-вторых. Кроме этого надо сделать поддержку сообщений в БЛ и БД за веб апи. Методы интерфейсам могут быть <BR>
                        в разных разделах/подсистемах Support один из них, но ниже уровнем в микросервисе можно сделать всё один раз во вспомогательном <BR>
                        микросервисе. Ну и, соответственно, в Web UI делать для всех подсистем и всех типов сообщений 1 раз. <BR>
                        Поэтому я целиком новости не делал, а только верстку, чтобы сделать осн страницу как в задании. <BR>
                    </div>
                    <BR>
                    <BR>
                </div>
            </Contents>            
        </auxctrls:WindowLikeBorderPanel>        
    </asp:Content>