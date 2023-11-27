namespace UPN_ESDAT_FINAL.Model
{
    public class UsuarioModel
    {
        public string Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string RolDescripcion { get; set; }
    }
}
