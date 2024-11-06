using System.Collections.Generic;

namespace SearchingAlgorithms.Models
{
    public static class AAlgoritm
    {
        private static Nodo PickMinValueNode(Nodo node, List<(int, int)> Movements, List<Nodo> Visited, (int, int) end, int[,] matrix, int n, int m)
        {
            var min = Movements.Select(x => new Nodo(node.X + x.Item1, node.Y + x.Item2, end))
                                .Where(w => w.IsValidNode(matrix, n, m) && !Visited.Any(e => e.X == w.X && e.Y == w.Y))
                                .OrderBy(z => z.CosteTotal)
                                .First();
            return min;
        }

        public static int CaminoMasCorto(int[,] matrix, (int, int) begin, (int, int) end)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            List<(int, int)> Movements = new List<(int, int)>()
            {
                (1,0),
                (0,1),
                (-1,0),
                (0,-1)
            };

            var nodeInitial = new Nodo(begin.Item1, begin.Item2, end);

            var Visited = new List<Nodo>() { nodeInitial };

            while (Visited.Count() > 0)
            {
                var ChoosenNode = PickMinValueNode(nodeInitial, Movements, Visited, end, matrix, n, m);

                Visited.Add(ChoosenNode);

                if (ChoosenNode.X == end.Item1 && ChoosenNode.Y == end.Item2)
                {
                    break;
                }

                nodeInitial = ChoosenNode;
            }
            return Visited.Count();
        }
    }
}
