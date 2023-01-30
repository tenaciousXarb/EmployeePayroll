import {BrowserRouter,Route,Routes} from 'react-router-dom';
import AddAdmin from './Admin/AddAdmin';
import AdminLogout from './Admin/AdminLogout';
import PagAllAdmin from './Admin/PagAllAdmin';
import AddLeave from './Employee/AddLeave';
import CreateCourse from './Employee/CreateCourse';
import EmpHome from './Employee/EmpHome';
import AddEmployee from './Universal/AddEmployee';
import Login from './Admin/Login';
import EmpLogin from './Employee/EmpLogin';
import EmpLogout from './Employee/EmpLogout';
import Barchart from './Admin/BarChart';
import DeleteAdmin from './Admin/DeleteAdmin';
import UpdateAdmin from './Admin/UpdateAdmin';
import Departments from './Admin/Departments';
import DeleteDepartment from './Admin/DeleteDepartment';
import UpdateDepartment from './Admin/UpdateDepartment';
import UpdateEmployee from './Employee/UpdateEmployee';
import SalaryReport from './Employee/SalaryReport';
import ChangePassword from './Employee/ChangePassword';
import PendingLeaves from './Admin/PendingLeaves';
import ApproveLeave from './Admin/ApproveLeave';
import RejectLeave from './Admin/RejectLeave';

const Main=()=>
{
    return (
        <div>
            <BrowserRouter>
                <Routes>
                    <Route path="/admin" element={<Login/>}></Route>
                    <Route path="/admin/create" element={<AddAdmin/>}></Route>
                    <Route path="/admins/show" element={<PagAllAdmin/>}></Route>
                    <Route path="/admins/show/:id" element={<UpdateAdmin/>}></Route>
                    <Route path="/admins/delete/:id" element={<DeleteAdmin/>}></Route>
                    <Route path="/admins/leaves" element={<PendingLeaves/>}></Route>
                    <Route path="/admins/stats" element={<Barchart/>}></Route>
                    <Route path="/approve/:id" element={<ApproveLeave/>}></Route>
                    <Route path="/reject/:id" element={<RejectLeave/>}></Route>
                    <Route path="/admins/logout" element={<AdminLogout/>}></Route>

                    <Route path="/departments" element={<Departments/>}></Route>
                    <Route path="/departments/show/:id" element={<UpdateDepartment/>}></Route>
                    <Route path="/departments/delete/:id" element={<DeleteDepartment/>}></Route>
                    

                    <Route path="/" element={<EmpLogin/>}></Route>
                    <Route path="/employee/registration" element={<AddEmployee/>}></Route>
                    <Route path="/employee/edit" element={<UpdateEmployee/>}></Route>
                    <Route path="/employee/salaryreport" element={<SalaryReport/>}></Route>
                    <Route path="/employee/changepassword" element={<ChangePassword/>}></Route>
                    <Route path="/employee/leaveapplication" element={<AddLeave/>}></Route>
                    <Route path="/employee/home" element={<EmpHome/>}></Route>
                    {//<Route path="/employee/home/:name" element={<EmpHome/>}></Route>
                    }
                    <Route path="/employees/logout" element={<EmpLogout/>}></Route>
                    {/*
                    <Route path="/tutorhome" element={<TutorHome/>}></Route>
                    <Route path="/tutorlogin" element={<TutorLogin/>}></Route>
                    <Route path="/betutor" element={<CreateTutor/>}></Route>
                    <Route path="/mytutorprofile" element={<MyProfile/>}></Route>
                    <Route path="/tutoreditprofile" element={<MyProfileEdit/>}></Route>
                    <Route path="/tutorpasswordchange" element={<UpdatePassword/>}></Route>
                    <Route path="/jobboard" element={<PagJobBoard/>}></Route>
                    <Route path="/tutormyjobs" element={<PagMyJobBoard/>}></Route>
                    <Route path="/tutorfeedbacks" element={<PagMyFeedbacks/>}></Route>
                    <Route path="/tutorstats" element={<BarChart/>}></Route>
                    <Route path="/forgotpw" element={<ForgotPassword/>}></Route>
                    <Route path="/fpws" element={<SendOtp/>}></Route>
                    <Route path="/fpnp" element={<AddNewPassword/>}></Route>
                    
                    <Route path="/edittutor/:id" element={<UpdateTutor/>}></Route>
                    <Route path="/tutorpwchange" element={<PasswordChange/>}></Route>
                    
                    <Route path="/tutorcourses" element={<Courses/>}></Route>
                    <Route path="/tutorcourses/addcourses" element={<CreateCourse/>}></Route>
                    <Route path="/tutorcourses/searchcourses" element={<SearchCourse/>}></Route>
                    <Route path="/tutorcourses/udcourses" element={<UdCourse/>}></Route>
                    <Route path="/tutorcourses/udcourses/edit/:id" element={<UpdateCourse/>}></Route>
                    <Route path="/tutorcourses/udcourses/delete/:id" element={<DeleteCourse/>}></Route>
                    <Route path="/tutorlogout" element={<TutorLogout/>}></Route>
    */}
                </Routes>
            </BrowserRouter>
        </div>
    )
}
export default Main;