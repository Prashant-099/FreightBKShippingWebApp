public interface IBranchContext
{
    int BranchId { get; }
    event Action? OnBranchChanged;   // ✅ ADD THIS
    void SetBranch(int branchId);
}

public class BranchContext : IBranchContext
{
    private int _branchId;

    public int BranchId => _branchId;

    public event Action? OnBranchChanged;

    public void SetBranch(int branchId)
    {
        if (_branchId == branchId)
            return;

        _branchId = branchId;
        OnBranchChanged?.Invoke(); // 🔥 notify
    }
}
