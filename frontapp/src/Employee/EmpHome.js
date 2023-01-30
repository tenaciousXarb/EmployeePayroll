import {Link, useParams} from 'react-router-dom';
import { useState,useEffect } from 'react';
import axiosConfig from '../axiosConfig';
import LoggedAdminNavbar from '../Navigation/LoggedAdminNavbar';
import Form from 'react-bootstrap/Form';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import LoggedEmpNavbar from '../Navigation/LoggedEmpNavbar';
import jsPDF from 'jspdf';

const EmpHome=(props)=>
{
    //const {name} = useParams();

    const[err,setErr] = useState("");
    const[msg,setMsg] = useState("");
    
    /*useEffect(()=>
    {
        axiosConfig.get(`/employees/getbyname/${name}`)
        .then(
            (rsp)=>
            {
                localStorage.setItem('id',rsp.data.id);
                localStorage.setItem('name',rsp.data.name);
                localStorage.setItem('address',rsp.data.address);
                localStorage.setItem('email',rsp.data.email);
                localStorage.setItem('phone',rsp.data.phone);
                localStorage.setItem('city',rsp.data.city);
                localStorage.setItem('bank',rsp.data.bankaccount);
                localStorage.setItem('pincode',rsp.data.pincode);
                localStorage.setItem('degree',rsp.data.degree);
                localStorage.setItem('designation',rsp.data.designation);
                localStorage.setItem('branch',rsp.data.branch);
                localStorage.setItem('deptid',rsp.data.deptid);
                localStorage.setItem('status',rsp.data.status);
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
    },[]);*/

    const handleForm=(event)=>
    {
        var doc = new jsPDF('portrait','px','a4','false');
        doc.setFont('Helvetica', 'bold');
        doc.text(60, 80, 'Name:');
        doc.text(60, 100, 'Username:');
        doc.text(60, 120, 'Address:');
        doc.text(60, 140, 'City:');
        doc.text(60, 160, 'Pincode:');
        doc.text(60, 180, 'Email:');
        doc.text(60, 200, 'Phone:');
        doc.text(60, 220, 'Degree:');
        doc.text(60, 240, 'Bank:');
        doc.setFont('Helvetica','normal');
        doc.text(150, 80, localStorage.getItem('name'));
        doc.text(150, 100, localStorage.getItem('username'));
        doc.text(150, 120, localStorage.getItem('address'));
        doc.text(150, 140, localStorage.getItem('city'));
        doc.text(150, 160, localStorage.getItem('pincode'));
        doc.text(150, 180, localStorage.getItem('email'));
        doc.text(150, 200, localStorage.getItem('phone'));
        doc.text(150, 220, localStorage.getItem('degree'));
        doc.text(150, 240, localStorage.getItem('bank'));
        
        /*autoTable(doc, {
            head: [['Name', 'Email', 'Country']],
            body: [
              ['David', 'david@example.com', 'Sweden'],
              ['Castille', 'castille@example.com', 'Spain']
            ],
          })*/
        doc.save('MyProfile.pdf');
    }

    return(
        <div>
            <LoggedEmpNavbar/><br></br>
            <u><h1 align="center">My Profile</h1></u>
            <br/>
            <Form align="center">
                <h3>
                    <Form.Group as={Row} className="mb-3" controlId="formPlaintextEmail">
                        <Form.Label column sm="2">Username:</Form.Label>
                        <Col sm="10">
                            <Form.Control plaintext readOnly defaultValue={localStorage.getItem('username')} />
                        </Col>
                    </Form.Group>

                    <Form.Group as={Row} className="mb-3" controlId="formPlaintextEmail">
                        <Form.Label column sm="2">Name:</Form.Label>
                        <Col sm="10">
                            <Form.Control plaintext readOnly defaultValue={localStorage.getItem('name')} />
                        </Col>
                    </Form.Group>

                    <Form.Group as={Row} className="mb-3" controlId="formPlaintextEmail">
                        <Form.Label column sm="2">Address:</Form.Label>
                        <Col sm="10">
                            <Form.Control plaintext readOnly defaultValue={localStorage.getItem('address')} />
                        </Col>
                    </Form.Group>

                    <Form.Group as={Row} className="mb-3" controlId="formPlaintextEmail">
                        <Form.Label column sm="2">City:</Form.Label>
                        <Col sm="10">
                            <Form.Control plaintext readOnly defaultValue={localStorage.getItem('city')} />
                        </Col>
                    </Form.Group>

                    <Form.Group as={Row} className="mb-3" controlId="formPlaintextEmail">
                        <Form.Label column sm="2">Pincode:</Form.Label>
                        <Col sm="10">
                            <Form.Control plaintext readOnly defaultValue={localStorage.getItem('pincode')} />
                        </Col>
                    </Form.Group>

                    <Form.Group as={Row} className="mb-3" controlId="formPlaintextEmail">
                        <Form.Label column sm="2">Email:</Form.Label>
                        <Col sm="10">
                            <Form.Control plaintext readOnly defaultValue={localStorage.getItem('email')} />
                        </Col>
                    </Form.Group>

                    <Form.Group as={Row} className="mb-3" controlId="formPlaintextEmail">
                        <Form.Label column sm="2">Phone:</Form.Label>
                        <Col sm="10">
                            <Form.Control plaintext readOnly defaultValue={localStorage.getItem('phone')} />
                        </Col>
                    </Form.Group>

                    <Form.Group as={Row} className="mb-3" controlId="formPlaintextEmail">
                        <Form.Label column sm="2">Degree:</Form.Label>
                        <Col sm="10">
                            <Form.Control plaintext readOnly defaultValue={localStorage.getItem('degree')} />
                        </Col>
                    </Form.Group>

                    <Form.Group as={Row} className="mb-3" controlId="formPlaintextEmail">
                        <Form.Label column sm="2">Bank Account:</Form.Label>
                        <Col sm="10">
                            <Form.Control plaintext readOnly defaultValue={localStorage.getItem('bank')} />
                        </Col>
                    </Form.Group>
                </h3>
                <Button variant="primary"><Link to={"/employee/edit"}>Edit</Link>Edit</Button> {" "}
                <Button variant="dark" onClick={handleForm}>Download</Button>
            </Form>
        </div>
    )
}

export default EmpHome;