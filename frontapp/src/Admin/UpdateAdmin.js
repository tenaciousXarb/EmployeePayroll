import {useParams} from 'react-router-dom';
import { useState,useEffect } from 'react';
import axiosConfig from '../axiosConfig';
import LoggedAdminNavbar from '../Navigation/LoggedAdminNavbar';
import Form from 'react-bootstrap/Form';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';

const UpdateAdmin=(props)=>
{
    const[Username,setUsername] = useState("");
    const[Id,setId] = useState("");

    const {id} = useParams();

    const[err,setErr] = useState("");
    const[msg,setMsg] = useState("");
    
    useEffect(()=>
    {
        axiosConfig.get(`/admins/${id}`)
        .then
        (
            (rsp)=>
            {
                setUsername(rsp.data.username);
                setId(id);
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
    },
    []);

    const handleForm=(event)=>
    {
        event.preventDefault();
        var data = {Id:Id,Username:Username};

        axiosConfig.post("/admins/update",data)
        .then
        (
            (rsp)=>
            {
                setErr('');
                console.log(rsp.data);
                setMsg(rsp.data);
                window.location.href="/admins/show";
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
            <h1 align="center">Edit Admin Profile</h1>
            <br/>
            <Form onSubmit={handleForm} align="center">
                <FloatingLabel controlId="floatingInput" label="Username" className="mb-3">
                    <Form.Control type="text" placeholder='Username' name="Username" value={Username} onChange={(e)=>{setUsername(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{err[0]}</span>
                    </Form.Text>
                </FloatingLabel><br></br>
                <Button variant="primary" type="submit">Update</Button>
            </Form>
        </div>
    )
}

export default UpdateAdmin;