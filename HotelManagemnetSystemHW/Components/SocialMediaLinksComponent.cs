using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace HotelManagemnetSystemHW.Components
{
    public class SocialMediaLinksComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Dictionary<string, string> socialMediaLinks)
        {
            string socialMediaLinksContent = "";

            foreach (var link in socialMediaLinks)
            {
                socialMediaLinksContent = $"{socialMediaLinksContent} <a href='{link.Value}'>{link.Key}</a>";
            }
            return new HtmlContentViewComponentResult(
              new HtmlString(socialMediaLinksContent)
          );
        }
    }
}
