using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double workingAirConditionerAdditionalConsumption = 1.4;

        private AirConditionerCondition airConditionerCondition;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.airConditionerCondition = AirConditionerCondition.On;
        }

        protected override double AdditionalConsumption =>
            airConditionerCondition == AirConditionerCondition.On ?
            workingAirConditionerAdditionalConsumption : this.FuelConsumption;

        public void SwitchOnAirConditioner()
        {
            this.airConditionerCondition = AirConditionerCondition.On;
        }

        public void SwitchOffAirConditioner()
        {
            this.airConditionerCondition = AirConditionerCondition.Off;
        }
    }
}
