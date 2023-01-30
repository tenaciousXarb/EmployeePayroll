import React from 'react';
import { useState,useEffect } from 'react';
import axiosConfig from '../axiosConfig';
import Table from 'react-bootstrap/Table';
import { Link } from 'react-router-dom';
import LoggedEmpNavbar from '../Navigation/LoggedEmpNavbar';
import { Button } from 'react-bootstrap';
import jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';
import moment from 'moment/moment';

const SalaryReport=()=>
{
    const[Id,setId] = useState(localStorage.getItem('id'));
    const[jobs,setJobs] = useState([]);

    const[err,setErr] = useState("");
    const[msg,setMsg] = useState("");

    useEffect(()=>
    {
        axiosConfig.get(`/transactions/${Id}`)
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

    const handleForm=(event)=>
    {
        let info = [];
        var total = 0;
        jobs.forEach((element, index, array) => {
            info.push([element.Month, element.Amount, element.Date, "aaron13"])
            total = total + element.Amount
        })
        var doc = new jsPDF('portrait','px','a4','false');
        doc.setFont('Helvetica','bold');
        var s = "Monthly Report of "+localStorage.getItem('name');
        doc.text(150, 40, s);
        autoTable(doc, {
            head: [['Month', 'Amount', 'Date','Assigned By']],
            body: info,
            startY: 70
          });
          var sal = "Total Salary:"+total;
          doc.text(300, 300, sal);
        doc.save('MonthlyReport.pdf');
    }

    return(
        <div align="center">
            <LoggedEmpNavbar/><br></br>
            <h1 align="center">All Transactions</h1>
            <br/>
            <Table striped bordered hover variant="dark">
                <thead>
                    <tr>
                        <th>Amount</th>
                        <th>Date</th>
                        <th>Month</th>
                        <th>Assigned By</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        jobs.map((st)=>(
                            <tr>
                                <td>{st.amount}</td>
                                <td>{moment(st.date).format("LL")}</td>
                                <td>{st.month}</td>
                                <td>aaron13</td>
                            </tr>
                        ))
                    }
                </tbody>
            </Table>
            <Button variant="dark" onClick={handleForm}>Download</Button>
        </div>
    )
}
export default SalaryReport;