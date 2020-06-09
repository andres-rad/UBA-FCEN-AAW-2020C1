using Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.UseCases.Cliente
{
    public class LeerQrUC : IUseCase
    {
        private readonly IRepository _repository;

        public LeerQrUC(IRepository repository)
        {
            _repository = repository;
        }

        public LeerQrResponse Procesar(LeerQrRequest request)
        {



            return new LeerQrResponse();
        }
    }
}
