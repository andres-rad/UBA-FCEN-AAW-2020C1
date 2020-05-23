using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Interfaces
{
    public interface IRepositoryTurnero
    {
        Turnero GetTurneroById(string id); 
    }
}
