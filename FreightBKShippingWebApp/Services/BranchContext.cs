public interface IBranchContext
{
    int BranchId { get; set; }
}

public class BranchContext : IBranchContext
{
    public int BranchId { get; set; }
}
