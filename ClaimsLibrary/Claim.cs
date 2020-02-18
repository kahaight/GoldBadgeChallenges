using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsLibrary
{
    public enum ClaimType { Car, Home, Theft }

    public class Claim
    {
        public Claim() { }

        public Claim(int claimId, ClaimType typeOfClaim, string claimDescription, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimId = claimId;
            TypeOfClaim = typeOfClaim;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
        public int ClaimId { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string ClaimDescription { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                if (Convert.ToInt32(Math.Floor((DateOfClaim - DateOfIncident).Days / 1d)) <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
        }
    }
}
