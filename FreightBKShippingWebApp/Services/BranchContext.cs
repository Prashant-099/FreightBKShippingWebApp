using FreightBKShippingWebApp.Model;
public interface IBranchContext
{
    int BranchId { get; }

    List<Branch> UserBranches { get; }   // 🔥 object list

    event Action? OnBranchChanged;

    void SetBranch(int branchId);
    void SetUserBranches(List<Branch> branches);
}


public class BranchContext : IBranchContext
{
    private int _branchId;

    public int BranchId => _branchId;

    public List<Branch> UserBranches { get; private set; } = new();

    public event Action? OnBranchChanged;

    public void SetBranch(int branchId)
    {
        if (_branchId == branchId)
            return;

        _branchId = branchId;
        OnBranchChanged?.Invoke();
    }

    public void SetUserBranches(List<Branch> branches)
    {
        UserBranches = branches ?? new();
        OnBranchChanged?.Invoke();
    }
}
