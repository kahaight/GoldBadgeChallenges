using System;
using System.Collections.Generic;
using ClaimsLibrary;
using KomodoCafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsTests
{
    [TestClass]
    public class ClaimRepositoryTests
    {
        [TestMethod]

        public void GetAllMenuItems_ShouldReturnList()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            Claim numberOne = new Claim(1, ClaimType.Car, "whatever", 1050, new DateTime(2020,2, 8), new DateTime(2020,2,16));
            claimRepo.AddNewClaim(numberOne);
            Claim numberTwo = new Claim(2, ClaimType.Car, "whatever", 1050, new DateTime(2020, 2, 8), new DateTime(2020, 2, 16));
            claimRepo.AddNewClaim(numberTwo);
            Queue<Claim> newQueue = new Queue<Claim>();
            var menuOne = claimRepo.GetAllClaims();
            Assert.IsTrue(menuOne.GetType() == newQueue.GetType());
        }
        [TestMethod]
        public void GetNextClaim_ShouldReturnClaim()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            Claim numberOne = new Claim(1, ClaimType.Car, "whatever", 1050, new DateTime(2020, 2, 8), new DateTime(2020, 2, 16));
            claimRepo.AddNewClaim(numberOne);
            Claim numberTwo = new Claim(2, ClaimType.Car, "whatever", 1050, new DateTime(2020, 2, 8), new DateTime(2020, 2, 16));
            claimRepo.AddNewClaim(numberTwo);
            var nextClaim = claimRepo.GetNextClaim();
            Assert.AreEqual(numberOne.ClaimId, nextClaim.ClaimId);
        }
        [TestMethod]
        public void RemoveClaimFromQueue()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            Claim numberOne = new Claim(1, ClaimType.Car, "whatever", 1050, new DateTime(2020, 2, 8), new DateTime(2020, 2, 16));
            claimRepo.AddNewClaim(numberOne);
            Claim numberTwo = new Claim(2, ClaimType.Car, "whatever", 1050, new DateTime(2020, 2, 8), new DateTime(2020, 2, 16));
            claimRepo.AddNewClaim(numberTwo);
            Queue<Claim> beforeQueue = claimRepo.GetAllClaims();
            int originalCount = beforeQueue.Count;
            claimRepo.RemoveClaim(numberOne);
            Queue<Claim> afterQueue = claimRepo.GetAllClaims();
            int newCount = afterQueue.Count;

            Assert.AreEqual(originalCount - 1, newCount);

        }
    }
}

