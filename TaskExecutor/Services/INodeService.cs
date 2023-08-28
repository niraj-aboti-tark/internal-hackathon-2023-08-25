using TaskExecutor.Models;

namespace TaskExecutor.Services
{
    public interface INodeService
    {
        string Add(string name, string address);
        void Remove(string name);
        NodeModel Update(NodeModel node);
        NodeModel UpdateStatus(NodeModel node);
        IEnumerable<NodeModel> Get(Func<NodeModel, bool> predicate);
    }
}
