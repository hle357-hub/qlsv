using AntDesign;
using AntDesign.Charts;
using AntDesign.TableModels;
using Microsoft.AspNetCore.Components;
using OneOf.Types;
using QuanLySinhVien.Shared;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
namespace Client.Pages
{
    public partial class Danhsachsv
    {
        [Inject]
        private IQlsvService qlsv { get; set; } = default!;
        [Inject]
        private IMessageService message {  get; set; }= default!;
        private StudentListDto studentList= new StudentListDto();
        private StudentDto newStudent= new StudentDto();
        private bool openModal = false;
        private bool isLoading = false;
        private string statusModel = string.Empty;
        private FormModel isEdit = FormModel.add;
        public enum FormModel
        {
            add,
            edit
        }
        private StudentListRequestDto request = new StudentListRequestDto
        {
            Keyword = string.Empty,
            SortBy= "id",
            Descending=false,
            Page=1,
            PageSize=10
        };
        
        private void CallAddTable()
        {
            isEdit = FormModel.add;
            openModal = true;
        }
        private void CallUpdateTable(StudentDto student)
        {
            isEdit = FormModel.edit;
            newStudent = new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Address = student.Address,
                DateBirthDay = student.DateBirthDay,
            };
            openModal = true;
        }
        private async Task OkForTable()
        {
            isLoading = true;
            if (isEdit == FormModel.add)
            {
                statusModel = "bang them moi sinh vien";
                await AddStudent(newStudent);
            }
            else if (isEdit == FormModel.edit)
            {
                statusModel = "bang cap nhat sinh vien";
                await UpdateStudent();
            }
            dongmodal();
            isLoading = false;
        }
        private async Task AddStudent(StudentDto Student)
        {
            try
            {
                var result=await qlsv.AddStudentAsync(Student);
                if (result.Success)
                {
                    await ResetData();
                    message.Success(result.Message);
                }
                else
                {
                    message.Error(result.Message);
                }
            }
            catch (Exception ex) {
                message.Error("xoa sinh vien that bai");
                Console.WriteLine(ex.ToString());
            }
        }
        private async Task ResetTable()
        {
            request= new StudentListRequestDto
            {
                Keyword = string.Empty,
                SortBy = "id",
                Descending = false,
                Page = 1,
                PageSize = 10
            };
            await ResetData();
             StateHasChanged();
        }
        private async Task ResetData()
        {
            try
            {
                studentList = await qlsv.StudentListAsync(request);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                message.Error("du lieu co van de");
            }
        }
        private async Task FindStudentById(string key)
        {
            isLoading = true;
            try
            {
                request.Page = 1;
                request.Keyword = key;
                await ResetData();
            }
            finally
            {
                isLoading = false;
            }
        }
        private async Task DeleteStudent(StudentDto Student)
        {
            try
            {
                var result= await qlsv.DeleteStudentAsync(Student);
                if (result.Success)
                {
                    await ResetData();
                    message.Success(result.Message);
                }
                else
                {
                    message.Error(result.Message);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                message.Error("xoa sv that bai");
            }
        }
        private async Task UpdateStudent() {
            try
            {
                var result=await qlsv.UpdateStudentAsync(newStudent);
                if (result.Success) {
                    await ResetData();
                    message.Success(result.Message);
                }
                else
                {
                    message.Error(result.Message);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                message.Error("cap nhat thong tin sv that bai");
            }
            await ResetData() ;
        }
        private void dongmodal()
        {
            openModal = false;
        }
        private async Task OnTableChange(QueryModel<StudentDto> query)
        {
            try
            {
                request.Page = query.PageIndex;
                request.PageSize = query.PageSize;
                studentList = await qlsv.StudentListAsync(request);
                message.Success("tai bang thanh cong");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Error("tai bang that bai");
            }
        }
    }
}
