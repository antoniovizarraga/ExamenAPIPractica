namespace ENT
{
    public class Persona
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }


        public Persona() { }


        public Persona(int Id, string Nombre, string Apellidos)
        {
            this.Id = Id;

            if (!string.IsNullOrEmpty(Nombre))
            {
                this.Nombre = Nombre;
            }


            if (!string.IsNullOrEmpty(Apellidos))
            {
                this.Apellidos = Apellidos;
            }

        }

    }





        
}
