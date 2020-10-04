using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tema_api
{
    public class StudentRepo
    {
        public static List<Student> Students = new List<Student>()
        {
            new Student() { Id = 1, Nume = "Petrea", Prenume = "Razvan", Facultate = "AC", AnStudiu = 4 },
            new Student() { Id = 2, Nume = "Mocanu", Prenume = "Gigel", Facultate = "ETC", AnStudiu = 3 },
            new Student() { Id = 3, Nume = "Spataru", Prenume = "Daniel", Facultate = "MEC", AnStudiu = 2 }
        };
    }
}
