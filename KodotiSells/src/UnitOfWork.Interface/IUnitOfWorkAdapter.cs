using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork.Interface
{
    // esta interfaz implementa IDisposable porque va estar dentro
    // del scope using y una vez que finalice el using se va a liberar 
    // el recurso cerrando la cadena de conexion y todo lo que tenga que 
    // liberar de la memoria
    public interface IUnitOfWorkAdapter: IDisposable
    {
        // Acceder a los repositorios
        IUnitOfWorkRepository Repositories { get; }
        // Confirmar los cambios y guardar

        // este metodo va a confirmar los cambios por ejemplo 
        // si hacemos un update, delete o insert o varias operaciones
        // transaccionales hacia la base de datos, las operaciones se 
        // confirmaran al finalizar
        void SaveChanges();
    }
}
