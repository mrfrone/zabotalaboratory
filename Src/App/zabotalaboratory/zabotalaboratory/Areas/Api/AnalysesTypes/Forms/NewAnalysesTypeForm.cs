using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Web.Areas.Api.AnalysesTypes.Forms
{
    public class NewAnalysesTypeForm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Number1C { get; set; }
    }
}
