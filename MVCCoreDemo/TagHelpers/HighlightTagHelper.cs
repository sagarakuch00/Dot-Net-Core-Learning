using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCCoreDemo.TagHelpers
{

    [HtmlTargetElement("*", Attributes = "Highlight")]
    public class HighlightTagHelper : TagHelper
    {
        public string Highlight { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("style", $"background-color:{Highlight}");
        }

    }
}
