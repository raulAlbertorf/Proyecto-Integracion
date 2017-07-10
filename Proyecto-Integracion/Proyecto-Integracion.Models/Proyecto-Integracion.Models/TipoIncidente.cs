using System.ComponentModel.DataAnnotations;

namespace Proyecto_Integracion.Models
{
    public enum TipoIncidente
    {
        [Display(Name = "Homicidio")]
        Homicidio = 1,

        [Display(Name = "Suicidio")]
        Suicidio = 2,

        [Display(Name = "Robo o Asalto")]
        RoboAsalto = 3,

        [Display(Name = "Violación")]
        Violacion = 4,

        [Display(Name = "Explotación Sexual")]
        ExplotacionSexual = 5
    }
}
