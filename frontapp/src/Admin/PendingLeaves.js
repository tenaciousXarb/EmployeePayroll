import React from 'react';
import { useState,useEffect } from 'react';
import axiosConfig from '../axiosConfig';
import Table from 'react-bootstrap/Table';
import { Link } from 'react-router-dom';
import LoggedAdminNavbar from '../Navigation/LoggedAdminNavbar';
import { Button } from 'react-bootstrap';

const PendingLeaves=()=>
{
    const[Id,setId] = useState(localStorage.getItem('id'));
    const[jobs,setJobs] = useState([]);

    const[err,setErr] = useState("");
    const[msg,setMsg] = useState("");

    useEffect(()=>
    {
        axiosConfig.get("/vacations")
        .then(
            (rsp)=>
            {
                setJobs(rsp.data);
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
    },[]);

    return(
        <div align="center">
            <LoggedAdminNavbar/><br></br>
            <h1 align="center">All Transactions</h1>
            <br/>
            <Table striped bordered hover variant="dark">
                <thead align='center'>
                    <tr>
                        <th>Employee</th>
                        <th>Date</th>
                        <th>Number of Days</th>
                        <th>Status</th>
                        <th colSpan={2}>—</th>
                    </tr>
                </thead>
                <tbody align='center'>
                    {
                        jobs.map((st)=>(
                            <tr>
                                <td>{st.empId}</td>
                                <td>{st.date}</td>
                                <td>{st.nod}</td>
                                <td>{st.status}</td>
                                {
                                    (st.status === "Pending") ?
                                    <td><Button variant="success"><Link style={{color: "black", textDecoration: "none"}} to={`/approve/${st.Id}`}>Approve</Link></Button></td>
                                    : 
                                    <td></td>
                                }
                                {
                                    (st.status === "Pending") ?
                                    <td><Button variant="danger"><Link style={{color: "black", textDecoration: "none"}} to={`/reject/${st.Id}`}>Reject</Link></Button></td>
                                    :
                                    <td></td>
                                }
                            </tr>
                        ))
                    }
                </tbody>
            </Table>
        </div>
    )
}
export default PendingLeaves;