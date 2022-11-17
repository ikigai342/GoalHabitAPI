namespace GoalHabitAPI.Services.DtoService
{
    public static class DtoService
    {
        public static GoalMainDto AsDto(this Goal goal)
        {
            return new GoalMainDto
            {
                Id = goal.Id,
                Name = goal.Name,
                Description = goal.Description,
                Score = goal.Score,
                MaxScore = goal.MaxScore,
                GoalType = goal.GoalType,
            };
        }

        public static GoalSelectedDto AsSelectDto(this Goal goal)
        {
            return new GoalSelectedDto
            {
                Name = goal.Name,
                Description = goal.Description,
                Achievements = goal.Achievements,
                Sacrifices = goal.Sacrifices,
                Score = goal.Score,
                MaxScore = goal.MaxScore,
                GoalType = goal.GoalType,
            };
        }

        public static Goal AsDto(this GoalAddDto goal)
        {
            return new Goal
            {
                Id = Guid.NewGuid(),
                Name = goal.Name,
                Description = goal.Description,
                Achievements = goal.Achievements,
                Sacrifices = goal.Sacrifices,
                MaxScore = goal.MaxScore,
                GoalType = goal.GoalType,
                UserId = Guid.NewGuid(),
            };
        }

    }
}
