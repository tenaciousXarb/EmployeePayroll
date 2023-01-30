import {useParams} from 'react-router-dom';
import { useState,useEffect } from 'react';
import axiosConfig from '../axiosConfig';
import LoggedAdminNavbar from '../Navigation/LoggedAdminNavbar';
import Form from 'react-bootstrap/Form';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import LoggedEmpNavbar from '../Navigation/LoggedEmpNavbar';

const ChangePassword=()=>
{
    const[Cpassword,setCpassword] = useState("");
    const[Password,setPassword] = useState("");

    const[Id,setId] = useState(localStorage.getItem('id'));

    const[e,setE] = useState(false);

    const[err,setErr] = useState("");
    const[msg,setMsg] = useState("");

    const handleForm=(event)=>
    {
        event.preventDefault();
        if(Password !== Cpassword)
        {
            setE(true);
            setErr("Passwords do not match!");
        }
        else
        {
            var data = {Id:Id,Password:Password, Name:localStorage.getItem('name'),Phone:localStorage.getItem('phone'),Email:localStorage.getItem('email'),Address:localStorage.getItem('address'),City:localStorage.getItem('city'),Pincode:localStorage.getItem('pincode'),Degree:localStorage.getItem('degree'),BankAccount:localStorage.getItem('bank'),Username:localStorage.getItem('username')};

            axiosConfig.post("/employees/update",data)
            .then
            (
                (rsp)=>
                {
                    setErr('');
                    console.log(rsp.data);
                    setMsg(rsp.data);
                    window.location.href="/employee/changepassword";
                },
                (er)=>
                {
                    if(er.response.status==400)
                    {
                        setE(true);
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
    }

    return(
        <div>
            <LoggedEmpNavbar/><br></br>
            <h1 align="center">Change Password</h1>
            <br/>
            <Form onSubmit={handleForm} align="center">
                <FloatingLabel label="Password" className="mb-3">
                    <Form.Control type="password" placeholder='Password' name="Password" value={Password} onChange={(e)=>{setPassword(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{e? err[0]:''}</span>
                    </Form.Text>
                </FloatingLabel>
                
                <FloatingLabel label="Confirm Password" className="mb-3">
                    <Form.Control type="password" placeholder='Cpassword' name="Cpassword" value={Cpassword} onChange={(e)=>{setCpassword(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{e? err[1]:''}</span>
                    </Form.Text>
                </FloatingLabel><br></br>
                <Button variant="primary" type="submit">Change</Button>
            </Form>
        </div>
    )
}

export default ChangePassword;