using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HotelManagemnetSystemHW.TagHelpers
{
    public class ListTagHelper : TagHelper
    {
        public List<string> Items { get; set; } = new();

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";
            string listContent = "";
            foreach (string item in Items)
            {
                listContent = $"{listContent}<li>{item}</li>";
            }
            output.Content.SetHtmlContent(listContent);
        }
    }
}
