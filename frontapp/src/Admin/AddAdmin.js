import {useState} from 'react';
import axiosConfig from '../axiosConfig';
import { useEffect } from 'react';
import LoggedAdminNavbar from '../Navigation/LoggedAdminNavbar';
import Form from 'react-bootstrap/Form';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Button from 'react-bootstrap/Button';

const AddAdmin=()=>
{
    const[Username,setUsername] = useState("");
    const[Password,setPassword] = useState("");
    const[Cpassword,setCpassword] = useState("");

    const[err,setErr] = useState("");
    const[msg,setMsg] = useState("");

    const handleForm=(event)=>
    {
        event.preventDefault();
        var data = {Username:Username,Password:Password};

        axiosConfig.post("/admins/create",data)
        .then
        (
            (rsp)=>
            {
                setErr('');
                console.log(rsp.data);
                setMsg(rsp.data.msg);
            },
            (er)=>
            {
                if(er.response.status==422)
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
            <h1 align="center">New Admin</h1>
            <br/>
            <Form onSubmit={handleForm} align="center">
                <FloatingLabel controlId="floatingInput" label="Username" className="mb-3">
                    <Form.Control type="text" placeholder='Username' name="Username" value={Username} onChange={(e)=>{setUsername(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{err[0]}</span>
                    </Form.Text>
                </FloatingLabel>
                <FloatingLabel controlId="floatingPassword" label="Password">
                    <Form.Control type="password" placeholder='Password' name="Password" value={Password} onChange={(e)=>{setPassword(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{err[1]}</span>
                    </Form.Text>
                </FloatingLabel><br></br>
                <Button variant="primary" type="submit">Register</Button>
            </Form>
        </div>
    )
}
export default AddAdmin;