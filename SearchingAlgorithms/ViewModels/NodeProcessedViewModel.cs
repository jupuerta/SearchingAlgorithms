using SearchingAlgorithms.Models.Entities;

namespace SearchingAlgorithms.ViewModels
{
    public class NodeProcessedViewModel
    {
        public IList<NodeA>? ListPathChoosen { get; set; }
        public IList<NodeA>? ListNodeRevised { get; set; }
    }
}
