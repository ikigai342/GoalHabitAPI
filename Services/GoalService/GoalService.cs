using GoalHabitAPI.Services.DtoService;

namespace GoalHabitAPI.Services.GoalService
{
    public class GoalService : IGoalService
    {
        private readonly DataContext _context;

        public GoalService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Goal>> AddGoal(GoalAddDto goal)
        {
            _context.Goals.Add(
                new Goal
                {
                    Id = Guid.NewGuid(),
                    Name = goal.Name,
                    Description = goal.Description,
                    Achievements = goal.Achievements,
                    Sacrifices = goal.Sacrifices,
                    MaxScore = goal.MaxScore,
                    GoalType = goal.GoalType,
                    UserId = Guid.NewGuid(),
                });
            await _context.SaveChangesAsync();

            return await GetAllGoals();
        }

        public async Task<List<Goal>?> DeleteGoal(Guid id)
        {
            Goal goal = await _context.Goals.FindAsync(id);

            if (goal == null)
                return null;

            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();

            return await GetAllGoals();
        }

        public async Task<List<Goal>> GetAllGoals()
        {
            var goals = await _context.Goals.ToListAsync();
            return goals;
        }

        public async Task<GoalSelectedDto?> GetGoal(Guid id)
        {
            Goal goal = await _context.Goals.FindAsync(id);

            if (goal == null)
                return null;

            return goal.AsSelectDto();
        }

        public async Task<List<GoalMainDto>> GetUserGoals()
        {
            var goals = await _context.Goals.Select(goal => goal.AsDto()).ToListAsync();
            return goals;
        }

        public async Task<GoalSelectedDto?> UpdateGoal(Guid id, GoalSelectedDto request)
        {

            Goal goal = await _context.Goals.FindAsync(id);

            if (goal == null)
                return null;

            goal.Name = request.Name;
            goal.Description = request.Description;
            goal.Achievements = request.Achievements;
            goal.Sacrifices = request.Sacrifices;
            goal.Score = request.Score;
            goal.MaxScore = request.MaxScore;
            goal.GoalType = request.GoalType;
            await _context.SaveChangesAsync();

            return goal.AsSelectDto();
        }
    }
}
