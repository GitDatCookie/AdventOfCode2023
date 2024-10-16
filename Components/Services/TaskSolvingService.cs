using AdventOfCode2023Blazor.Components.Models;
using AdventOfCode2023Blazor.Components.Services.Tasks.Day1;
using AdventOfCode2023Blazor.Components.Services.Tasks.Day2;

namespace AdventOfCode2023Blazor.Components.Services
{
    public class TaskSolvingService
    {
        TaskModel taskModel;
        public TaskSolvingService(TaskModel taskModelInput)
        {
            taskModel = taskModelInput;
        }
        
        public string GetSolution(TaskModel taskModelInput)
        {
            switch (taskModelInput.TaskNumber)
            {
                case 0:
                    return "Day not yet implemented";
                case 1:
                    TrebuchetTask day1Task = new TrebuchetTask(taskModelInput);
                    return day1Task.SolveTask();
                case 2:
                    CubeConundrumTask day2Task = new CubeConundrumTask(taskModelInput);
                    return day2Task.SolveTask();
                default:
                    break;
            }
            string result = "test";
            return result ;
        }
    }
}
