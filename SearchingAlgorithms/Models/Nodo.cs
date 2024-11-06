namespace SearchingAlgorithms.Models
{
    public class Nodo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int G { get; set; }
        public int H { get; set; }

        public int CosteTotal 
        { 
            get 
            { 
                return G + H;
            } 
        }

        public Nodo(int _X,
                    int _Y,
                    int _G,
                    int _H)
        {
            X = _X; Y = _Y; 
            G = _G; H = _H; 
        }
    }
}
