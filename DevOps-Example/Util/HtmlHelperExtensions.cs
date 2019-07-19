using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace DevOps.Util
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent TimeSpanString(this IHtmlHelper htmlHelper, TimeSpan val)
        {
            double days = val.Days;
            double hours = val.Hours + (days * 24);
            double minutes = val.Minutes;
            double seconds = val.Seconds;
            var formattedString = $"{hours:00}:{minutes:00}";

            return new HtmlString("<span>" + formattedString + "</span>");
        }
    }
}
