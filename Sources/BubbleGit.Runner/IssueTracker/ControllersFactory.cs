namespace BubbleGit.Runner.IssueTracker
{
    public interface IControllersFactory
    {
        IInsertIssueController CreateInsertIssueController(ICommitTempMessage tempCommitMessage);
    }

    public class ControllersFactory : IControllersFactory
    {
        public IInsertIssueController CreateInsertIssueController(ICommitTempMessage tempCommitMessage)
        {
            return new InsertIssueController(new InsertIssueView(), tempCommitMessage);
        }
    }
}