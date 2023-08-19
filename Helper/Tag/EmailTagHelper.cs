using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCHomework6.Helper.Tag
{
    public class EmailTagHelper : TagHelper
    {
        private IUrlHelperFactory UrlHelperFactory { get; }
        private IActionContextAccessor Accessor { get; }
        [HtmlAttributeName("my-subject")]
        public string? Subject { get; set; }

        public EmailTagHelper(IUrlHelperFactory urlHelperFactory, IActionContextAccessor accessor)
        {
            UrlHelperFactory = urlHelperFactory;
            Accessor = accessor;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var childContent = await output.GetChildContentAsync();
            var content = childContent.GetContent();
            string _subject = string.IsNullOrEmpty(Subject) ? "" : $"?subject={Subject}";
            output.Attributes.SetAttribute("href", $"mailto:{content}{_subject}");
            output.Content.SetContent(content);
        }
    }
}