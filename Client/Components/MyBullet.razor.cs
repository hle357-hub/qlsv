using AntDesign.Charts;
using Microsoft.AspNetCore.Components;
using QuanLySinhVien.Shared;

namespace Client.Components
{
    public partial class MyBullet
    {
        [Inject]
        private IChartDataService chartDataService { get; set; } = default!;
        private List<BulletDataDto> list = new();
        private BulletConfig config = new();
        protected override async Task OnInitializedAsync()
        {
            var res= await chartDataService.SubjectTargetAsync();
            if (res.Success)
            {
                list= res.Data.ToList();
            }
            config = CreateConfig();
        }
        private BulletConfig CreateConfig()
        {
            return new BulletConfig
            {
                Data = list.Select(x => new BulletViewConfigData
                {
                    Title = x.Name,
                    Measures = new[] { (int)x.Value },
                    Targets = new[] { (int)x.Target },
                    Ranges = new[] { 100.0 }
                }).ToArray(),
                RangeMax = 100,
                Title = new Title
                {
                    Visible = true,
                    Text = "bieu do bullet"
                },
                Description = new Description
                {
                    Visible = true,
                    Text = "\"So sánh giá trị hiện tại với mục tiêu"
                },
                TargetField = "target",
                RangeField = "ranges",
                MeasureField = "measures",
                XField = "title"
            };
        }
    }
}
