using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
    public class Cuenta
    {
        protected double saldo;
        protected int ni, nr;
        protected double tasaAnual;
        protected double comisionMensual;
        public bool correcto = true;

        public double Saldo
        {
            get => saldo;
            protected set
            {
                if (value >= 0)
                    saldo = value;
                else
                {
                    Console.WriteLine("Error saldo negativo");
                    correcto = false;
                }
            }
        }

        protected double TasaAnual
        {
            get => tasaAnual; set
            {
                if (value >= 0 && value < 15)
                    tasaAnual = value;
                else
                {
                    correcto = false;
                    Console.WriteLine("Error Tasa no valida");
                }
            }
        }

        public Cuenta(double saldo, double tasaAnual)
        {
            Saldo = saldo;
            TasaAnual = tasaAnual;
            ni = 0;
            nr = 0;
            comisionMensual = 0;
        }

        public void Ingresar(double cant)
        {
            saldo += cant;
            ni++;
        }
        public void Retirar(double cant)
        {
            Saldo -= cant;
            nr++;
        }

        protected void InteresMensual()
        {
            comisionMensual = saldo * (tasaAnual / 12 / 100);
            comisionMensual = Math.Round(comisionMensual, 2);
            saldo -= comisionMensual;
        }

        public void ExtractoMensual()
        {
            Console.Write("Saldo antes de comision " + saldo);
            InteresMensual();
            Console.WriteLine(" se le ha cobrado " + comisionMensual + ", saldo actual " + saldo);
        }

        public override string ToString()
        {
            return "Su saldo es " + saldo + ". Ingresos: " + ni + " Retiros: " + nr;
        }
    }

    public class Ahorro : Cuenta
    {
        private bool activo;
        public Ahorro(double saldo, double tasaAnual) : base(saldo, tasaAnual)
        {
            activo = saldo >= 100;
        }
        public new void Retirar(double cant)
        {
            if (activo)
            {
                base.Retirar(cant);
                activo = saldo >= 100;
            }
        }
        private new void InteresMensual()
        {
            comisionMensual = saldo * (tasaAnual / 12 / 100);
            comisionMensual = Math.Round(comisionMensual, 2);
            saldo -= comisionMensual;
            if (nr > 4)
            {
                comisionMensual += (nr - 4) * 1.5;
            }
        }
        public new void ExtractoMensual()
        {
            Console.Write("Saldo antes de comision " + saldo);
            InteresMensual();
            Console.WriteLine(" se le ha cobrado " + comisionMensual + ", saldo actual " + saldo);
            Console.WriteLine("Su cuenta " + (activo ? "" : "no ") + "esta activa.");
        }

        public override string ToString()
        {
            return "Su saldo es " + saldo + ", comision de " + comisionMensual + ", numero de transacciones " + (ni + nr);
        }

    }
}
