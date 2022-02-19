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
            //customerDal.Add(customer);//[Obsolete] ile getirdiğim kısıtlama
            customerDal.AddNew(customer);
            Console.ReadLine();
        }
    }
    [ToTable("Customers")]
    class Customer
    {
        //Class içindeki proplarar ilave özellik,kural verebiliriz:Attribute ile merkezi bir noktada iş kuralları koyabilirim
        //Değerleri girmek zorunlu mesela.
        [RequiredProperty]
        public int Id { get; set; }
        [RequiredProperty]
        public string FirstName { get; set; }
        [RequiredProperty]
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }

    }
    class CustomerDal
    {
        [Obsolete("Dont't use Add, instead use AddNew Method")] 
        public void Add(Customer customer)
        {
            Console.WriteLine(customer.Id+" - "+customer.FirstName+" - "+customer.LastName+" - "+customer.Age);
        }
        public void AddNew(Customer customer)
        {
            Console.WriteLine(customer.Id+" - "+customer.FirstName+" - "+customer.LastName+" - "+customer.Age);
        }
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple =true)]
    class RequiredPropertyAttribute:Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Class)]
    class ToTableAttribute : Attribute
    {
        private string _tablename;

        public ToTableAttribute(string tablename)
        {
            _tablename = tablename;
        }
    }
}
