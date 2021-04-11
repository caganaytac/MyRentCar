using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
   public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CardHolderName { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
    }
}
