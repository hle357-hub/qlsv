using AntDesign.Charts;
using Microsoft.AspNetCore.Components;
using QuanLySinhVien.Shared;
namespace Client.Components
{
    public partial class MyBar
    {
        [Inject]
        private IChartDataService chartService { get; set; } = default!;
        private List<ChartDataDto> classStudents = new();
        private BarConfig config;
        protected override async Task OnInitializedAsync()
        {

            var response = await chartService.ClassStudentCountAsync();

            if (response.Success)
            {
                classStudents = response.Data.ToList();
            }

            config = CreateConfig();
        }

        private BarConfig CreateConfig()
        {
            return new BarConfig
            {
                XField = "category",
                YField = "value",

                AutoFit = true,
                Height = 350,


                BarStyle = new GraphicStyle
                {
                    Fill = "l(270) 0:#ffffff 0.5:#7ec2f3 1:#1890ff"
                }
            };
        }
    }
}
