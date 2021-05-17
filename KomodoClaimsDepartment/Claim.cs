using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDepartment
{
    public enum ClaimType{Car=1,Home,Theft};
    public class Claim
    {
        public Claim() { }
        public Claim(int claimId,ClaimType claimType,string description,decimal claimAmount,DateTime Incident,DateTime Claim) {
            this.ClaimID = claimId;
            this.TypeOfClaim = claimType;
            this.Description = description;
            this.ClaimAmount = claimAmount;
            this.DateOfIncident = Incident;
            this.DateOfClaim = Claim;
        }
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { 
            get 
            {
                TimeSpan DateLegitimacy = DateOfClaim - DateOfIncident;
                int days = DateLegitimacy.Days;
                if (days <= 30)
                    return true;
                else
                    return false;
            } 
        }
    }
}
