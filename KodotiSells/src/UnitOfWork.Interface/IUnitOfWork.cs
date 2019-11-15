using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        // El IUnitOfWorkAdapter sera el encargado de realizar la conexion 
        // a la base de datos y nos va a permitir acceder al repositorio 
        IUnitOfWorkAdapter Create();
    }
}
