﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces.Actions
{
    public interface IReadRepository<T, Y> where T: class
    {
        IEnumerable<T> GetAll();
        T Get(Y id);
    }
}
