namespace SearchingAlgorithms.Models.Entities
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
                    int[,] matrix,
                    (int, int) Objetive)
        {
            X = _X; Y = _Y;
            SetG(matrix);
            CalculateDistance(Objetive);
        }
        private void SetG(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (X < n && X >= 0 && Y < m && Y >= 0)
            {
                G = matrix[X, Y];
            }
            else
            {
                G = 10;  
            }
        }
        private void CalculateDistance((int, int) objetivo)
        {
            this.H = Math.Abs(X - objetivo.Item1) + Math.Abs(Y - objetivo.Item2);
        }
        public bool IsValidNode()
        {
            if (G == 1)
            {
                return true;
            }
            return false;
        }
    }
}
