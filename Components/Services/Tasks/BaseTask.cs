namespace AdventOfCode2023Blazor.Components.Services.Tasks
{
    public abstract class BaseTask
    {
        public string Result { get; set; }
        public string ReturnResult()
        {
            return Result;
        }
    }

    
}
