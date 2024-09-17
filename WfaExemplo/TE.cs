namespace WfaExemplo
{
    public class TE : Triangulo
    {
        private double baseT;

        public double BaseT
        {
            get { return baseT; }
            set { baseT = value; }
        }

        private double alturaT;

        public double AlturaT
        {
            get { return alturaT; }
            set { alturaT = value; }
        }

        public override double CalcularArea()
        {
            return (baseT * alturaT) / 2;
        }

        public override double CalcularPerimetro()
        {
            return baseT * 3;
        }
        public override string ToString()
        {
            return $"Triangulo E. ({baseT} , {alturaT})";
        }
    }
}