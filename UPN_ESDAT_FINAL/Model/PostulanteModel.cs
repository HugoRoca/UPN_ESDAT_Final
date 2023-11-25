using System;

namespace UPN_ESDAT_FINAL.Model
{
    public class PostulanteModel
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string FechaNacimiento { get; set; }
        public string Documentos { get; set; }
        public string Dni { get; set; }
        public int IdProceso { get; set; }
    }
}
