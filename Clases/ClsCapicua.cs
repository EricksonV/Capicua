using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea_10__Capicua_.Interfaces;

namespace Tarea_10__Capicua_.Clases
{
    class ClsCapicua : mdClsCapicua
    {
        private Stack<object> datosPila = new Stack<object>();
        private Queue<object> datosCola = new Queue<object>();


        private void llenaColaYPila(char dato)
        {
            datosCola.Enqueue(dato);
            datosPila.Push(dato);
        }
        private string ComparaSiesCapicua()
        {
            int i = datosCola.Count();
            bool flag = true;
            while ((i != 0)&&(flag == true))
            {
                char a = (char)datosCola.Dequeue();
                flag = a.Equals(datosPila.Pop());
                i--;
            }
            datosCola.Clear();
            datosPila.Clear();
            return flag == true ? "Si es Capicua" : "No es Capicua";
        }

        private string ingresoNumero()
        {
            bool flag = true;
            int i = 0;
            Console.WriteLine("Ingrese un número para saber si es Capicua");
            Console.Write("Número a Ingresar: ");
            string dato = Console.ReadLine();
            while ((flag == true) && (i < dato.Length))
            {
                char c = dato[i++];
                flag = (c >= '0' && c <= '9');

            }
            return (flag == true)? dato: "NO";
        }

        public void menuPrincipal()
        {
            bool flag = false;

            do
            {
                string dato = ingresoNumero();
                if(dato != "NO")
                {
                    foreach(char c in dato)
                    {
                        llenaColaYPila(c);
                    }

                    Console.WriteLine($"{dato} {ComparaSiesCapicua()}");
                    Console.WriteLine();
                    Console.WriteLine("Desea Salir Y, si no presione cualquier otra tecla");
                    string comprueba = Console.ReadLine();
                    flag = comprueba.Equals("Y");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Debe ser solo números");
                }
            } while (flag != true);
        }
    }
}
