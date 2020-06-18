using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions; 
using Microsoft.AspNetCore.Routing;
using SelectPdf;

namespace zabotalaboratory.Common.Razor.RazorRender
{
    internal class RazorRenderService : IRazorRenderService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRazorViewEngine _razorViewEngine;
        private readonly ITempDataProvider _tempDataProvider;

        public RazorRenderService(IServiceProvider serviceProvider,
            IRazorViewEngine razorViewEngine,
            ITempDataProvider tempDataProvider)
        {
            _serviceProvider = serviceProvider;
            _razorViewEngine = razorViewEngine;
            _tempDataProvider = tempDataProvider;
        }

        public async Task<string> GetRenderedHtml<TModel>(TModel viewModel, string templateName)
        {
            var actionContext = this.GetActionContext();
            var view = this.FindView(actionContext, templateName);
            if (view == null)
                return string.Empty;

            using (var outputStream = new StringWriter())
            {
                var viewDataDictionary = new ViewDataDictionary<TModel>(metadataProvider: new EmptyModelMetadataProvider(), modelState: new ModelStateDictionary())
                {
                    Model = viewModel
                };
                var tempDataDictionary = new TempDataDictionary(actionContext.HttpContext, _tempDataProvider);

                var viewContext = new ViewContext(actionContext, view, viewDataDictionary, tempDataDictionary, outputStream, new HtmlHelperOptions());

                await view.RenderAsync(viewContext);

                return outputStream.ToString();
            }
        }

        private IView FindView(ActionContext actionContext, string templateName)
        {
            var getViewResult = _razorViewEngine.GetView(executingFilePath: null, viewPath: templateName, isMainPage: false);
            if (getViewResult.Success)
                return getViewResult.View;

            var findViewResult = _razorViewEngine.FindView(actionContext, templateName, isMainPage: false);
            if (findViewResult.Success)
                return findViewResult.View;

            throw new FileNotFoundException($"Cannot find cshtml template with name {templateName}");
        }

        private ActionContext GetActionContext()
        {
            var httpContext = new DefaultHttpContext
            {
                RequestServices = _serviceProvider
            };
            return new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
        }
    }

}

