using Microsoft.AspNetCore.Components;

namespace AdventOfCode2023Blazor.Components.Pages.DayPages
{
    public partial class Day2
    {
        [Parameter]
        public bool Part2 { get; set; } = false;
        [Inject]
        NavigationManager navigationManager { get; set; }

        public void SwitchParts()
        {
            Part2 = !Part2;
        }
    }
}