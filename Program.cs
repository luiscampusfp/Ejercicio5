using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Desarrollar un programa que modele una cuenta bancaria que tiene los siguientes atributos, que deben ser de acceso protegido:
• Saldo, de tipo float.
• Número de ingresos con valor inicial cero, de tipo int.
• Número de retiros con valor inicial cero, de tipo int.
• Tasa anual (porcentaje), de tipo float.
• Comisión mensual con valor inicial cero, de tipo float.
La clase Cuenta tiene un constructor que inicializa los atributos saldo y tasa anual con valores pasados como parámetros. La clase
Cuenta tiene los siguientes métodos:
• Ingresar una cantidad de dinero en la cuenta actualizando su saldo.
• Retirar una cantidad de dinero en la cuenta actualizando su saldo. El valor a retirar no debe superar el saldo.
• Calcular el interés mensual de la cuenta y actualiza el saldo correspondiente.
• Extracto mensual: actualiza el saldo restándole la comisión mensual y calculando el interés mensual correspondiente (invoca el
método anterior).
• Imprimir: muestra en pantalla los valores de los atributos.

La clase Cuenta tiene dos clases hijas:
• Cuenta de ahorros: posee un atributo para determinar si la cuenta de ahorros está activa (tipo boolean). Si el saldo es menor a
100€, la cuenta está inactiva, en caso contrario se considera activa. Los siguientes métodos se redefinen:
1. Ingresar: se puede ingresar dinero si la cuenta está activa. Debe invocar al método heredado.
2. Retirar: es posible retirar dinero si la cuenta está activa. Debe invocar al método heredado.
3. Extracto mensual: si el número de retiros es mayor que 4, por cada retiro adicional, se cobra 1.5€ como comisión
mensual. Al generar el extracto, se determina si la cuenta está activa o no con el saldo.
4. Un nuevo método imprimir que muestra en pantalla el saldo de la cuenta, la comisión mensual y el número de
transacciones realizadas (suma de cantidad de consignaciones y retiros).

• Cuenta corriente: posee un atributo de sobregiro, el cual se inicializa en cero. Se redefinen los siguientes métodos:
• Retirar: se retira dinero de la cuenta actualizando su saldo. Se puede retirar dinero superior al saldo. El dinero que se debe
queda como sobregiro.
• Ingresar: invoca al método heredado. Si hay sobregiro, la cantidad consignada reduce el sobregiro.
• Extracto mensual: invoca al método heredado.
• Un nuevo método imprimir que muestra en pantalla el saldo de la cuenta, la comisión mensual, el número de
transacciones realizadas (suma de cantidad de consignaciones y retiros) y el valor de sobregiro.
Realizar un método main que implemente un objeto Cuenta de ahorros y llame a los métodos correspondientes
             */

            List<Cuenta> cuentas = new List<Cuenta>();
            string r;
            do
            {
                Console.Clear();
                Console.WriteLine("Opciones del programa:\n" +
                    "1- Crear Cuenta\n" +
                    "2- Eliminar Cuenta\n" +
                    "3- Operar Cuenta\n" +
                    "4- Salir");
                r = Console.ReadLine();
                switch (r)
                {
                    case "1":
                        Console.WriteLine("Defina el tipo de cuenta que desea crear (normal, ahorro, corriente):");
                        string tipo = Console.ReadLine();
                        Console.WriteLine("Introduzca el saldo de su nueva cuenta:");
                        double saldo = double.Parse(Console.ReadLine());
                        Console.WriteLine("Introduzca el interes anual:");
                        double interes = double.Parse(Console.ReadLine());
                        if (tipo == "normal")
                            cuentas.Add(new Cuenta(saldo, interes));
                        else if (tipo == "ahorro")
                            cuentas.Add(new Ahorro(saldo, interes));
                        else if (tipo == "corriente")
                            cuentas.Add(new Corriente(saldo, interes));
                        else
                            Console.WriteLine("No se ha creado la cuenta, porque no se reconoce el tipo");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Introduzca la posicion de la cuenta que deceas eliminar:");
                        int pos = int.Parse(Console.ReadLine());
                        cuentas.RemoveAt(pos);
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Introduzca la posicion de la cuenta que deceas eliminar:");
                        int pos2 = int.Parse(Console.ReadLine());
                        MenuCuenta(cuentas[pos2]);
                        break;
                    case "4":
                        Console.WriteLine("Saliendo de la programa");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Seleccion incorrecta");
                        Console.ReadLine();
                        break;
                }

            } while (r != "4");
        }

        public static void MenuCuenta(Cuenta c)
        {
            string r;
            do
            {
                Console.Clear();
                Console.WriteLine("Opciones del programa:\n" +
                    "1- Hacer Ingreso\n" +
                    "2- Hacer Retiro\n" +
                    "3- Extracto Meensual\n" +
                    "4- Salir");
                r = Console.ReadLine();
                switch (r)
                {
                    case "1":
                        Console.WriteLine("Introduzca una cantidad:");
                        c.Ingresar(double.Parse(Console.ReadLine()));
                        Console.WriteLine(c);
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Introduzca una cantidad:");
                        c.Retirar(double.Parse(Console.ReadLine()));
                        Console.WriteLine(c);
                        Console.ReadLine();
                        break;
                    case "3":
                        c.ExtractoMensual();
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("Saliendo de la cuenta");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Seleccion incorrecta");
                        Console.ReadLine();
                        break;
                }

            } while (r != "4");
        }
    }
}
