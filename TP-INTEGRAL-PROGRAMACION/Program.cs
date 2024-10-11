using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static TP_INTEGRAL_PROGRAMACION.Program;

namespace TP_INTEGRAL_PROGRAMACION
{

    internal class Program
    { 
        static bool existe = false;
        static int opcion;
        static string productoBuscado, productoAEliminar;
        static void Main(string[] args)
        {
            Cerveza[] infoDeCerveza = new Cerveza[]
            {
                new Cerveza("IPA", "BARRILES", 10, 100000.00),
                new Cerveza("APA", "BARRILES", 25, 112000.00),
                new Cerveza("SCOTTISH", "BARRILES", 13, 114000.00),
                new Cerveza("OLD ALE", "BARRILES", 16, 85000.00),
                new Cerveza("PORTER", "BARRILES", 32, 112000.00),
                new Cerveza("GLADSTONE", "BARRILES", 28, 112000.00),
                new Cerveza("BLONDE", "BARRILES", 15, 112000.00),
                new Cerveza("HONEY", "BARRILES", 29, 112000.00),
            };

            Console.WriteLine("Bienvenido al programa de Gestión de Inventario;");
            do
            {
                MensajeYMenu();
                opcion = int.Parse(Console.ReadLine());
                IngresoAlMenu(opcion, infoDeCerveza);
            } while (opcion != 6);
        }
        static void MensajeYMenu()
        { 
            Console.WriteLine("\nA partir del siguiente menú elija una opción:");
            Console.WriteLine("Opcion 1: buscar productos");
            Console.WriteLine("Opcion 2: ver información productos");
            Console.WriteLine("Opcion 3: agregar producto");
            Console.WriteLine("Opcion 4: eliminar producto");
            Console.WriteLine("Opcion 5: realizar presupuesto");
            Console.WriteLine("Opcion 6: salir");
        }
        static void IngresoAlMenu(int opcion, Cerveza[] infoDeCerveza) 
        {
            switch (opcion)
            {
                case 1:
                    BuscarProducto(infoDeCerveza);
                    break;
                case 2: 
                    VerInformacionDeProductos(infoDeCerveza); 
                    break;
                case 3:
                case 4:
                    EliminarProducto(infoDeCerveza);
                    break;
                default: Console.WriteLine("Opcion invalida");break;
            } 
        }
        static void BuscarProducto(Cerveza[] infoDeCerveza)
        {
            Console.Write("\nIngrese el nombre del producto: ");
            productoBuscado = Console.ReadLine().ToUpper();
            bool existe = false;

            for (int i = 0; i < infoDeCerveza.Length; i++)
            {
                if (productoBuscado == infoDeCerveza[i].NombreCerveza.ToUpper())
                {
                    Console.WriteLine($"\nEl producto {productoBuscado} se encuentra disponible");
                    existe = true;
                    break;
                }
            }
            if (!existe)
            {
                Console.WriteLine("El producto no se encontró");
            }
            
        }
        static void VerInformacionDeProductos(Cerveza[] infoDeCerveza)
        {
            Console.WriteLine("\nLos Productos disponibles son:");
            foreach (Cerveza cerveza in infoDeCerveza)
            {
                Console.WriteLine($"Nombre: {cerveza.NombreCerveza}, " +
                    $"Presentación: {cerveza.PresentacionCerveza}, " +
                    $"Stock: {cerveza.StockCerveza}, " +
                    $"Precio: {cerveza.PreciosCerveza}");
            }
        }
        static void EliminarProducto(Cerveza[] infoDeCerveza)
        { 
            Console.Write("\nIndique el nombre del producto que desea eliminar del stock: ");
            productoAEliminar = Console.ReadLine().ToUpper();

            int indiceAEliminar = Array.FindIndex(infoDeCerveza, e => e.NombreCerveza.ToUpper() == productoAEliminar);

            if (indiceAEliminar != -1)
            {
                Cerveza[] nuevaInfoDeCerveza = new Cerveza [infoDeCerveza.Length -1];

                Array.Copy(infoDeCerveza, 0, nuevaInfoDeCerveza, 0, indiceAEliminar);
                Array.Copy(infoDeCerveza, indiceAEliminar + 1, nuevaInfoDeCerveza, indiceAEliminar, infoDeCerveza.Length - indiceAEliminar - 1);

                infoDeCerveza = nuevaInfoDeCerveza;
                //return nuevaInfoDeCerveza;
            }
            else
            {
                Console.WriteLine("El producto no se encontró");
                //return infoDeCerveza;
            }
            Console.WriteLine("La lista con el producto eliminado es:");
            foreach (Cerveza nuevaLista in infoDeCerveza)
            {
                Console.WriteLine(nuevaLista + " ");
            }
        }

        public struct Cerveza 
        {
            public string  NombreCerveza;
            public string PresentacionCerveza;
            public int StockCerveza;
            public double PreciosCerveza;

            public Cerveza (string nombreCerveza, string presentacionCerveza, int stockCerveza, double preciosCerveza)
            {
                NombreCerveza = nombreCerveza;
                PresentacionCerveza = presentacionCerveza;
                StockCerveza = stockCerveza;
                PreciosCerveza = preciosCerveza;
            }
        }

    }

}
