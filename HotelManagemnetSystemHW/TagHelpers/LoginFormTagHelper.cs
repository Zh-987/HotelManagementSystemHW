using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HotelManagemnetSystemHW.TagHelpers
{
    public class LoginFormTagHelper : TagHelper
    {
       public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "form";
            output.Attributes.Add("name","login");
            output.Attributes.Add("method", "post");

            string formContent = @"
                <ul>
                    <li>
                        <label for='login'>Login</label>
                        <input type='text' name='login'/>
                    </li>
                    <li>
                        <label for='password'>Password</label>
                        <input type='text' name='password'/>
                    </li>
                    <li>
                        <input type='submit' name='password' value='Login'/>
                    </li>
                </ul>";
            output.Content.SetHtmlContent(formContent);
        }
    }
}
