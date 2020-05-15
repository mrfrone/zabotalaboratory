namespace zabotalaboratory.Analyses.Database.Entities
{
    public class AnalysesResult
    {
        public virtual int Id { get; set; }

        public virtual string Result { get; set; }

        public virtual LaboratoryAnalysesTests LaboratoryAnalysesTests { get; set; }
    }
}
