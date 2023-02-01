import {BrowserRouter,Route,Routes} from 'react-router-dom';
import AddAdmin from './Admin/AddAdmin';
import AdminLogout from './Admin/AdminLogout';
import PagAllAdmin from './Admin/PagAllAdmin';
import AddLeave from './Employee/AddLeave';
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
                    <Route path="/employees/logout" element={<EmpLogout/>}></Route>
                </Routes>
            </BrowserRouter>
        </div>
    )
}
export default Main;