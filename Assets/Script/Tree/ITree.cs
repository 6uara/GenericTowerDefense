public interface ITree
{
    int Root();
    ITree LeftBranc();
    ITree RightBranch();
    bool EmptyTree();
    void InicilizeTree();
    void AddElement(int x);
    void RemoveElement(int x);
}
