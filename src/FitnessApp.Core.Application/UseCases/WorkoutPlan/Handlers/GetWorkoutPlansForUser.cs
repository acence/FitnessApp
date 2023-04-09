using FitnessApp.Infrastructure.Database.Interfaces;
using MediatR;

namespace FitnessApp.Core.Application.UseCases.WorkoutPlan.Handlers
{
	public class GetWorkoutPlansForUser : IRequestHandler<GetWorkoutPlansForUser.Query, IEnumerable<Domain.WorkoutPlan>>
	{
		private readonly IWorkoutPlanRepository _workoutPlanRepository;

		public GetWorkoutPlansForUser(IWorkoutPlanRepository workoutPlanRepository)
		{
			_workoutPlanRepository = workoutPlanRepository;
		}
		public async Task<IEnumerable<Domain.WorkoutPlan>> Handle(Query request, CancellationToken cancellationToken)
		{
			return await _workoutPlanRepository.GetWorkoutPlansForUserAsync(request.UserId);
		}

		public class Query : IRequest<IEnumerable<Domain.WorkoutPlan>>
		{
			public Int32 UserId { get; set; }
		}
	}
}
