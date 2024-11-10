using SearchingAlgorithms.Models.Entities;

namespace SearchingAlgorithms.ViewModels
{
    public class NodeProcessedViewModel
    {
        public IList<Nodo>? ListPathChoosen { get; set; }
        public IList<Nodo>? ListNodeRevised { get; set; }
    }
}
