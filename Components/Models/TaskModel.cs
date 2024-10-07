namespace AdventOfCode2023Blazor.Components.Models
{
    public class TaskModel
    {
        public string TaskContent { get; set; }
        public int TaskNumber { get; set; }

        public TaskModel(string taskContent, int taskNumber)
        {
            TaskContent = taskContent;
            TaskNumber = taskNumber;
        }
    }
}
