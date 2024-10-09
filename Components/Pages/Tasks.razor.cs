using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace AdventOfCode2023Blazor.Components.Pages
{
    public partial class Tasks
    {
        [Parameter]
        public int day { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            HandleDaySelected(day);
        }

        private int? selectedTask;
        const int maxFileSize = 5000 * 1024;
        public string ErrorMessage { get; set; } = "";
        public string? FileContent { get; set; }

        public async Task FileUpload(InputFileChangeEventArgs e)
        {
            var browserFile = e.File;

            if (browserFile != null)
            {
                try
                {
                    var fileStream = browserFile.OpenReadStream(maxFileSize);
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        FileContent = await reader.ReadToEndAsync();

                    }
                }
                catch (Exception ಥ_ಥ)
                {
                    ErrorMessage = ಥ_ಥ.Message;
                }
            }
        }

        private void HandleDaySelected(int day)
        {
            selectedTask = day;
            Console.WriteLine($"Selected day: {day}");
            StateHasChanged();
        }
    }
}