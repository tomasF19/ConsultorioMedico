using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Clinica
{
    class Medico
    {
        private string nombremedico, apellidomedico;
        private int dnimedico, matriculamedico;
        //private int limite;
        private ArrayList pacientes;
        private Turno[] turnosdias;
        private Turno turnos;
        //private int num;
        public Medico(string nombremedico, string apellidomedico, int dnimedico, int matriculamedico)
        {
            this.nombremedico = nombremedico;
            this.apellidomedico = apellidomedico;
            this.dnimedico = dnimedico;
            this.matriculamedico = matriculamedico;
            pacientes = new ArrayList();
            turnosdias = new Turno[9];
            for (int i = 0; i < 9; i++)
            {
                Turno iniciarturno = new Turno(" ", 0);
                turnosdias[i] = iniciarturno;
            }
            turnosdias[0].Hora = "08:00";
            turnosdias[1].Hora = "08:30";
            turnosdias[2].Hora = "09:00";
            turnosdias[3].Hora = "09:30";
            turnosdias[4].Hora = "10:00";
            turnosdias[5].Hora = "10:30";
            turnosdias[6].Hora = "11:00";
            turnosdias[7].Hora = "11:30";
            turnosdias[8].Hora = "12:00";

        }

        public string Nombremedico { set { nombremedico = value; }get { return nombremedico; } }
        public string Apellidomedico { set { apellidomedico = value; }get { return apellidomedico; } }
        public int Dnimedico { set { dnimedico = value; }get { return dnimedico; } }
        public int Matriculamedico { set { matriculamedico = value; }get { return matriculamedico; } }
        public ArrayList Pacientes { get { return pacientes; } }
        public Turno Turnos { set { turnos = value; } get { return turnos; } }
        public Turno[] Turnosdias { set { turnosdias = value; } get { return turnosdias; } }

        public void agregarPac(Paciente pac) {
            pacientes.Add(pac);
        }
        public void eliminarPac(Paciente pac) {
            pacientes.Remove(pac);
        }
        public int totalPac() {
            return pacientes.Count;
        }

        public Paciente verPac(int i) {
            return (Paciente)pacientes[i];
        }

        public ArrayList todosPac() {
            return pacientes;
        }
        public string corroborarPaciente(Paciente pac) {
            ArrayList listadodepacientes = new ArrayList();
            string respu = "F";
            listadodepacientes = pacientes;
            foreach (Paciente item in listadodepacientes)
            {
                if (item.Dni == pac.Dni)
                {
                    respu = "F";
                    break;
                }
            }

            return respu;
        }

        public void darTurno(string hora, string nombrepac, int dnipa) {
            turnos = new Turno();
            turnos.Hora = hora;
            turnos.Nombre = nombrepac;
            turnos.Dnipac = dnipa;
            switch (hora)
            {
                case "08:00":turnosdias[0] = turnos;
                    break;
                case "08:30":turnosdias[1] = turnos;
                    break;
                case "09:00":turnosdias[2] = turnos;
                    break;
                case "09:30":turnosdias[3] = turnos;
                    break;
                case "10:00":turnosdias[4] = turnos;
                    break;
                case "10:30":turnosdias[5] = turnos;
                    break;
                case "11:00":turnosdias[6] = turnos;
                    break;
                case "11:30":turnosdias[7] = turnos;
                    break;
                case "12:00":turnosdias[8] = turnos;
                    break;
                default:
                    Console.WriteLine("El turno que ingresó es incorrecto");
                    break;
            }

        }

        public void cancelarTurno(string unaHora) {
            foreach  (Turno k in turnosdias)
            {
                if (k.Hora == unaHora)
                {
                    k.Nombre = " ";
                    k.Dnipac = 0;
                }

            }
        }

        public int totalTurnosOcupados() {
            int cantidadturnos = 0;
            foreach (Turno item in turnosdias)
            {
                if (item.Nombre != " ")
                {
                    cantidadturnos++;
                }
            }


            return cantidadturnos;
        }

        public Turno verTurno(int t) {
            return (Turno)turnosdias[t];
        }

        public Turno[] listaTurnos() {
            return turnosdias;
        } 






    }
        
        



}

