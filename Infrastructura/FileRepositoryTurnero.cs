using System;
using System.Collections.Generic;
using System.Text;
using Aplicacion.Interfaces;
using Domain;

namespace Infrastructura
{
    public class FileRepositoryTurnero : IRepositoryTurnero
    {
        public Turnero GetTurneroById(string id)
        {
            return new Turnero();
        }
    }
}
