using AntDesign.Charts;
using Microsoft.AspNetCore.Components;
using QuanLySinhVien.Shared;

namespace Client.Components
{
    public partial class MyBubble
    {
        [Inject]
        private IChartDataService chartDataService { get; set; } = default!;
        private List<BubbleDataDto> list = new();
        private ScatterConfig config= new();
        protected override async Task OnInitializedAsync()
        {
            var response = await chartDataService.SubjectRelationAsync();
            if (response.Success)
            {
                list = response.Data.ToList();
            }
            config = CreateConfig();
        }
        private ScatterConfig CreateConfig()
        {
            var minX = list.Min(x => x.X);
            var maxX = list.Max(x => x.X);

            var minY = list.Min(x => x.Y);
            var maxY = list.Max(x => x.Y);

            var paddingX = (maxX - minX) * 0.1;
            var paddingY = (maxY - minY) * 0.1;

            return new ScatterConfig
            {
                XField = "x",
                YField = "y",
                SizeField = "size",
                ColorField = "size",

                Color = new[]
                {
            "#ffd500",
            "#82cab2",
            "#193442",
            "#d18768",
            "#7e827a"
        },

                Shape = "circle",
                Size = new[] { 4, 20 },

                PointStyle = new GraphicStyle()
                {
                    FillOpacity = new decimal(0.8),
                    Stroke = "#bbb"
                },

                XAxis = new ValueTimeAxis
                {
                    Min = minX - paddingX,
                    Max = maxX + paddingX,

                    Grid = new BaseAxisGrid()
                    {
                        Line = new BaseAxisGridLine()
                        {
                            Style = new LineStyle()
                            {
                                Stroke = "#eee"
                            }
                        }
                    }
                },

                YAxis = new ValueTimeAxis()
                {
                    Min = minY - paddingY,
                    Max = maxY + paddingY,

                    Line = new BaseAxisLine()
                    {
                        Style = new LineStyle()
                        {
                            Stroke = "#aaa"
                        }
                    }
                },

                Quadrant = new QuadrantConfig()
                {
                    Label = new[]
                    {
                new
                {
                    Content = "Male decrease,\nfemale increase"
                },
                new
                {
                    Content = "Female decrease,\nmale increase"
                },
                new
                {
                    Content = "Female & male decrease"
                },
                new
                {
                    Content = "Female & male increase"
                },
            }
                }
            };
        }
    }
}
