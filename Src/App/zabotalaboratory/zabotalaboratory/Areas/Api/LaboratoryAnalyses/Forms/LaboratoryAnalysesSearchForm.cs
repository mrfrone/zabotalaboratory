namespace zabotalaboratory.Api.LaboratoryAnalyses.Forms 
{ 
    public class LaboratoryAnalysesSearchForm
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PatronymicName { get; set; }

        public string PickUpDate { get; set; }

        public int Page { get; set; }
    }
}
