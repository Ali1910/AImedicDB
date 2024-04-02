using System.ComponentModel.DataAnnotations.Schema;

namespace AA_Task.Models
{
    public class MedicationWarningJoin
    {
        public int Id { get; set; }
        [ForeignKey(nameof(medication))]
        public int MedicationId{ get; set; }
        [ForeignKey(nameof(warning))]
        public int  WarningId { get; set; }

        public Medication medication { get; set; }
        public Warning warning { get; set; }
    }
}
