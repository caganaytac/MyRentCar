﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
   public class UserCreditScore : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CreditScore { get; set; }
    }
}
