﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bang_Orientation.Api.Models;

namespace Bang_Orientation.Api.DAL.Interface
{
    public interface IProductInterface
    {
        void Save(Product newProduct);
    }
}
