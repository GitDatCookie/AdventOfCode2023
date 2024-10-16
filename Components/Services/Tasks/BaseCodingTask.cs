using AdventOfCode2023Blazor.Components.Models;

namespace AdventOfCode2023Blazor.Components.Services.Tasks
{
    public abstract class BaseCodingTask : ICodingTask
    {
        protected bool firstPart { get; set; }
        protected string result { get; set; }
        protected string[] preProcessedLines { get; set; }

        protected BaseCodingTask(TaskModel taskModel)
        {
            firstPart = taskModel.FirstPart;
            preProcessedLines = taskModel.TaskContent
                .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        }

        public abstract string SolveTask();
    }
}
