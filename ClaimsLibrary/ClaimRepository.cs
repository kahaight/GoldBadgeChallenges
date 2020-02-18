using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsLibrary
{
    public class ClaimRepository
    {
        protected readonly Queue<Claim> _claimRepository = new Queue<Claim>();

        public Queue<Claim> GetAllClaims()
        {
            return _claimRepository;
        }

        public Claim GetNextClaim()
        {
            return _claimRepository.Peek();
        }

        public void AddNewClaim(Claim newClaim)
        {
            _claimRepository.Enqueue(newClaim);
        }

        public void RemoveClaim(Claim newClaim)
        {
            _claimRepository.Dequeue();
        }

    }
}
