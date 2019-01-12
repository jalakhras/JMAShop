using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMAShop.TagHelpers
{
    [HtmlTargetElement("table", Attributes = "header")]
    public class TableHeaderTagHelper: TagHelper { 
      public string HeaderContent { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        base.Process(context, output);

        TagBuilder header = new TagBuilder("h2");
        header.InnerHtml.Append(HeaderContent);
        output.PreElement.SetHtmlContent(header);
    }
}
}
