using System.ComponentModel.DataAnnotations;

namespace Proyecto_Integracion.Models
{
    public enum TipoIncidente
    {
        //[Display(Name = "Robo de vehiculo s/v")]
        //Robo_Vehiculo_Sin_Violencia,
        //[Display(Name = "Robo de vehiculo c/v")]
        //Robo_Vehiculo_Con_Violencia,
        //[Display(Name = "Robo a bordo de microbus s/v")]
        //Robo_BordoMicrobus_Sin_Violencia,
        //[Display(Name = "Robo a bordo de microbus c/v")]
        //Robo_BordoMicrobus_Con_Violencia,
        //[Display(Name = "Robo a negocio s/v")]
        //Robo_Negocio_Sin_Violencia,
        //[Display(Name = "Robo a negocio c/v")]
        //Robo_Negocio_Con_Violencia,
        //[Display(Name = "Robo a casa habitacion s/v")]
        //Robo_CasaHabitacion_Sin_Violencia,
        //[Display(Name = "Robo a casa habitacion c/v")]
        //Robo_CasaHabitacion_Con_Violencia,
        //[Display(Name = "Homicidio doloso")]
        //HomicidioDoloso,
        //[Display(Name = "Robo a transeunte s/v")]
        //Robo_Transeunte_Sin_Violencia,
        //[Display(Name = "Robo a transeunte c/v")]
        //Robo_Transeunte_Con_Violencia,
        //[Display(Name = "Voilacion")]
        //Voilacion,
        //[Display(Name = "Lesiones por arma de fuego")]
        //Lesiones_Arma_Fuego

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
