namespace WebApplicationPWARest.Modelos
{
    public class Check
    {
        public int id { get; set; }
        public string hora_entrada { get; set; }
        public string hora_salida { get; set; }
        public string user_id { get; set; }
        public string clave_lab { get; set; }
        public int status { get; set; }
    }
}
