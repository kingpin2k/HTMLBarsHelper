using HTMLBarsHelper;
using System.Web;
using System.Web.Optimization;

namespace HTMLBarsHelperWebExample
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/app")
#if DEBUG
                   .Include("~/Scripts/ember-template-compiler.js")
                   .Include("~/Scripts/ember.debug.js")
#else
                   .Include("~/Scripts/ember.prod.js")
#endif
                   .Include("~/Scripts/app.js"));

            bundles.Add(new Bundle("~/bundles/templates", new HTMLBarsTransformer())
                .IncludeDirectory("~/Scripts/templates", "*.hbs", true));

            bundles.Add(new StyleBundle("~/bundles/styles")
                .Include("~/Content/styles.css"));

            BundleTable.EnableOptimizations = true;

#if DEBUG
            BundleTable.EnableOptimizations = false;
#endif
        }
    }
}