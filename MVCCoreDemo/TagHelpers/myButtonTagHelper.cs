using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCCoreDemo.TagHelpers
{
    [HtmlTargetElement("my-button")]
    public class myButtonTagHelper : TagHelper
    {
        public string Type { get; set; }

        public string value { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";
            output.Attributes.Add("type", Type);
            output.Attributes.Add("value", value);
        }
    }
}
