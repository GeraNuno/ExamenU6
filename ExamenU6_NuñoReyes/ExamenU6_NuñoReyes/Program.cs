using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ExamenU6_NuñoReyes
{
    class Program
    {
        class Inventario
        {
            public string nombre, descripcion;
            public float precio;
            public int cantidad;

            public Inventario(string nombre, string descripcion, float precio, int cantidad)
            {
                this.nombre = nombre;
                this.descripcion = descripcion;
                this.precio = precio;
                this.cantidad = cantidad;
            }

            public void Datos()
            {
                Console.WriteLine("Datos Registrados");
                Console.WriteLine("Nombre Producto: " + nombre);
                Console.WriteLine("Descripción: " + descripcion);
                Console.WriteLine("Precio: {0:C}", precio);
                Console.WriteLine("Cantidad en Inventario: " + cantidad);
            }
        }
        static void Main(string[] args)
        {
            string nombre, descripcion;
            float precio;
            int cantidad, opc;

            do
            {
                Console.Write("\nMenú de Opciones\n\n1) Registrar Producto\n2) Consultar Productos\n3) Salir\n\nElija la opción: ");
                opc = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opc)
                {
                    case 1:
                        StreamWriter sw = new StreamWriter("inventario.txt", true);
                        Console.WriteLine("----- Captura de Datos -----");
                        Console.Write("\nNombre: ");
                        nombre = Console.ReadLine();
                        Console.Write("Descripción: ");
                        descripcion = Console.ReadLine();
                        Console.Write("Precio: ");
                        precio = float.Parse(Console.ReadLine());
                        Console.Write("Cantidad: ");
                        cantidad = int.Parse(Console.ReadLine());
                        Console.Clear();

                        Inventario inv = new Inventario(nombre, descripcion, precio, cantidad);

                        sw.WriteLine("Nombre Producto: " + inv.nombre + "\nDescripción: " + inv.descripcion + "\nPrecio: $" + inv.precio + "\nCantidad en Inventario: " + inv.cantidad + "\n");

                        Console.WriteLine("Producto registrado exitosamente!!!\n");
                        inv.Datos();
                        Console.WriteLine("\nPresione ENTER para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        sw.Close();
                        break;
                    case 2:
                        try
                        {
                            StreamReader sr = new StreamReader("inventario.txt");
                            string line = "";
                            Console.WriteLine("Productos Registrados\n");
                            while ((line = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                            }
                            sr.Close();
                            Console.WriteLine("Presione ENTER para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        catch(IOException e)
                        {
                            Console.WriteLine("Error, Archivo no encontrado\nDebe Capturar un producto primero");
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Presione ENTER para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Presione ENTER para salir del programa...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Error, elija una opción correcta!\nPresione ENTER para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (opc != 3);
        }
    }
}
