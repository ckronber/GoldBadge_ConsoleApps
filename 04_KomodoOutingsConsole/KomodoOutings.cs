using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KomodoOutingsConsole
{
    public enum EventType{Golf=1,Bowling,Amusement_Park,Concert}
    public class KomodoOutings
    {
        public KomodoOutings() { }
        public KomodoOutings(EventType typeOfEvent,int numberOfEmployees,DateTime eventDate,decimal costPerPerson,decimal totalCost)
        {
            this.TypeOfEvent = typeOfEvent;
            this.NumberOfEmployees = numberOfEmployees;
            this.EventDate = eventDate;
            this.CostPerPeron = costPerPerson;
            this.TotalCost = totalCost;
        }

        public EventType TypeOfEvent { get; set; }
        public int NumberOfEmployees { get; set; }
        public DateTime EventDate { get; set; }
        public decimal CostPerPeron { get; set; }
        public decimal TotalCost { get; set; }
    }
}
