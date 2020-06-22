using System;
using System.Collections.Generic;
using System.Text;

namespace zabotalaboratory.Analyses.Datamodel.LaboratoryAnalyses
{
    public class ZabotaGender
    {
        public virtual int? Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string ShortName { get; set; }
    }
}
