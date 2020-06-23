using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Web.Areas.Api.AnalysesTypes.Forms
{
    public class UpdateTypesNumberInOrderForm
    {
        [Required]
        public int NumberInOrder { get; set; }

        [Required]
        public bool IsUp { get; set; }
    }
}