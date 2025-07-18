using CaseStudy.SharedModels;

namespace CaseStudy.Domain.Logs
{
    public class Logs
    {
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ActionType ActionType { get; set; }
        public Employee.Employee Employee { get; set; }

        public Logs() { }

        public Logs(DateTime? createdOn, DateTime? updatedOn, ActionType actionType)
        {
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
            ActionType = actionType;
        }
    }
}
