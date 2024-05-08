﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T entity);
        void TRemove(T entity);
        void TUpdate(T entity);
        List<T> GetAll();
        T GetById(int id);
    }
}
