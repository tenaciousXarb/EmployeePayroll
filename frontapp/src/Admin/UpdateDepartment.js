import {useParams} from 'react-router-dom';
import { useState,useEffect } from 'react';
import axiosConfig from '../axiosConfig';
import LoggedAdminNavbar from '../Navigation/LoggedAdminNavbar';
import Form from 'react-bootstrap/Form';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Button from 'react-bootstrap/Button';

const UpdateDepartment=(props)=>
{
    const[Name,setName] = useState("");
    const[Tallowance,setTallowance] = useState("");
    const[Mallowance,setMallowance] = useState("");
    const[Leave,setLeave] = useState("");
    const[Id,setId] = useState("");

    const {id} = useParams();

    const[err,setErr] = useState("");
    const[msg,setMsg] = useState("");
    
    useEffect(()=>
    {
        axiosConfig.get(`/departments/${id}`)
        .then
        (
            (rsp)=>
            {
                setName(rsp.data.name);
                setTallowance(rsp.data.tallowance);
                setMallowance(rsp.data.mallowance);
                setLeave(rsp.data.leave);
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
        var data = {Id:Id,Name:Name,Tallowance:Tallowance,Mallowance:Mallowance,Leave:Leave};

        axiosConfig.post("/departments/update",data)
        .then
        (
            (rsp)=>
            {
                setErr('');
                console.log(rsp.data);
                setMsg(rsp.data);
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
            <h1 align="center">Edit Admin Profile</h1>
            <br/>
            <Form onSubmit={handleForm} align="center">
                <FloatingLabel controlId="floatingInput" label="Name" className="mb-3">
                    <Form.Control type="text" placeholder='Name' name="Name" value={Name} onChange={(e)=>{setName(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{err[0]}</span>
                    </Form.Text>
                </FloatingLabel>
                <FloatingLabel controlId="floatingInput" label="Tallowance" className="mb-3">
                    <Form.Control type="text" placeholder='Tallowance' name="Tallowance" value={Tallowance} onChange={(e)=>{setTallowance(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{err[1]}</span>
                    </Form.Text>
                </FloatingLabel>
                <FloatingLabel controlId="floatingInput" label="Mallowance" className="mb-3">
                    <Form.Control type="text" placeholder='Mallowance' name="Mallowance" value={Mallowance} onChange={(e)=>{setMallowance(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{err[2]}</span>
                    </Form.Text>
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
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{err[3]}</span>
                    </Form.Text>
                </FloatingLabel><br></br>
                <Button variant="primary" type="submit">Update</Button>
            </Form>
        </div>
    )
}

export default UpdateDepartment;