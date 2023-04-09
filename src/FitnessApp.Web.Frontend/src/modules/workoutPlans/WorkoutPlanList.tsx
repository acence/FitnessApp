import { WorkoutPlan } from '../../models/WorkoutPlan/WorkoutPlan';
import { Fragment, useEffect, useState } from "react"
import { Link } from 'react-router-dom';

export default function WorkoutPlanList(props:WorkoutPlanListProps) {
    let [workoutPlans, setWorkoutPlans] = useState<WorkoutPlan[]>();
    let [loading, setLoading] = useState<boolean>(false);
    useEffect(() => {
        setLoading(true);
        setWorkoutPlans([{
            id: 1,
            name: "Test"
        }]);
        setLoading(false);
    }, [props.userId]);

    return (
        <Fragment>
            {loading ?
            <div>Loading workouts...</div>
            : workoutPlans?.map(workoutPlan => 
            <div>
                <Link key={workoutPlan.id} to={`workout-plan/${workoutPlan.id}`}>
                    {workoutPlan.name}
                </Link>
            </div>)}
        </Fragment>
        
    )
  }
  
  type WorkoutPlanListProps = {
    userId: number;
  }