using System;


//elaborar una aplicacion objetual con clases que pida el nombre 
// de una persona y evalue que sea mayor de edadpara continuar pidiendo
//los demas datos personales (apellido, edad, email)
namespace Parcial_2
{
    //se crea la clase persona con sus atributos nombre, edad, mail, etc y metodos EsMayorEdad()
    class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
        //contructor persona
        public Persona(string nombre)
        {
            Nombre = nombre;
        }
        public bool EsMayorEdad()
        {
            return Edad >=18;
        }
    }
    //se crea clase Estudiante con sus atributos nombre, edad calificaciones
    class Estudiante
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double[] Calificaciones { get; set; }
        //constructor Esudiante con parametros nombre, edad y calificaciones
        public Estudiante(string nombre, int edad, double[] calificaciones)
        {
            Nombre = nombre;
            Edad = edad;
            Calificaciones = calificaciones;
        }
    }
    class Program
    {
        static Estudiante[] IngresarEstudiantes()
        {
            Console.Write("Ingrese la cantidad de estudiantes: ");
            int cantidadEstudiantes = int.Parse(Console.ReadLine());

            //vector para guardar info de estudiantes
            Estudiante[] estudiantes = new Estudiante[cantidadEstudiantes];
            //ciclo para recorrer estudiantes y preguntarle info
            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                Console.Write($"Ingrese el nombre del estudiante # {i+1}: ");
                string nombre = Console.ReadLine();

                Console.Write($"Ingrese la edad del estudiante # {i+1}: ");
                int edad = int.Parse(Console.ReadLine());

                Console.Write($"Ingrese las calificaciones del estudiante # {i+1} separadas por espacios: ");
                double[] calificaciones = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);

                //guardar toda la info en el vector
                estudiantes[i] = new Estudiante(nombre, edad, calificaciones);
            }

            return estudiantes;
        }

        //devolver valores ingresados por usuario
        static void m_Estudiantes(Estudiante[] estudiantes)
        {
            Console.WriteLine("\nDatos de los estudiantes:");
            for (int i = 0; i < estudiantes.Length; i++)
            {
                Console.WriteLine($"Estudiante # {i}");
                Console.WriteLine($"Nombre: {estudiantes[i].Nombre}");
                Console.WriteLine($"Edad: {estudiantes[i].Edad}");
                Console.WriteLine($"Calificaciones: {string.Join(", ", estudiantes[i].Calificaciones)}");
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Bienvenido a la aplicación de calcular edad persona\nIngresa el nombre completo: ");
            string nombre = Console.ReadLine();

            //crear instancia persona
            Persona persona = new Persona(nombre);

            //edad
            while (true)
            {
                Console.Write("Ingresa la edad: ");
                if(int.TryParse(Console.ReadLine(),out int edad))
                {
                    persona.Edad = edad;

                    //verificar
                    if (persona.EsMayorEdad())
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("DEBES SER MAYOR DE EDAD PARA CONTINUAR");
                    }
                }
                else
                {
                    Console.Write("Ingrese una edad valida. ");
                }
            }
            //solicitat apellido
            Console.Write("Por favor, ingrese su apellido: ");
            persona.Apellido = Console.ReadLine();

            //solicitar mail
            Console.Write("Por favor, ingrese su correo electronico: ");
            persona.Email = Console.ReadLine();

            //mostrar datos
            Console.WriteLine("\n¡Gracias por registrarte!");
            Console.WriteLine("Datos registrados: ");
            Console.WriteLine($"Nombre: {persona.Nombre}");
            Console.WriteLine($"Apellido: {persona.Apellido}");
            Console.WriteLine($"Edad: {persona.Edad}");
            Console.WriteLine($"Email: {persona.Email}");
            Console.WriteLine("ENTER PARA EL EJERCICIO 2");

            Console.ReadKey();
            // Permitir a los usuarios ingresar información sobre varios estudiantes
            Estudiante[] arrayEstudiantes = IngresarEstudiantes();

            // Mostrar los datos de los estudiantes
            m_Estudiantes(arrayEstudiantes);
        }
    }
}