namespace UPN_ESDAT_FINAL.Model
{
    public class PostulanteDetalleModel
    {
        public int Id { get; set; }
        public int IdPostulante { get; set; }
        public int IdProceso { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
    }
}
