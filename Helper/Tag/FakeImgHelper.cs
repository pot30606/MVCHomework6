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
    public class FakeImgHelper : TagHelper
    {

        private IUrlHelperFactory UrlHelperFactory { get; }
        private IActionContextAccessor Accessor { get; }

        [HtmlAttributeName("my-width")]
        public string? Width { get; set; }
        [HtmlAttributeName("my-height")]
        public string? Height { get; set; }
        //https://unsplash.it/200/200/?random
        public readonly string Url = "https://unsplash.it/WIDTH/HEIGHT/?random";

        public FakeImgHelper(IUrlHelperFactory urlHelperFactory, IActionContextAccessor accessor)
        {
            UrlHelperFactory = urlHelperFactory;
            Accessor = accessor;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var actionContext = Accessor.ActionContext;
            var urlHelper = UrlHelperFactory.GetUrlHelper(actionContext);
            output.TagName = "img";
            string _url = Url.Replace("HEIGHT", Height ?? "200").Replace("WIDTH", Width ?? "200");
            output.Attributes.SetAttribute("src", _url);
            output.Attributes.SetAttribute("alt", $"這是一張假圖{Width}x{Height}");
        }

    }
}