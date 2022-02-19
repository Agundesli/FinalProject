using System;

namespace Ders11_Attribute
{
    class Program
    {
        static void Main(string[] args)
        {
            //Attribute
            //AttributeTargets
            //AttributeUsageAttribute
            //FlagsAttribute
            //SerializableAttribute
            //ObsoleteAttribute
            Customer customer = new Customer { Id = 1, LastName = "Gundeşli", Age = 28 };
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);
            Console.ReadLine();
        }
    }
    class Customer
    {
        //Class içindeki proplarar ilave özellik verebiliriz:Attribute ile
        public int Id { get; set; }
        //[RequiredProperty]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

    }
    class CustomerDal
    {
        public void Add(Customer customer)
        {
            Console.WriteLine(customer.Id+" - "+customer.FirstName+" - "+customer.LastName+" - "+customer.Age);
        }
    }
}
