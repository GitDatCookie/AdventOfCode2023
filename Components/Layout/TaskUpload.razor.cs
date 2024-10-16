using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using AdventOfCode2023Blazor.Components.Services;
using AdventOfCode2023Blazor.Components.Models;

namespace AdventOfCode2023Blazor.Components.Layout
{
    public partial class TaskUpload
    {
        [Parameter]
        public int Day { get; set; } = 0;
        [Parameter]
        public bool FirstPart { get; set; }
        [Parameter]
        public int ComponentId { get; set; }

        private string UploadID => $"taskUplaod-{ComponentId}";

        const int maxFileSize = 5000 * 1024;
        public string ErrorMessage { get; set; } = "";
        public string? FileContent { get; set; }
        public string? FileName { get; set; }
        public string? Result { get; set; }


        public void ShowAnswerTextBox()
        {
            TaskModel taskModel = new(FileContent, Day, FirstPart);
            TaskSolvingService taskSolver = new TaskSolvingService(taskModel);
            Result = taskSolver.GetSolution(taskModel);
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
