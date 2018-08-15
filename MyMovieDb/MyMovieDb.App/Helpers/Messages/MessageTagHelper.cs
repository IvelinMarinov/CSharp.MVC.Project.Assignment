using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyMovieDb.App.Helpers.Messages
{
    public class MessageTagHelper : TagHelper
    {
        public string Type { get; set; }

        public string Message { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var result = new StringBuilder();
            result
                .Append($"<div class=\"alert alert-{this.Type.ToLower()} alert-dismissible show\">")
                .Append("<button type = \"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>")
                .Append(this.Message)
                .Append("</div>");

            output.Content.SetHtmlContent(result.ToString());
        }
    }
}
