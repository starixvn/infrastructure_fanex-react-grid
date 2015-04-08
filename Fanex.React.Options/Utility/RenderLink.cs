// -----------------------------------------------------------------------
// <copyright file="RenderLink.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fanex.React.Options.Utility
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class RenderLink
    {
        /// <summary>
        /// Render link.
        /// </summary>
        /// <param name="linkInfo">Link information.</param>
        /// <returns>String value.</returns>
        public static string Render(LinkInformation linkInfo)
        {
            var template = "<span class='react-grid-link' onclick='{0}({1})'>{2}<span>";
            var paramList = string.Empty;
            foreach (var param in linkInfo.Parameters)
            {
                var paramTemplate = param.IsNumber ? "{0}" : "'{0}'";
                paramList += string.IsNullOrEmpty(paramList)
                    ? string.Format(paramTemplate, param.Value)
                    : "," + string.Format(paramTemplate, param.Value);
            }

            return string.Format(template, linkInfo.FunctionName, paramList, linkInfo.DisplayText);
        }
    }
}