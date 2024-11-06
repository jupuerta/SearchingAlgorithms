using System.Collections.Generic;

namespace SearchingAlgorithms.Models
{
    public static class AAlgoritm
    {
        private static int CalculateDistance((int, int) nodo, (int, int) objetivo)
        {
            return Math.Abs(nodo.Item1 - objetivo.Item1) + Math.Abs(nodo.Item2 - objetivo.Item2);
        }

        private static Nodo PickMinValueNode(List<(int, int)> listPosib, List<(int, int)> movimientos, (int, int) end)
        {
            Nodo MinNode = null;

            movimientos.ForEach(x => new Nodo(x.Item1, x.Item2, 0, AAlgoritm.CalculateDistance(x, end)));
            foreach ((int, int) nodo in movimientos)
            {
                var punt = new Nodo(nodo.Item1, nodo.Item2, 0, AAlgoritm.CalculateDistance(nodo, end));
            }

        }

        public static int CaminoMasCorto(int[,] matrix, (int, int) begin, (int, int) end)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            List<(int, int)> list = new List<(int, int)>()
            {
                (1,0),
                (0,1),
                (-1,0),
                (0,-1)
            };

            var nodeInitial = new Nodo(begin.Item1, begin.Item2, 0, AAlgoritm.CalculateDistance(begin, end));
            var nodeEnd = new Nodo(end.Item1, end.Item2, 0, AAlgoritm.CalculateDistance(begin, end));

            var Visitados = new List<(int, int)>() { begin };

            while (Visitados.Count()>1)
            {
                foreach ((int, int) nodo in list)
                {
                    var punt = new Nodo(nodo.Item1, nodo.Item2, 0, AAlgoritm.CalculateDistance(nodo, end));
                }
            }
            return 0;
        }
    }
}
