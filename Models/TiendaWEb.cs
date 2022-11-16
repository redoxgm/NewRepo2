using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace tpLabo4_usarEste_.Models
{
    public class TiendaWEb
    {
        public int id { get; set; }
         public string nombreTienda { get; set; }

       public List<Proveedor> ? proveedors { get; set; }

        public List<Celular> ? celulars { get; set; }



        

    }
}
