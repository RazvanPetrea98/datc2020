using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
 public interface IStudentRepository
{
    Task<List<StudentEntity>> GetAllStudents();

    Task CreateNewStudent(StudentEntity student);

    Task UpdateStudent(StudentEntity student);

    Task DeleteStudent(StudentEntity student);
}