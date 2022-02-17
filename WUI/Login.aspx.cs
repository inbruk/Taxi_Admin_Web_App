namespace Rapport.Support.WUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Telerik.Web.UI;

    using Rapport.BusinessTools.AuthenticationEngine;
    using Rapport.AuxiliaryTools.StringExtentions;

    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthenticationEngine ae = AuthenticationEngineHandler.Get();
            if ( ae.IsLoggedIn()==true ) 
            {
                // если мы уже залогинены, то нечего здесь делать
                Response.Redirect("Main.aspx");
            }

            lblServerErrorResponse.Visible = false; // всегда, елси не обработчик, или в нем нет бага аутентификации
        }

        protected async void rbtnEnter_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                String login = rtbEmailLogin.Text;
                String password = rtbPassword.Text;

                // перестраховка, на самом деле спец. символы должны не пропускаться валидаторами
                login = login.RemoveDangerousSymbols();
                password = password.RemoveDangerousSymbols();

                AuthenticationEngine ae = AuthenticationEngineHandler.Get();
                Boolean result = await ae.LogInAsync(login, password);
                if (result == true)
                {
                    Response.Redirect("Main.aspx");
                }
                else
                {
                    lblServerErrorResponse.Visible = true;
                }
            }
        }
    }
}