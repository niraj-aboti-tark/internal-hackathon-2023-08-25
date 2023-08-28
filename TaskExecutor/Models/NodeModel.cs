namespace TaskExecutor.Models
{
    public class NodeModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Address { get; set; }
        public NodeStatus Status { get; set; } = NodeStatus.Available;
    }

    public enum NodeStatus
    {
        Available,
        Busy,
        Offline,
    }
}
