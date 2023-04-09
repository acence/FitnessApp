import { useParams } from "react-router-dom"

export default function WorkoutPlanDetails()
{
    const { workoutId } = useParams();
    
    return <div>{ workoutId }</div>
}