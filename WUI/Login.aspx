<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Rapport.Support.WUI.Login" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Rapport.Support: Страница входа</title>

    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="GlobalStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

	    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
		    <Scripts>
			    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
			    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
			    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
		    </Scripts>
	    </telerik:RadScriptManager>

        <telerik:RadSkinManager ID="RadSkinManager1" runat="server" Skin="Office2010Silver" />

        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" 
            DecoratedControls="All" EnableRoundedCorners="true" EnableTheming="true" />
        
        <div class="loginPageBlock">
            <div class="loginMiddleBlock">
                <div class="loginHeaderPart">
                    <div class="loginRapportPanel">
                        <div class="loginRapportDiv" >Rapport</div>
                    </div>                    
                </div>
                <div class="loginBodyPart">
                    <div class="loginBodyItem">
                        <div class="loginCaption">
                            Войдите в Rapport
                        </div>
                    </div>
                    <div class="loginBodyTextOrButton">
                        <div class="loginText">
                            Пожалуйста, введите свои учетные данные, полученные при регистрации. <BR>
                            В пароле важен регистр (ПРОПИСНЫЕ или строчные). <BR>
                            Разрешенные символы: большие и маленькие латинские буквы, цифры, @, -, _
                        </div>
                    </div>
                    <div class="loginBodyItem">
                        <div class="loginItemCaption">
                            <asp:Label Text="Логин (Email)" AssociatedControlID="rtbEmailLogin" runat="server" />                            
                        </div>
                        <div class="loginItemControl">
                            <telerik:RadTextBox ID="rtbEmailLogin" TextMode="SingleLine"  MaxLength="64" Font-Size="12px" 
                                 Width="320px" Height="25px" runat="server"></telerik:RadTextBox>
                        </div>
                    </div>
                    <div class="loginBodyItem">
                        <div class="loginItemCaption">
                            <asp:Label Text="Пароль" AssociatedControlID="rtbPassword" runat="server" /> 
                        </div>
                        <div class="loginItemControl">
                            <telerik:RadTextBox ID="rtbPassword" TextMode="Password"  MaxLength="32"  Font-Size="12px" 
                                Width="150px" Height="25px" runat="server"></telerik:RadTextBox>
                            <span class="loginItemForgottenPassword">
                                <a href="Main.aspx">Забыли пароль?</a> 
                            </span>
                        </div>
                    </div>
                    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                        <div class="loginItemValidatorts">
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic"
                                    ControlToValidate="rtbEmailLogin" ErrorMessage="Поле ввода ЛОГИН должно быть заполнено!<BR>"
                                />

                                <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="rtbEmailLogin" 
                                    ValidationExpression="^[a-zA-Z0-9@\.\-_]*$"
                                    ErrorMessage="Поле ввода ЛОГИН не должно содержать запрещенных символов !<BR>"
                                />

                                <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="rtbEmailLogin" 
                                    ValidationExpression="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"
                                    ErrorMessage="Поле ввода ЛОГИН должно содержать корректный email !<BR>"
                                />

                                <asp:RequiredFieldValidator runat="server" Display="Dynamic"
                                    ControlToValidate="rtbPassword" ErrorMessage="Поле ввода ПАРОЛЬ должно быть заполнено!<BR>"
                                />
                            
                                <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="rtbPassword" ValidateRequestMode="Disabled"
                                    ValidationExpression="^[a-zA-Z0-9@\.\-_]*$"
                                    ErrorMessage="Поле ввода ПАРОЛЬ не должно содержать запрещенных символов!<BR>"
                                />

                                <asp:Label ID="lblServerErrorResponse" 
                                    Text="Логин и/или пароль не подходят. Или проблемы с сервером WebApi. Поробуйте еще раз." 
                                    Visible="true" runat="server" />  

                        </div>
                        <div class="loginBodyEnterButton">
                            <div class="loginItemButton">
                                <telerik:RadButton ID="rbtnEnter" runat="server" Width="188px" Text="Войти" OnClick="rbtnEnter_Click" />
                            </div>
                        </div>
                    </telerik:RadAjaxPanel>

                </div>
            </div>
        </div>

    </form>
</body>
</html>
