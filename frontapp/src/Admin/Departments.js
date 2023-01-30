import {useState} from 'react';
import axiosConfig from '../axiosConfig';
import LoggedAdminNavbar from '../Navigation/LoggedAdminNavbar';
import Form from 'react-bootstrap/Form';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Button from 'react-bootstrap/Button';
import PagAllDepartments from './PagAllDepartments';

const Departments=({ jobs, loading })=>
{
    const[Name,setName] = useState("");
    const[Tallowance,setTallowance] = useState("");
    const[Mallowance,setMallowance] = useState("");
    const[Leave,setLeave] = useState("");

    const[err,setErr] = useState("");
    const[msg,setMsg] = useState("");

    if (loading)
    {
        return(
            <div>
                <LoggedAdminNavbar/>
                <h1 align="center">Loading...</h1>
                <br/><br/>
            </div>
        )
    }

    const handleForm=(event)=>
    {
        event.preventDefault();
        var data = {Name:Name,Tallowance:Tallowance,Mallowance:Mallowance,Leave:Leave};

        axiosConfig.post("/departments/create",data)
        .then
        (
            (rsp)=>
            {
                setErr('');
                console.log(rsp.data);
                setMsg(rsp.data.msg);
                window.location.href="/departments";
            },
            (er)=>
            {
                if(er.response.status==400)
                {
                    console.log(er.response.data);
                    setErr(er.response.data);
                }
                else
                {
                    console.log(er.response.data);
                    setMsg("Server Error Occured");
                }
            }
        )
    }

    return(
        <div>
            <LoggedAdminNavbar/><br></br>
            <h1 align="center">New Department</h1>
            <br/>
            <Form onSubmit={handleForm} align="center">
                <FloatingLabel controlId="floatingInput" label="Name" className="mb-3">
                    <Form.Control type="text" placeholder='Name' name="Name" value={Name} onChange={(e)=>{setName(e.target.value)}}/>
                </FloatingLabel>
                <FloatingLabel controlId="floatingInput" label="Tallowance" className="mb-3">
                    <Form.Control type="text" placeholder='Tallowance' name="Tallowance" value={Tallowance} onChange={(e)=>{setTallowance(e.target.value)}}/>
                </FloatingLabel>
                <FloatingLabel controlId="floatingInput" label="Mallowance" className="mb-3">
                    <Form.Control type="text" placeholder='Mallowance' name="Mallowance" value={Mallowance} onChange={(e)=>{setMallowance(e.target.value)}}/>
                </FloatingLabel>
                <FloatingLabel controlId="floatingInput" label="Leave" className="mb-3">
                    <Form.Select aria-label="Default select example"  name="Leave" value={Leave} onChange={(e)=>{setLeave(e.target.value)}}>
                        <option value="" selected>Select</option>
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                        <option value="6">6</option>
                        <option value="7">7</option>
                    </Form.Select>
                </FloatingLabel><br></br>
                <Button variant="primary" type="submit">Register</Button>
            </Form>

            <br/><br/><br/>
            
            <PagAllDepartments/>
        </div>
    )
}
export default Departments;