using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace HotelManagemnetSystemHW.Components
{
    public class FooterComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Dictionary<string, string> footerData)
        {
            return new HtmlContentViewComponentResult(
              new HtmlString($"<div><img src='{footerData["logoLink"]}'><label>{footerData["companyName"]}</label></div>")
          );
        }
    }
}
