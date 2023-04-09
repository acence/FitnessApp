import './assets/style/App.scss'
import WorkoutPlanList from './modules/workoutPlans/WorkoutPlanList'

import { BrowserRouter, Routes, Route, Outlet } from "react-router-dom";
import WorkoutPlanDetails from './modules/workoutPlans/WorkoutPlanDetails';

function App() {

  return (
    <div className="container">
        <BrowserRouter>
          <Routes>        
            <Route path="/" element={<WorkoutPlanList userId={1} />} />
            <Route path="/workout-plan/:workoutId" element={<WorkoutPlanDetails />} />
          </Routes>
          <Outlet />
        </BrowserRouter>
    </div>
  )
}

export default App;
