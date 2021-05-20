using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenPlanConsole
{
    public enum CarType { Electric,Hybrid,Gas}
    class Car
    {
        string Make;
        string Model;
        int year;
        CarType typeCar { get; }
    }

    class ElectricCar:Car
    { 
        CarType typeCar => CarType.Electric;
        int BattCapacity { get; set; } //in KWh
        int RangeInMiles { get; set; }
    }
    class HybridCar:Car
    {
        CarType typeCar => CarType.Hybrid;

    }
    class GasCar:Car
    {
        CarType typeCar => CarType.Gas;
    }
}
