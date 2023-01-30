import {useParams} from 'react-router-dom';
import { useState,useEffect } from 'react';
import axiosConfig from '../axiosConfig';
import LoggedAdminNavbar from '../Navigation/LoggedAdminNavbar';
import Form from 'react-bootstrap/Form';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';

const RejectLeave=(props)=>
{
    const[EmpId,setEmpId] = useState("");
    const[Date,setDate] = useState("");
    const[Status,setStatus] = useState("");
    const[Nod,setNod] = useState("");
    const[AdminId,setAdminId] = useState("");
    const[Id,setId] = useState("");

    const {id} = useParams();

    const[err,setErr] = useState("");
    const[msg,setMsg] = useState("");
    
    useEffect(()=>
    {
        axiosConfig.get(`/vacations/${id}`)
        .then
        (
            (rsp)=>
            {
                setEmpId(rsp.data.empid);
                setDate(rsp.data.date);
                setStatus(rsp.data.status);
                setNod(rsp.data.nod);
                setAdminId(rsp.data.adminid);
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
        var data = {Id:Id,EmpId:EmpId,Date:Date,Status:Status,Nod:Nod,AdminId:AdminId};
        const value = 0;
        axiosConfig.post(`/vacations/update/${value}`,data)
        .then
        (
            (rsp)=>
            {
                setErr('');
                console.log(rsp.data);
                setMsg(rsp.data);
                window.location.href="/admins/leaves";
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
            <h1 align="center">Rejected!</h1>
            <br/>
            <Form onSubmit={handleForm} align="center">
                <Button variant="primary" type="submit">Okay</Button>
            </Form>
        </div>
    )
}

export default RejectLeave;