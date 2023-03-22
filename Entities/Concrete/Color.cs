﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;


namespace Entities.Concrete
{
   public class Color :IEntity
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
}
