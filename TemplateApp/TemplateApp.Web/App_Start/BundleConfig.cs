using System.Web.Optimization;

namespace TemplateApp.Web
{
	public class BundleConfig
	{
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
		{
            // When <compilation debug="true" />, MVC4 will render the full readable version. When set to <compilation debug="false" />, the minified version will be rendered automatically
            //BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap")
                .Include("~/Content/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrap-theme")
                .Include("~/Content/bootstrap-theme.css"));

            bundles.Add(new StyleBundle("~/Content/Site")
                .Include("~/Content/Site.css"));
		}
	}
}
