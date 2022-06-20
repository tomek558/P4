using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab5
{
    internal class Order
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        //[ForeignKey("Client")]
        public int ClientId { get; set; }

        public Client Client { get; set; }


    }
}
