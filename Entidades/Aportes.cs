using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_AP1_Junior_20190009.Entidades
{
    public class Aportes
    {
        [Key]
        public int AporteID { get; set; }
        public DateTime Fecha { get; set; }
        public String Persona { get; set; }
        public String Concepto { get; set; }
        public float Monto { get; set; }

        public Aportes()
        {
            AporteID = 0;
            Fecha = DateTime.Now;
            Persona = string.Empty;
            Concepto = string.Empty;
            Monto = 0;
        }
    }
}
