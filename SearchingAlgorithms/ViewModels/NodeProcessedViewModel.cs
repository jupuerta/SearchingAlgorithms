using SearchingAlgorithms.Models.Entities;

namespace SearchingAlgorithms.ViewModels
{
    public class NodeProcessedViewModel<T>
    {
        public IList<T>? ListPathChoosen { get; set; }
        public IList<T>? ListNodeRevised { get; set; }
    }
}
