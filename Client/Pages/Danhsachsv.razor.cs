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
        private IQlsvService StudentManagement { get; set; } = default!;
        [Inject]
        private IMessageService Message {  get; set; }= default!;
        private StudentListDto studentList= new StudentListDto();
        private StudentDto newStudent= new StudentDto();
        public enum FormModel
        {
            add,
            edit
        }
        private bool openModal = false;
        private bool isLoading = false;
        private string statusModel = string.Empty;
        private FormModel isEdit = FormModel.add;
       
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

        private async Task OkForTableAsync()
        {
            isLoading = true;
            if (isEdit == FormModel.add)
            {
                statusModel = "bang them moi sinh vien";
                await AddStudentAsync(newStudent);
            }
            else if (isEdit == FormModel.edit)
            {
                statusModel = "bang cap nhat sinh vien";
                await UpdateStudentAsync();
            }
            CloseModal();
            isLoading = false;
        }

        private async Task AddStudentAsync(StudentDto student)
        {
            try
            {
                var result=await StudentManagement.AddStudentAsync(student);
                if (result.Success)
                {
                    await ResetDataAsync();
                    Message.Success(result.Message);
                }
                else
                {
                    Message.Error(result.Message);
                }
            }
            catch (Exception ex) {
                Message.Error("xoa sinh vien that bai");
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task ResetTableAsync()
        {
            request= new StudentListRequestDto
            {
                Keyword = string.Empty,
                SortBy = "id",
                Descending = false,
                Page = 1,
                PageSize = 10
            };
            await ResetDataAsync();
             StateHasChanged();
        }

        private async Task ResetDataAsync()
        {
            try
            {
                studentList = await StudentManagement.StudentListAsync(request);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                Message.Error("du lieu co van de");
            }
        }

        private async Task FindStudentByIdAsync(string key)
        {
            isLoading = true;
            try
            {
                request.Page = 1;
                request.Keyword = key;
                await ResetDataAsync();
            }
            finally
            {
                isLoading = false;
            }
        }

        private async Task DeleteStudentAsync(StudentDto student)
        {
            try
            {
                var result= await StudentManagement.DeleteStudentAsync(student);
                if (result.Success)
                {
                    await ResetDataAsync();
                    Message.Success(result.Message);
                }
                else
                {
                    Message.Error(result.Message);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                Message.Error("xoa sv that bai");
            }
        }

        private async Task UpdateStudentAsync() {
            try
            {
                var result=await StudentManagement.UpdateStudentAsync(newStudent);
                if (result.Success) {
                    await ResetDataAsync();
                    Message.Success(result.Message);
                }
                else
                {
                    Message.Error(result.Message);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                Message.Error("cap nhat thong tin sv that bai");
            }
            await ResetDataAsync() ;
        }

        private void CloseModal()
        {
            openModal = false;
        }

        private async Task OnTableChangeAsync(QueryModel<StudentDto> query)
        {
            try
            {
                request.Page = query.PageIndex;
                request.PageSize = query.PageSize;
                studentList = await StudentManagement.StudentListAsync(request);
                Message.Success("tai bang thanh cong");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Message.Error("tai bang that bai");
            }
        }
    }
}
