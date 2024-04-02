using AA_Task.Models;

namespace AA_Task.Interface
{
    public interface IspecialtyRepo
    {
        bool AddSpecialty(Specialty specialty);
        List<Specialty> GetSpecialties( );
        Specialty GetSpecialtyByName( string name );
    }
}
