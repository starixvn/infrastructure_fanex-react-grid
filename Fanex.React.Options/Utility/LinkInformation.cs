// -----------------------------------------------------------------------
// <copyright file="LinkInformation.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fanex.React.Options.Utility
{
    using System.Collections.Generic;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LinkInformation
    {
        public LinkInformation()
        {
            DisplayText = string.Empty;
            FunctionName = string.Empty;
            ClassName = string.Empty;
            Parameters = new List<LinkParameter>();
        }

        public string DisplayText { get; set; }

        public string FunctionName { get; set; }

        public string ClassName { get; set; }

        public List<LinkParameter> Parameters { get; set; }
    }
}