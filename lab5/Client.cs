using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    [Table("Klient")]
    internal class Client
    {
        public Client()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }

       //[Required]
       //[MaxLength(50)]
       
        public string Name { get; set; }

        public List<Order> Orders { get; set; }


    }

}
