﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDepartment
{
    public class ClaimRepository
    {
        private readonly Queue<Claim> _claimsInQueue = new Queue<Claim>();
       
        //Create
        public bool addToQueue(Claim newClaim)
        {
            int count = _claimsInQueue.Count;
            _claimsInQueue.Enqueue(newClaim);
            return _claimsInQueue.Count>count? true:false;
        }
        //Read
        public List<Claim> readQueue()
        {
            return _claimsInQueue.ToList();
        }

        //Delete
        public bool DeleteQueue()
        {  
            int count = _claimsInQueue.Count;

            _claimsInQueue.Dequeue();

            if (_claimsInQueue.Count < count)
                return true;
            else
                return false;
        }

        public Claim getNext()
        {
            return _claimsInQueue.Peek();
        }
    }
}
