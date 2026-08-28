using AntDesign;
using AntDesign.Charts;
using Microsoft.AspNetCore.Components;
using QuanLySinhVien.Shared;

namespace Client.Pages
{
    public partial class Bang
    {
        [Inject]
        private IQlsvService qlsv { get; set; } = default!;
        [Inject]
        private IMessageService message { get; set; } = default!;
        private StudentListDto studentList = new StudentListDto();
        private Object[] chartdata = Array.Empty<object>();
        private bool renderChart = true;
        private StudentListRequestDto request = new StudentListRequestDto
        {
            Keyword = string.Empty,
            SortBy = "id",
            Descending = false,
            Page = 1,
            PageSize = 10
        };
        private ColumnConfig config;
        private ColumnConfig CreateChartConfig()
        {
            var dem = studentList.Students.Where(x => x.Address != null)
                .GroupBy(x => x.Address)
                .ToDictionary(x => x.Key, x => x.Count());
            chartdata = dem.Select(x => new
            {
                label = x.Key,
                value = x.Value,
            }).Cast<object>().ToArray();
            return new ColumnConfig
            {
                XField = "label",
                YField = "value",
                Height = 350,
                AutoFit = true,
                Padding = "auto",
                Animation = false
            };
        }
        protected override async Task OnInitializedAsync()
        {
            await ResetData();
            config = CreateChartConfig();
            renderChart = true;
            StateHasChanged();

        }
        private async Task ResetData()
        {
            try
            {
                studentList = await qlsv.StudentListAsync(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                message.Error("du lieu co van de");
            }
        }
    }
}
