namespace Runner.IssueTracker
{
    public interface IControllersFactory
    {
        IInsertIssueController CreateInsertIssueController(string repositoryDirectory);
    }

    public class ControllersFactory : IControllersFactory
    {
        public IInsertIssueController CreateInsertIssueController(string repositoryDirectory)
        {
            return new InsertIssueController(new InsertIssueView(), new CommitTempMessage(repositoryDirectory), 
                new LastIssue(repositoryDirectory));
        }
    }
}