using System.ComponentModel.DataAnnotations;

namespace Practica3.Models
{
    public class equipos
    {
        [Key]
        public int id_equipo {  get; set; }

        public String? nombre { get; set; }

        public String? Tipo_equipo { get; set; }

        public int id_marcas { get; set; }
        public int anio_compra {  get; set; }

        public String? vida_util {  get; set; }
        public String? descripcion { get; set; }

        public String? modelo { get; set; }
        public int Costo { get; set; }

    }
}
