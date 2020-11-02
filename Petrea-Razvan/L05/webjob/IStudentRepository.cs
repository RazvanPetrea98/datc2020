using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
 public interface IStudentRepository
{
    Task<List<StudentEntity>> GetAllStudents();

    Task<StudentEntity> GetStudent(string id);

    Task InsertNewStudent(StudentEntity student);

    Task EditStudent(StudentEntity student);

    Task DeleteStudent(string id);
}
