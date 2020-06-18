using System.ComponentModel.DataAnnotations;

namespace zabotalaboratory.Api.LaboratoryAnalyses.Forms
{
    public class GetLaboratoryAnalyseIdForm
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
