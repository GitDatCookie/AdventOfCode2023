namespace AdventOfCode2023Blazor.Components.Services
{
    public class TaskSolvingService
    {
        private int day { get; set; }
        private string? taskFile { get; set; }

        public TaskSolvingService(int dayInput, string? taskFileInput)
        {
            day = dayInput;
            taskFile = taskFileInput;
        }
        
        public string GetSolution(int dayInput, string? taskFileInput)
        {
            switch (dayInput)
            {
                case 0:
                    return "Day not yet implemented";
                default:
                    break;
            }
            string result = "test";
            return result ;
        }
    }
}
