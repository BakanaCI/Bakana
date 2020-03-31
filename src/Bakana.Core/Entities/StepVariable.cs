using ServiceStack.DataAnnotations;

namespace Bakana.Core.Entities
{
    [UniqueConstraint(nameof(StepId), nameof(Name))]
    public class StepVariable : Variable
    {
        [References(typeof(Step))]
        public string StepId { get; set; }
    }
}