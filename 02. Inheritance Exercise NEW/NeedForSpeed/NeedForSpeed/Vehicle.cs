namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption { get => DefaultFuelConsumption; }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public Vehicle(int horsePower, double fuel)
        {
            Fuel = fuel;
            HorsePower = HorsePower;
        }
        public virtual void Drive(double kilometers)
        {
            double consumed = kilometers * FuelConsumption;
            if (this.Fuel >= consumed)
            {  
                Fuel = Fuel - consumed;
            }
            
        }
    }
}
