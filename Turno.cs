using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica
{
    class Turno
    {
        private string nombre, hora;
        private int dnipac;

        public Turno(string nombre, string hora, int dnipac)
        {
            this.nombre = nombre;
           
            this.hora = hora;
            this.dnipac = dnipac;
        }
        public Turno(string nombre, int dnipac)
        {
            this.nombre = nombre;
            this.dnipac = dnipac;
        }
        public Turno()
        { 
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Dnipac { get => dnipac; set => dnipac = value; }
        public string Hora { get => hora; set => hora = value; }


       

    }
}
