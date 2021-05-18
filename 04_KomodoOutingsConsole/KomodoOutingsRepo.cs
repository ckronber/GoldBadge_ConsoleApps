using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KomodoOutingsConsole
{
    class KomodoOutingsRepo
    {
        List<KomodoOutings> _outingEvent = new List<KomodoOutings>() { };

        //Create
        public bool AddEvent(KomodoOutings Outing)
        {
            int count = _outingEvent.Count;
            _outingEvent.Add(Outing);
            return _outingEvent.Count > count ? true : false;
        }
        //Read
        public List<KomodoOutings> ReadEvents()
        {
            return _outingEvent;
        }
        
        //Delete
        public bool DeleteEvent(KomodoOutings Outing)
        {
            int count = _outingEvent.Count;
            _outingEvent.Remove(Outing);
            return _outingEvent.Count < count ? true : false;
        }
    }
}
