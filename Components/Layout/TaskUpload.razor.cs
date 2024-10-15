using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;

namespace AdventOfCode2023Blazor.Components.Layout
{
    public partial class TaskUpload
    {
        [Parameter]
        public int Day { get; set; } = 0;

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }

        private int? selectedTask;
        const int maxFileSize = 5000 * 1024;
        public string ErrorMessage { get; set; } = "";
        public string? FileContent { get; set; }
        public string? FileName { get; set; }
        public bool ShowTextbox { get; set; } = false;

        public void CreateTextbox()
        {
            ShowTextbox = !ShowTextbox;
        }
        public async Task FileUpload(InputFileChangeEventArgs e, int Day)
        {
            var browserFile = e.File;

            if (browserFile != null)
            {
                try
                {
                    FileName = browserFile.Name;
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

    }
}
