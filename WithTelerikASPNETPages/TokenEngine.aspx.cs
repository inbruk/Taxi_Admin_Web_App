using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Rapport.BusinessTools.TokenEngine;

public partial class TokenEngine : System.Web.UI.Page 
{
    protected async void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        Rapport.BusinessTools.TokenEngine.TokenEngineController tt = 
            new Rapport.BusinessTools.TokenEngine.TokenEngineController
        ("http://dev.inbest.pro/api/v1/support/", "tokens", "tokens/current");

        sb.Append( tt.ToString() );
        sb.Append( "<BR> LogInAsync:" );

        sb.Append( ( await tt.LogInAsync("admin@taxys.ru", "123") ).ToString() );
        sb.Append("<BR> LogOutAsync:");

        await tt.LogOutAsync();
        sb.Append("<BR> LogInAsync:");

        sb.Append((await tt.LogInAsync("admin@taxys.ru", "123")).ToString());
        sb.Append("<BR> CurrToken:");

        sb.Append(tt.GetCurrentAccessToken().ToString());
        sb.Append("<BR> Update:");

        sb.Append(( await tt.UpdateTokensAsync() ) .ToString());
        sb.Append("<BR> CurrToken:");

        sb.Append(tt.GetCurrentAccessToken().ToString());
        sb.Append("<BR> CheckLoggedInLightVersion:");

        sb.Append(tt.CheckLoggedInLightVersion().ToString());
        sb.Append("<BR> CheckLoggedInHeavyVersionAsync:");

        sb.Append((await tt.CheckLoggedInHeavyVersionAsync()).ToString());
        sb.Append("<BR> CheckLoggedInHeavyVersionAsync:");

        sb.Append((await tt.CheckLoggedInHeavyVersionAsync()).ToString());
        sb.Append("<BR> CheckLoggedInHeavyVersionAsync:");

        sb.Append((await tt.CheckLoggedInHeavyVersionAsync()).ToString());
        sb.Append("<BR> LogOutAsync, CheckLoggedInLightVersion:");

        await tt.LogOutAsync(); 

        sb.Append(tt.CheckLoggedInLightVersion().ToString());
        sb.Append("<BR> CheckLoggedInHeavyVersionAsync:");

        sb.Append((await tt.CheckLoggedInHeavyVersionAsync()).ToString());
        sb.Append("<BR> Logout!");

        await tt.LogOutAsync(); 

        // если включить асинхронность то видно параллельное выполнение запросов
        // если тут await tt.LogOutAsync() поставить точку останова, улетает внутри Update так что работает именно параллельно !!!
        // также поставить точки останова в TokenEngineController там где ловим исключения

        Context.Response.Write(sb.ToString());
    }
}
