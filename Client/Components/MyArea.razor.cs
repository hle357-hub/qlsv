using AntDesign.Charts;
using Microsoft.AspNetCore.Components;
using QuanLySinhVien.Shared;

namespace Client.Components
{
    public partial class MyArea
    {
        [Inject]
        private IChartDataService chartService { get; set; } = default!;

        private List<ChartDataDto> birthData = new();

        private AreaConfig config;

        protected override async Task OnInitializedAsync()
        {
            
            var response = await chartService.BirthStudentCountAsync();

            if (response.Success)
            {
                birthData = response.Data.ToList();
            }

            config = CreateChartConfig();
        }

        private AreaConfig CreateChartConfig()
        {
            return new AreaConfig
            {
                XField = "category",
                YField = "value",

                AutoFit = true,
                Height = 350,

                Smooth = true,

                AreaStyle = new GraphicStyle
                {
                    Fill = "l(270) 0:#ffffff 0.5:#7ec2f3 1:#1890ff"
                }
            };
        }
    }
}