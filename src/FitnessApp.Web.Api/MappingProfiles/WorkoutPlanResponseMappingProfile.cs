using AutoMapper;
using FitnessApp.Domain;
using FitnessApp.Web.Api.Models.Response.Workouts;

namespace FitnessApp.Web.Api.MappingProfiles
{
	public class WorkoutPlanResponseMappingProfile : Profile
	{
		public WorkoutPlanResponseMappingProfile()
		{
			CreateMap<WorkoutPlan, WorkoutPlanResponse>();
		}
	}
}
