using System.Diagnostics.CodeAnalysis;
using React;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Fanex.React.Grid.ReactConfig), "Configure")]

namespace Fanex.React.Grid
{
    /// <summary>
    /// REACT CONFIG.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1027:TabsMustNotBeUsed", Justification = "Reviewed.")]
    public static class ReactConfig
    {
        public static void Configure()
        {
            ReactSiteConfiguration.Configuration = new ReactSiteConfiguration()
                .AddScript("~/Scripts/test.js");

            ReactSiteConfiguration.Configuration = new ReactSiteConfiguration()
                .AddScript("~/Scripts/ReactGrid/react-grid.js");
        }
    }
}