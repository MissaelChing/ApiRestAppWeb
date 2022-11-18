namespace WebApplicationPWARest.Modelos
{
    public class Horarios
    {
        public int id { get; set; }
        public string materia { get; set; }
        public int user_id { get; set; }
        public DateTime hora { get; set; }
        public string dia { get; set; }
        public int clave_laboratorio { get; set; }
    }
}
