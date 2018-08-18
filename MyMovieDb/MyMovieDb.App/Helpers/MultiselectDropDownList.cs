using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyMovieDb.App.Helpers
{
    public static class MultiselectDropDownList
    {
        public static IHtmlContent MultiselectDropDownListFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression,
            IEnumerable<SelectListItem> collection)
        {
            using (var writer = new StringWriter())
            {
                var label = htmlHelper.LabelFor(expression, new { @class = "control-label" });
                var dropDown = htmlHelper.DropDownListFor(
                    expression,
                    collection,
                    new {@class = "form-control selectpicker", multiple = "true", data_live_search = "true", data_size = "10", data_selected_text_format = "count > 5" });

                writer.Write("<div class=\"form-group\">");
                label.WriteTo(writer, HtmlEncoder.Default);
                dropDown.WriteTo(writer, HtmlEncoder.Default);
                writer.Write("</div>");


                return new HtmlString(writer.ToString());
            }
        }

        public static IHtmlContent MultiselectDropDownListFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression,
            IEnumerable<SelectListItem> collection,
            string id)
        {
            using (var writer = new StringWriter())
            {
                var label = htmlHelper.LabelFor(expression, new { @class = "control-label" });
                var dropDown = htmlHelper.DropDownListFor(
                    expression,
                    collection,
                    new { @class = "form-control selectpicker", id = $"{id}", multiple = "true", data_live_search = "true", data_size = "10", data_selected_text_format = "count > 5" });

                writer.Write("<div class=\"form-group\">");
                label.WriteTo(writer, HtmlEncoder.Default);
                dropDown.WriteTo(writer, HtmlEncoder.Default);
                writer.Write("</div>");


                return new HtmlString(writer.ToString());
            }
        }
    }
}
