using System;

namespace HelloWorld
{
    public class Persona
    {
        //al crear un objeto y hacer new Objet(); separas memoria para ese objeto
        //clase que tiene un método con static puede ser llamado desde la misma clase, sin necesidad de hacer un objeto
        public string firstName;
        public string secondName;
        public int age;

        public void Introduce()
        {
            //creas un template de la sentencia
            string fullName = string.Format("My name is {0} {1}", firstName, secondName);
            Console.WriteLine(fullName);
        }
        public static int Increment(int number)
        {
            number += 10;
            return number;
        }
        public static void MakeOlder(Persona persona)
        {
            persona.age += 10;
        }
    }
}
