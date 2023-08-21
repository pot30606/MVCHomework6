using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MVCHomework6.Data.Database;

namespace MVCHomework6.Helper.Tag
{
    public class TagsTagHelper : TagHelper
    {
        private IUrlHelperFactory UrlHelperFactory { get; }
        private IActionContextAccessor Accessor { get; }

        [HtmlAttributeName("class-name")]
        public string? Class { get; set; }
        [HtmlAttributeName("tag-name")]
        public string? Input { get; set; }
        public readonly string UrlPrefix = "/?q=";


        public TagsTagHelper(IUrlHelperFactory urlHelperFactory, IActionContextAccessor accessor)
        {
            UrlHelperFactory = urlHelperFactory;
            Accessor = accessor;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var actionContext = Accessor.ActionContext;
            var urlHelper = UrlHelperFactory.GetUrlHelper(actionContext);
            output.TagName = null;

            string html = "";
            var tags = Input.Split(',');
            foreach (var item in tags)
            {
                html += $"<a href=\"{UrlPrefix + item}\" class=\"{Class}\">{item}</a>";
            }
            output.Content.SetHtmlContent(html);
        }

    }

}