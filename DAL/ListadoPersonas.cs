using ENT;

namespace DAL
{
    public class ListadoPersonas
    {
        // Lista estática de personas
        private static List<Persona> personasList = new List<Persona>
        {
            new Persona(1, "Juan Pérez", "Calle Falsa 123"),
            new Persona(2, "Ana Gómez", "Avenida Siempre Viva 456"),
            new Persona(3, "Carlos López", "Calle Gran Vía 789"),
            new Persona(4, "María Fernández", "Calle del Sol 321"),
            new Persona(5, "Luis García", "Calle Luna 654"),
            new Persona(6, "Elena Martínez", "Avenida del Río 987"),
            new Persona(7, "Pedro Sánchez", "Calle del Parque 159"),
            new Persona(8, "Laura Rodríguez", "Avenida del Mar 753"),
            new Persona(9, "Jorge Díaz", "Calle de los Árboles 258"),
            new Persona(10, "Sofía González", "Avenida del Sol 654")
        };


        // Función para listar todas las personas
        public static List<Persona> ListarPersonas()
        {
            return personasList;
        }

        // Función para buscar una persona por su Id
        public static Persona BuscarPersonaPorId(int id)
        {
            return personasList.FirstOrDefault(p => p.Id == id);
        }

        // Función para actualizar una persona
        public static bool ActualizarPersona(int id, Persona per)
        {
            bool res = false;

            Persona persona = BuscarPersonaPorId(id);
            if (persona != null)
            {
                persona.Nombre = per.Nombre;
                persona.Apellidos = per.Apellidos;
                res = true;
            }
            return res;
        }

        // Función para crear una nueva persona
        public static void CrearPersona(Persona per)
        {

            personasList.Add(per);
        }

        // Función para eliminar una persona por su Id
        public static bool EliminarPersona(int id)
        {
            bool res = false;
            Persona persona = BuscarPersonaPorId(id);
            if (persona != null)
            {
                personasList.Remove(persona);
                res = true;
            }
            
            return res;
        }
    }
}
