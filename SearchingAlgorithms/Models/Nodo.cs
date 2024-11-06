namespace SearchingAlgorithms.Models
{
    public class Nodo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int G { get; set; }
        public int H { get; set; }

        public bool Visited { get; set; }

        public int CosteTotal
        {
            get
            {
                return G + H;
            }
        }

        public Nodo(int _X,
                    int _Y,
                    (int, int) Objetive)
        {
            X = _X; Y = _Y;
            CalculateDistance(Objetive);
        }

        private void CalculateDistance((int, int) objetivo)
        {
            this.H = Math.Abs(X - objetivo.Item1) + Math.Abs(Y - objetivo.Item2);
        }
        public bool IsValidNode(int[,] matrix, int n, int m)
        {
            if (X < n && X >= 0 && Y < m && Y >= 0 && matrix[X, Y] == 0)
            {
                return true;
            }
            return false;
        }
    }
}
