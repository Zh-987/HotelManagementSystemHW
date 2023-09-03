using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace HotelManagemnetSystemHW.HtmlHelpers
{
    public static class LoginFormHtmlHelper
    {
        public static HtmlString CreateLoginForm(this IHtmlHelper html)
        {
            TagBuilder form = new TagBuilder("form");
            form.Attributes.Add("name", "login");
            form.Attributes.Add("method", "post");

            TagBuilder ul = new TagBuilder("ul");
            TagBuilder liLogin = new TagBuilder("li");
            TagBuilder liPassword = new TagBuilder("li");
            TagBuilder liSubmit = new TagBuilder("li");


            TagBuilder labelLogin = new TagBuilder("label");
            labelLogin.Attributes.Add("for", "login");
            labelLogin.InnerHtml.Append("login");

            TagBuilder inputLogin = new TagBuilder("input");
            inputLogin.Attributes.Add("type", "text");
            inputLogin.Attributes.Add("name", "login");

            TagBuilder labelPassword = new TagBuilder("label");
            labelPassword.Attributes.Add("for", "password");
            labelPassword.InnerHtml.Append("password");

            TagBuilder inputPassword = new TagBuilder("input");
            inputPassword.Attributes.Add("type", "text");
            inputPassword.Attributes.Add("name", "password");

            TagBuilder button = new TagBuilder("input");
            button.Attributes.Add("type", "submit");
            button.Attributes.Add("value", "Login");

            liLogin.InnerHtml.AppendHtml(labelLogin);
            liLogin.InnerHtml.AppendHtml(inputLogin);
            ul.InnerHtml.AppendHtml(liLogin);

            liPassword.InnerHtml.AppendHtml(labelPassword);
            liPassword.InnerHtml.AppendHtml(inputPassword);
            ul.InnerHtml.AppendHtml(liPassword);

            liSubmit.InnerHtml.AppendHtml(button);
            ul.InnerHtml.AppendHtml(liSubmit);

            form.InnerHtml.AppendHtml(ul);

            using var writer = new StringWriter();
            form.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
    }
}
