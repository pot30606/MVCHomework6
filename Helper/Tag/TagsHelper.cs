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
    public class TagsHelper : TagHelper
    {
        private IUrlHelperFactory UrlHelperFactory { get; }
        private IActionContextAccessor Accessor { get; }

        [HtmlAttributeName("tag-name")]
        public string? TagName { get; set; }
        public readonly string UrlPrefix = "/?q=";

        public TagsHelper(IUrlHelperFactory urlHelperFactory, IActionContextAccessor accessor)
        {
            UrlHelperFactory = urlHelperFactory;
            Accessor = accessor;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var actionContext = Accessor.ActionContext;
            var urlHelper = UrlHelperFactory.GetUrlHelper(actionContext);
            output.TagName = "a";
            output.Attributes.SetAttribute("href", UrlPrefix + TagName);
            output.Content.SetHtmlContent(TagName);
        }

    }

}