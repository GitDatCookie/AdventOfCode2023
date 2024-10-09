using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace AdventOfCode2023Blazor.Components.Layout
{
    public partial class AdventCalendar
    {
        [Inject]
        private NavigationManager Navigation { get; set; }

        [Parameter]
        public EventCallback<int> OnDaySelected { get; set; }
        private List<ButtonModel> buttonList = new();
        private Random random = new();
        private class ButtonModel
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public int Day { get; set; }
            public string BackgroundColour { get; set; } = "black";
            public string TextColour { get; set; } = "white";
            public int TextSize { get; set; } = 16;
            public bool IsSelected { get; set; } = false;

        }

        private static readonly List<int> adventCalendarDays = Enumerable.Range(1, 25)
        .OrderBy(r => Random.Shared.Next())
        .ToList();

        
        protected override void OnInitialized()
        {
            buttonList = GenerateButtons();
        }

        private void OnDayClick(ButtonModel button)
        {
            foreach (var btn in buttonList)
            {
                btn.IsSelected = false;
            }
            button.IsSelected = true;
            Navigation.NavigateTo($"/task/{button.Day}");
                
        }

        private List<ButtonModel> GenerateButtons()
        {
            var buttons = new List<ButtonModel>();
            var random = new Random();
            var grid = new bool[5, 10];

            var buttonTypes = new List<(int width, int height)>
        {
            (2, 2),
            (1, 2),
            (2, 1),
            (1, 1)
        };

            var buttonCounts = new List<int> { 5, 5, 5, 10 };
            int dayCount = 0;
            buttons.AddRange(Enumerable.Range(0, buttonCounts.Count)
                .SelectMany(type => Enumerable.Range(0, buttonCounts[type])
                    .Select(count =>
                    {
                        var buttonModel = new ButtonModel
                        {
                            Width = buttonTypes[type].width,
                            Height = buttonTypes[type].height,
                            Day = adventCalendarDays[dayCount++],
                            BackgroundColour = Random.Shared.Next(2) == 0 ? "black" : "grey",
                            TextSize = type == 0 ? 60 : type == 1 || type == 2 ? 40 : 30
                        };
                        buttonModel.TextColour = buttonModel.BackgroundColour == "black" ? "white" : "black";
                        return buttonModel;
                    }))
                .ToList()
                .Select(button =>
                {
                    PlaceButton(buttons, grid, button);
                    return button;
                }));

            return buttons;
        }

        private void PlaceButton(List<ButtonModel> buttons, bool[,] grid, ButtonModel button)
        {
            bool spaceAvailable = false;

            while (!spaceAvailable)
            {
                button.X = random.Next(0, 5 - button.Width + 1);
                button.Y = random.Next(0, 10 - button.Height + 1);

                spaceAvailable = IsSpaceAvailable(grid, button);
            }

            Enumerable.Range(0, button.Width)
                .SelectMany(row => Enumerable.Range(0, button.Height).Select(column => (row, column)))
                .ToList()
                .ForEach(tuple => grid[button.X + tuple.row, button.Y + tuple.column] = true); ;

            buttons.Add(button);
        }

        private bool IsSpaceAvailable(bool[,] grid, ButtonModel button)
        {
            return !Enumerable.Range(0, button.Width)
                .SelectMany(row => Enumerable.Range(0, button.Height)
                .Select(column => grid[button.X + row, button.Y + column]))
                .Any(x => x);
        }
    }
}