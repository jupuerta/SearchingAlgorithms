using System.Collections.Generic;
using SearchingAlgorithms.Models.Entities;
using SearchingAlgorithms.ViewModels;

namespace SearchingAlgorithms.Models
{
    public class AAlgoritm
    {
        private IList<Nodo> PosibleNodes(Nodo node, List<(int, int)> Movements, List<Nodo> Visited, (int, int) end, int[,] matrix)
        {
            var a = Movements.Select(x => new Nodo((x.Item1 > 0) ? node.X + x.Item1 : node.X + x.Item1,
                                                  (x.Item2 > 0) ? node.Y + x.Item2 : node.Y + x.Item2,
                                                  matrix,
                                                  end)).ToList();
                                return a.Where(w => w.IsValidNode() && !Visited.Any(e => e.X == w.X && e.Y == w.Y))
                                .ToList();
        }

        public NodeProcessedViewModel CaminoMasCorto(int[,] matrix, (int, int) begin, (int, int) end)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            List<(int, int)> Movements = new List<(int, int)>()
            {
                (1,-1),     //suroeste
                (1,1),      //sureste
                (1,0),      //este
                (0,1),      //sur
                (-1,0),     //oeste
                (0,-1),     //norte
                (-1,-1),    //noroeste
                (-1,1)      //suroeste
            };

            var nodeInitial = new Nodo(begin.Item1, begin.Item2, matrix, end);

            var Visited = new List<Nodo>() { nodeInitial };
            var Revised = new List<Nodo>();

            while (Visited.Count() > 0)
            {
                var ListPosibleNodes = PosibleNodes(nodeInitial, Movements, Visited, end, matrix);

                if (ListPosibleNodes.Count != 0)
                {
                    nodeInitial = ListPosibleNodes.OrderBy(z => z.CosteTotal)
                                    .First();
                }

                Revised.Remove(nodeInitial);
                Revised.AddRange(ListPosibleNodes);
                Visited.Add(nodeInitial);


                if (nodeInitial.X == end.Item1 && nodeInitial.Y == end.Item2)
                {
                    break;
                }

                nodeInitial = Revised.OrderBy(x => x.CosteTotal).First();
            }
            
            var result = new NodeProcessedViewModel()
            {
                ListPathChoosen = Visited,
                ListNodeRevised = Revised
            };
            return result;
        }
    }
}
