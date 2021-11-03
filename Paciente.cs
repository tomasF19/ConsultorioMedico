using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Clinica
{
    class Paciente
    {
        private string nombre, ape, obrasocial;
        private int nroafiliado, dnipac;
        private ArrayList diagnosticos;

        public Paciente(string nombre, string ape, string obrasocial, int nroafiliado, int dnipac)
        {
            this.nombre = nombre;
            this.ape = ape;
            this.obrasocial = obrasocial;
            this.nroafiliado = nroafiliado;
            this.dnipac = dnipac;
            diagnosticos = new ArrayList();

        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Ape { get => ape; set => ape = value; }
        public Paciente(int dni)
        {
            this.dnipac = dni;
        }
        public string Obrasocial { get => obrasocial; set => obrasocial = value; }
        public int Nroafiliado { get => nroafiliado; set => nroafiliado = value; }
        public int Dni { get => dnipac; set => dnipac = value; }
        public ArrayList Diagnosticos{ get { return diagnosticos; } }

        public void agregarDiag(string diag) {
            diagnosticos.Add(diag);
        }
        public void eliminarDiag(string diag)//borra el ultimo diagnostico que coincide con el parametro
        {
            diagnosticos.Reverse();
            diagnosticos.Remove(diag);
            diagnosticos.Reverse();
        }
        public int cantidadDiag() {
            return diagnosticos.Count;
        }

        public ArrayList verDiags() {
            return diagnosticos;
        }
        public string verUltimodiag() {
            return (string)diagnosticos[diagnosticos.Count - 1];
        }

    }
}
