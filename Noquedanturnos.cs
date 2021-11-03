using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica
{
    class Noquedanturnos:Exception
    {

        public Noquedanturnos() {
            Console.WriteLine("NO QUEDAN TURNOS DISPONIBLES");
        }

    }
}
