using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GuiaDidactica_06_AlexanderZelaya
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("=============================================\n" +
                "   Bienvenido a la Farmacia 'La Desgracia'\n");
                Console.WriteLine("=============================================\n");
                Console.Write("         ¿Desea Realizar Una compra?\n" +
                    "1. Si\n" +
                    "0. Salir del programa\n" +
                    "=============================================\n" +
                    "opción: ");

                int opc = Convert.ToInt32(Console.ReadLine());

                if (opc == 1)
                {
                    Console.Clear();
                    // Crear los catálogos de medicamentos para cada enfermedad
                    Dictionary<string, List<Medicamento>> catalogo = new Dictionary<string, List<Medicamento>>();

                    catalogo.Add("Fiebre", new List<Medicamento>()
                    {
                        new Medicamento("Paracetamol", "pastillas", 20, new DateTime(2023, 6, 30)),
                        new Medicamento("Ibuprofeno", "pastillas", 15, new DateTime(2024, 9, 15)),
                        new Medicamento("Naproxeno", "pastillas", 30, new DateTime(2025, 2, 28)),
                        new Medicamento("Acetaminofén", "jarabe", 150, new DateTime(2023, 12, 31)),
                        new Medicamento("Dipirona", "inyeccion", 50, new DateTime(2024, 6, 30)),
                        new Medicamento("Diclofenaco", "pomada", 100, new DateTime(2023, 9, 30)),
                    });

                    catalogo.Add("Tos", new List<Medicamento>()
                    {
                        new Medicamento("Ambroxol", "jarabe", 250, new DateTime(2025, 8, 31)),
                        new Medicamento("Salbutamol", "inyeccion", 30, new DateTime(2024, 11, 30)),
                        new Medicamento("Guaifenesina", "pastillas", 40, new DateTime(2023, 10, 31)),
                        new Medicamento("Bromhexina", "jarabe", 200, new DateTime(2024, 4, 30)),
                        new Medicamento("Dextrometorfano", "pastillas", 25, new DateTime(2023, 7, 31)),
                        new Medicamento("Efedrina", "inyeccion", 10, new DateTime(2023, 12, 31)),
                        new Medicamento("Fluticasona", "pomada", 80, new DateTime(2025, 5, 31)),
                    });

                    catalogo.Add("Dolor de cabeza", new List<Medicamento>()
                    {
                        new Medicamento("Paracetamol", "pastillas", 20, new DateTime(2023, 6, 30)),
                        new Medicamento("Ibuprofeno", "pastillas", 15, new DateTime(2024, 9, 15)),
                        new Medicamento("Ácido acetilsalicílico", "pastillas", 30, new DateTime(2025, 2, 28)),
                        new Medicamento("Sumatriptán", "inyeccion", 5, new DateTime(2024, 8, 31)),
                        new Medicamento("Naproxeno", "pastillas", 30, new DateTime(2025, 2, 28)),
                    });

                    catalogo.Add("Alergias", new List<Medicamento>()
                    {
                        new Medicamento("Cetirizina", "pastillas", 50, new DateTime(2024, 3, 31)),
                        new Medicamento("Difenidramina", "pastillas", 30, new DateTime(2025, 7, 09)),
                        new Medicamento("Dexclorfeniramina", "pastillas", 25, new DateTime(2024, 11, 30)),
                        new Medicamento("Loratadina", "pastillas", 40, new DateTime(2023, 12, 31)),
                        new Medicamento("Prednisona", "pastillas", 20, new DateTime(2025, 6, 30)),
                        new Medicamento("Epinefrina", "inyeccion", 10, new DateTime(2023, 10, 31)),
                    });

                    // Solicitar los datos del cliente
                    Console.WriteLine("       Ingrese los datos del cliente:");
                    Console.Write("Nombre: ");
                    string nombreCliente = Console.ReadLine();
                    Console.Write("Apellido: ");
                    string apellidoCliente = Console.ReadLine();
                    Console.Write("ID: ");
                    string dniCliente = Console.ReadLine();

                    // Mostrar las enfermedades disponibles
                    Console.WriteLine("=============================================");
                    Console.WriteLine("Lista de Enfermedades que podemos tratar:");
                    foreach (string enfermedad in catalogo.Keys)
                    {
                        Console.WriteLine("- " + enfermedad);
                    }

                    // Solicitar la enfermedad y el medicamento deseado
                    Console.WriteLine("=============================================");
                    Console.Write("Ingrese el nombre de la enfermedad: ");
                    string enfermedadSeleccionada = Console.ReadLine();

                    while (!catalogo.ContainsKey(enfermedadSeleccionada))
                    {
                        Console.WriteLine("=============================================");
                        Console.WriteLine("La enfermedad ingresada no es válida.");
                        Console.Write("Ingrese el nombre de la enfermedad: ");
                        enfermedadSeleccionada = Console.ReadLine();
                    }

                    List<Medicamento> medicamentosDisponibles = catalogo[enfermedadSeleccionada];
                    Console.WriteLine("=============================================");
                    Console.WriteLine("Medicamentos disponibles para " + enfermedadSeleccionada + ":");

                    foreach (Medicamento medicamento in medicamentosDisponibles)
                    {
                        Console.WriteLine("- " + medicamento.Nombre + " (" + medicamento.Tipo + ")");
                    }

                    Console.WriteLine("=============================================");
                    Console.Write("Ingrese el nombre del medicamento deseado: ");
                    string medicamentoSeleccionado = Console.ReadLine();

                    while (!medicamentosDisponibles.Exists(m => m.Nombre == medicamentoSeleccionado))
                    {
                        Console.WriteLine("=============================================");
                        Console.WriteLine("El medicamento ingresado no es válido.");
                        Console.Write("Ingrese el nombre del medicamento deseado: ");
                        medicamentoSeleccionado = Console.ReadLine();
                    }

                    Medicamento medicamentoComprado = medicamentosDisponibles.Find(m => m.Nombre == medicamentoSeleccionado);

                    // Mostrar los datos del medicamento comprado
                    Console.WriteLine("=============================================");
                    Console.WriteLine("\nDatos del medicamento comprado:");
                    Console.WriteLine("- Enfermedad: " + enfermedadSeleccionada);
                    Console.WriteLine("- Medicamento: " + medicamentoComprado.Nombre + " (" + medicamentoComprado.Tipo + ")");
                    Console.WriteLine("- Cantidad: " + medicamentoComprado.Cantidad + (medicamentoComprado.Tipo == "pastillas" ? " unidades" : (medicamentoComprado.Tipo == "jarabe" ? " miligramos" : (medicamentoComprado.Tipo == "inyeccion" ? " miligramos" : " gramos"))));
                    Console.WriteLine("- Fecha de vencimiento: " + medicamentoComprado.FechaVencimiento.ToString("dd/MM/yyyy"));

                    // Mostrar la factura
                    Console.WriteLine("=============================================");
                    Console.WriteLine("\nFactura:");
                    Console.WriteLine("- Cliente: " + nombreCliente + " " + apellidoCliente + " (ID: " + dniCliente + ")");
                    Console.WriteLine("- Enfermedad: " + enfermedadSeleccionada);
                    Console.WriteLine("- Medicamento: " + medicamentoComprado.Nombre + " (" + medicamentoComprado.Tipo + ")");
                    Console.WriteLine("- Cantidad: " + medicamentoComprado.Cantidad + (medicamentoComprado.Tipo == "pastillas" ? " unidades" : (medicamentoComprado.Tipo == "jarabe" ? " miligramos" : (medicamentoComprado.Tipo == "inyeccion" ? " miligramos" : " gramos"))));
                    Console.WriteLine("- Fecha de vencimiento: " + medicamentoComprado.FechaVencimiento.ToString("dd/MM/yyyy"));
                    Console.WriteLine("- Total a pagar: $" + medicamentoComprado.Precio.ToString("0.00"));
                }
                else if (opc == 0)
                {
                    Console.Clear();
                    Console.WriteLine("=============================================");
                    Console.WriteLine("Ha salido del programa con éxito!");
                    Console.WriteLine("Presione una tecla para finalizar");
                    Console.ReadKey();
                    break;
                }
                else if (opc >= 2)
                {
                    Console.Clear();
                    Console.WriteLine("=============================================");
                    Console.WriteLine("Elija una opción correcta");
                    Console.WriteLine("=============================================");
                }
            }
        }
    }
}
