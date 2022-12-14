using GoalHabitAPI.Models.Dtos;

namespace GoalHabitAPI.Services.GoalService
{
    public interface IGoalService
    {
        Task<List<Goal>> GetAllGoals();
        Task<List<GoalMainDto>> GetUserGoals();
        Task<GoalSelectedDto> GetGoal(Guid id);
        Task<List<Goal>> AddGoal(GoalAddDto goal);
        Task<GoalSelectedDto> UpdateGoal(Guid id, GoalSelectedDto request);
        Task<List<Goal>> DeleteGoal(Guid id);
    }
}
