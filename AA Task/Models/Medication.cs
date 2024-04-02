using System.ComponentModel.DataAnnotations;

namespace AA_Task.Models
{
    public class Medication
        
    {
        public Medication()
        {
            medicationWarningJoins = new();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string? EnglishName { get; set; }
        public string? usedfor { get; set; }
        public string? about { get; set; }
        public List<MedicationWarningJoin> medicationWarningJoins { get; set; }
    }
}
