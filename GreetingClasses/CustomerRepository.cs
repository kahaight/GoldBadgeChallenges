using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingClasses
{
    public class CustomerRepository
    {
        private readonly List<ICustomer> _CustomerList = new List<ICustomer>();

        public void AddCustomerToList(ICustomer customer)
        {
            _CustomerList.Add(customer);
        }

        public void RemoveCustomerFromList(ICustomer customer)
        {
            _CustomerList.Remove(customer);
        }

        public ICustomer GetCustomerById(int id)
        {
            foreach(ICustomer customer in _CustomerList)
            {
                if(customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }
        public bool UpdateExistingCustomer(int id, ICustomer newCustomer)
        {
            ICustomer oldCustomer = GetCustomerById(id);
            if (oldCustomer != null)
            {
                oldCustomer.Id = newCustomer.Id;
                oldCustomer.FirstName = newCustomer.FirstName;
                oldCustomer.LastName = newCustomer.LastName;
                oldCustomer.Email = newCustomer.Email;
                return true;
            }
            return false;
        }
        public List<ICustomer> GetCustomerList()
        {
            return _CustomerList;
        }
        public ICustomer GetCustomerByName(string firstName, string lastName)
        {
            foreach (ICustomer customer in _CustomerList)
            {
                if (customer.FirstName == firstName && customer.LastName == lastName)
                {
                    return customer;
                }
            }
            return null;
        }
    }
}
