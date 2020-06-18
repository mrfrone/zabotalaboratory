using System.Threading.Tasks;

namespace zabotalaboratory.Common.Razor.RazorRender
{
    public interface IRazorRenderService
    {
        Task<string> GetRenderedHtml<TModel>(TModel viewModel, string templateName);
    }
}
