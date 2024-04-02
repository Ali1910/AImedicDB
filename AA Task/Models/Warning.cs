using System.ComponentModel.DataAnnotations;

namespace AA_Task.Models
{
    public class Warning
    {
        public Warning()
        {
            medicationWarningJoins = new();
        }
        public int Id { get; set; }
        public string WarningName { get; set; }
        public List<MedicationWarningJoin> medicationWarningJoins { get; set; }
    }
}
