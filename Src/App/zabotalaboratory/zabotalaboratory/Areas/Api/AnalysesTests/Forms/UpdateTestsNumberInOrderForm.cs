using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Api.AnalysesTests.Forms
{
    public class UpdateTestsNumberInOrderForm
    {
        [Required]
        public int NumberInOrder { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public bool IsUp { get; set; }
    }
}