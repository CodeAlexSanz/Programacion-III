using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaDidactica_06_AlexanderZelaya
{
    public class Medicamento
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public double Cantidad { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public double Precio { get; set; }

        public Medicamento(string nombre, string tipo, double cantidad, DateTime fechaVencimiento)
        {
            Nombre = nombre;
            Tipo = tipo;
            Cantidad = cantidad;
            FechaVencimiento = fechaVencimiento;

            // Asignar el precio según el tipo de medicamento
            if (tipo == "pastillas")
            {
                Precio = cantidad * 0.5;
            }
            else if (tipo == "jarabe")
            {
                Precio = cantidad * 1.5;
            }
            else if (tipo == "inyeccion")
            {
                Precio = cantidad * 2;
            }
            else if (tipo == "pomada")
            {
                Precio = cantidad * 3;
            }
        }
    }
}
