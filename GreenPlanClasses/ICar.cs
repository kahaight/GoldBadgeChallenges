using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlanClasses
{
    public interface ICar
    {
        int Id { get; set; }
        string Make { get; set; }
        string Model { get; set; }
        int Year { get; set; }
        double Mileage { get; set; }
        string Type { get; }
    }
}
