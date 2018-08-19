using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyMovieDb.Common.ViewModels.Users;

namespace MyMovieDb.App.Helpers
{
    public static class MoviesTable
    {
        public static IHtmlContent MoviesTableFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression,
            IEnumerable<MoviePersonFilmographyViewModel> collection)
        {
            using (var writer = new StringWriter())
            {
                writer.Write("<table class=\"table table-striped\"><thead></thead><tbody>");
                foreach (var item in collection)
                {
                    writer.Write($"<tr><td>");
                    writer.Write($"<a href=\"\\Movies\\Details\\{item.Id}\">{item.Title}</a>");

                    if (item.Status != "Completed")
                    {
                        writer.Write($"&nbsp;&nbsp;<span class=\"text-danger\">({item.Status})</span>");
                    }

                    if (item.Year != "1")
                    {
                        writer.Write($"</td><td>{item.Year}</td>");
                    }
                    else
                    {
                        writer.Write($"</td><td>n/a</td>");
                    }
                }

                writer.Write("</tbody></table>");

                return new HtmlString(writer.ToString());
            }

        }
    }
}
