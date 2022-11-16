using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tpLabo4_usarEste_.Models
{
    public class Celular
    {
        public int id { get; set; }
        public string modelo { get; set; }

        public double precio { get; set; }
        public string descripcion { get; set; }
        public string ? foto { get; set; }



       


        [Display(Name = "Marca")]
        public int marcaId { get; set; }
        [ForeignKey("marcaId")]
        public Marca ? marca  {get; set;}


        [Display(Name = "Sistema Operativo")]
        public int sistemaOperativoId { get; set; }
        [ForeignKey("sistemaOperativoId")]
        public SistemaOperativo ? SistemaOperativo { get; set; }

    }
}
