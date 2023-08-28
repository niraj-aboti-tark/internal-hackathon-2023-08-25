using TaskExecutor.Models;

namespace TaskExecutor.Services
{
    public class NodeService : INodeService
    {
        public List<NodeModel> Nodes { get; private set; } = new();

        public IEnumerable<NodeModel> Get(Func<NodeModel, bool> predicate)
        {
            return Nodes.Where(predicate);
        }
        public string Add(string name, string address)
        {
            var node = new NodeModel {  Name = name, Address = address };
            Nodes.Add(node);
            return node.Id;
        }

        public void Remove(string name)
        {
            var node = Nodes.Find(x => x.Name.Equals(name));
            if (node != null)
            {
                Nodes.Remove(node);
            }
        }

        public NodeModel Update(NodeModel node)
        {
            var existingNode = Nodes.Find(x => x.Id == node.Id);
            if (existingNode != null)
            {
                existingNode.Name = node.Name;
                existingNode.Address = node.Address;
                existingNode.Status = node.Status;
            }
            return existingNode;
        }
        public NodeModel UpdateStatus(NodeModel node)
        {
            var existingNode = Nodes.Find(x=>x.Id == node.Id);
            if (existingNode != null)
            {
                existingNode.Status =  node.Status;
            }

            return existingNode;
        }
    }
}
