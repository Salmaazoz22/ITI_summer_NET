using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Restaurant.DAL.Entitiy
{
    public class User
    {
       

        public User(string name, int age, Enum.Type type)
        {
            Name = name;
            Age = age;
            Type = type;
        }

        public int Id { get;  private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Restaurant.DAL.Enum.Type Type { get; private set; }
    }
}
