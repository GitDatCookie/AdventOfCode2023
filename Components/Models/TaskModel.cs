namespace AdventOfCode2023Blazor.Components.Models
{
    public class TaskModel
    {
        public string TaskContent { get; set; }
        public int TaskNumber { get; set; }
        public bool FirstPart { get; set; }

        public TaskModel(string taskContent, int taskNumber, bool firstPart)
        {
            TaskContent = taskContent;
            TaskNumber = taskNumber;
            FirstPart = firstPart;
        }
    }
}
