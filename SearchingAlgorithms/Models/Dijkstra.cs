namespace SearchingAlgorithms.Models
{
    public class Dijkstra
    {
        public int CaminoMasCortoConCostos(int[,] matriz)
        {
            int n = matriz.GetLength(0);
            int m = matriz.GetLength(1);
            int[] dx = { 1, 0 };
            int[] dy = { 0, 1 };

            int[,] matrizCostos = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrizCostos[i, j] = int.MaxValue;
                }
            }
            var prioridad = new SortedSet<(int costo, int x, int y)>();
            prioridad.Add((matriz[0, 0], 0, 0));
            matrizCostos[0, 0] = matriz[0, 0];

            while (prioridad.Count > 0)
            {
                var (costoActual, x, y) = prioridad.Min;
                prioridad.Remove(prioridad.Min);

                if (x == n - 1 && y == m - 1)
                    return costoActual;

                for (int i = 0; i < 2; i++)
                {
                    int nuevoX = x + dx[i];
                    int nuevoY = y + dy[i];

                    if (nuevoX < n && nuevoY < m)
                    {
                        int nuevoCosto = costoActual + matriz[nuevoX, nuevoY];

                        if (nuevoCosto < matrizCostos[nuevoX, nuevoY])
                        {
                            prioridad.Remove((matrizCostos[nuevoX, nuevoY], nuevoX, nuevoY));
                            matrizCostos[nuevoX, nuevoY] = nuevoCosto;
                            prioridad.Add((nuevoCosto, nuevoX, nuevoY));
                        }
                    }
                }
            }
            return -1;
        }
    }
}
