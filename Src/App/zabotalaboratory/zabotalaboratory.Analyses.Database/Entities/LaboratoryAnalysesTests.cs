namespace zabotalaboratory.Analyses.Database.Entities
{
    public class LaboratoryAnalysesTests
    {
        public virtual int Id { get; set; }

        public virtual int Number1C { get; set; }

        public virtual string Name { get; set; }
        
        public virtual AnalysesTypes AnalysesType { get; set; }
    }
}
