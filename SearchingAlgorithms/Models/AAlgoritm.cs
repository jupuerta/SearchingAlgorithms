using System.Collections.Generic;
using SearchingAlgorithms.Models.Entities;
using SearchingAlgorithms.ViewModels;

namespace SearchingAlgorithms.Models
{
    public class AAlgoritm
    {
        private IList<Nodo> PosibleNodes(Nodo node, List<(int, int)> Movements, List<Nodo> Visited, (int, int) end, int[,] matrix, int n, int m)
        {
            return Movements.Select(x => new Nodo(x.Item1 += node.X, x.Item2 += node.Y, end))
                                .Where(w => w.IsValidNode(matrix, n, m) && !Visited.Any(e => e.X == w.X && e.Y == w.Y))
                                .ToList();                   
        }

        public NodeProcessedViewModel CaminoMasCorto(int[,] matrix, (int, int) begin, (int, int) end)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            List<(int, int)> Movements = new List<(int, int)>()
            {
                (1,-1),
                (1,1),
                (1,0),
                (0,1),
                (-1,0),
                (0,-1),
                (-1,-1),
                (-1,1)
            };

            var nodeInitial = new Nodo(begin.Item1, begin.Item2, end);

            var Visited = new List<Nodo>() { nodeInitial };
            var Revised = new List<Nodo>();

            while (Visited.Count() > 0)
            {
                var ChoosenNode = PosibleNodes(nodeInitial, Movements, Visited, end, matrix, n, m)
                                    .OrderBy(z => z.CosteTotal)
                                    .First();

                Visited.Add(ChoosenNode);

                AddNodeRevised(Revised, PosibleNodes(nodeInitial, Movements, Visited, end, matrix, n, m));

                if (ChoosenNode.X == end.Item1 && ChoosenNode.Y == end.Item2)
                {
                    break;
                }

                nodeInitial = ChoosenNode;
            }
            
            var result = new NodeProcessedViewModel()
            {
                ListPathChoosen = Visited,
                ListNodeRevised = Revised
            };
            return result;
        }

        private void AddNodeRevised(IList<Nodo> Revised, IList<Nodo> PosibleNodes)
        {
            foreach (var Nodo in PosibleNodes)
            {
                Revised.Add(Nodo);
            }
        }
    }
}
