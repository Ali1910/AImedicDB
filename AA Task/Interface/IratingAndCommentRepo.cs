namespace AA_Task.Interface
{
    public interface IratingAndCommentRepo
    {
        bool addrating(int doctorid, int appointmnetId, int userId, string rating, string? comment);
    }
}
