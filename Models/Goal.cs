namespace GoalHabitAPI.Models
{
    public class Goal
    {
        public Guid Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Achievements { get; set; } = string.Empty;
        public string Sacrifices { get; set; } = string.Empty;
        public int MaxScore { get; set; } = 0;
        public int Score { get; set; } = 0;
        public GoalType GoalType { get; set; } = GoalType.Health;
        public Guid UserId { get; init; }
    }

    public enum GoalType
    {
        Health,
        Work,
        Life
    }
}
