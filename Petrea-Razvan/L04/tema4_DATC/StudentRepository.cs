using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Models;

namespace tema4_DATC
{
    public class StudentRepository : IStudentRepository
    {
        private string _cconnectionString;
        private CloudTableClient _tableClient;
        private CloudTable _studentsTable;

        public StudentRepository(IConfiguration configuration)
        {
            _cconnectionString = configuration.GetValue<string>("AzureStorageAccountConnectionString");
            Task.Run(async () => { await InitizaleTable(); })
                .GetAwaiter()
                .GetResult();
        }

        public async Task CreateNewStudent(StudentEntity student)
        {
            var insertOperation = TableOperation.Insert(student);

            await _studentsTable.ExecuteAsync(insertOperation);
        }

        public async Task UpdateStudent(StudentEntity student)
        {
            var updateOperation = TableOperation.Replace(student);

            await _studentsTable.ExecuteAsync(updateOperation);
        }

        public async Task DeleteStudent(StudentEntity student)
        {
            var deleteOperation = TableOperation.Delete(student);

            await _studentsTable.ExecuteAsync(deleteOperation);
        }

        public async Task<List<StudentEntity>> GetAllStudents()
        {
            var students = new List<StudentEntity>();
            TableQuery<StudentEntity> query = new TableQuery<StudentEntity>();

            TableContinuationToken token = null;
            do
            {
                TableQuerySegment<StudentEntity> resultSegment = await _studentsTable.ExecuteQuerySegmentedAsync(query, token);
                token = resultSegment.ContinuationToken;

                students.AddRange(resultSegment.Results);
            }  while (token != null);

            return students;
        }
         
          private async Task InitizaleTable()
          {
              
            var account = CloudStorageAccount.Parse(_cconnectionString);
            _tableClient = account.CreateCloudTableClient();

            _studentsTable = _tableClient.GetTableReference("studenti");

            await _studentsTable.CreateIfNotExistsAsync();
          }
    }
}