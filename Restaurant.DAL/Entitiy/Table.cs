using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Entitiy
{
 public class Table
        
    {
        public Table(string name)
        {
            Name = name;
        }

        public int Id { get;  private set; }
        public string Name { get; private set; }
        public bool IsBook { get; private set; }
    }
}
