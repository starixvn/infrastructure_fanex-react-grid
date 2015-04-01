// -----------------------------------------------------------------------
// <copyright file="PagingOptions.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fanex.React.Options.Core
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PagingOptions
    {
        public PagingOptions()
        {
            PageIndex = 0;
            PageSize = 100;
            PageSizeList = new List<int>() { 50, 100, 200, 500 };
        }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public List<int> PageSizeList { get; set; }

        public string PagingCallBack { get; set; }

        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1407:ArithmeticExpressionsMustDeclarePrecedence", Justification = "Reviewed.")]
        public int NumberOfPage
        {
            get
            {
                return PageSize != 0
                    ? TotalItems % PageSize == 0
                        ? TotalItems / PageSize
                        : TotalItems / PageSize + 1
                    : 0;
            }
        }

        public int TotalItems { get; set; }
    }
}