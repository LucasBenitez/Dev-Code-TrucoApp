﻿using Entidades;
using Repositorios.Interfaces;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class AccesorioServicio : IAccesorioServicio
    {
        private readonly IAccesorioRepositorio _accesorioRepositorio;

        public AccesorioServicio(IAccesorioRepositorio accesorioRepositorio)
        {
            _accesorioRepositorio = accesorioRepositorio;
        }
        public List<Accesorio> GetAccesorios()
        {
            return _accesorioRepositorio.GetAccesorios();
        }
    }
}
