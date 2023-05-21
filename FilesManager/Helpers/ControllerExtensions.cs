using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;

namespace FilesManager.Helpers
{
    public static class ControllerExtensions
    {
        public static class ConnectionStrings
        {
            public const string connMSSQL = "connMSSQL";
           
        }
        public class ApplicationInfo
        {
            public string DBConnectionStringName { get; set; }
        }
        public static string GetConnectionString(IConfiguration Configuration)
        {
            var _ApplicationInfo = Configuration.GetSection("ApplicationInfo").Get<ApplicationInfo>();
            string _GetConnStringName = String.Empty;
            _GetConnStringName = Configuration.GetConnectionString(ConnectionStrings.connMSSQL);

            return _GetConnStringName;
        }
        public static async Task<string> RenderViewAsync<TModel>(this Controller controller, string viewName, TModel model, bool partial = false)
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = controller.ControllerContext.ActionDescriptor.ActionName;
            }
            controller.ViewData.Model = model;
            using (var writer = new StringWriter())
            {
                IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult = viewEngine.FindView(controller.ControllerContext, viewName, !partial);
                if (viewResult.Success == false)
                {
                    return $"A view with the name {viewName} could not be found";
                }
                ViewContext viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, writer, new HtmlHelperOptions());
                await viewResult.View.RenderAsync(viewContext);
                return writer.GetStringBuilder().ToString();
            }
        }
    }
}
