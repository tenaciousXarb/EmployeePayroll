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

const UpdateSalary=()=>
{
    const[Name,setName] = useState("");
    const[Email,setEmail] = useState("");
    const[Phone,setPhone] = useState("");
    const[Address,setAddress] = useState("");
    const[City,setCity] = useState("");
    const[Pincode,setPincode] = useState("");
    const[Degree,setDegree] = useState("");
    const[BankAccount,setBankAccount] = useState("");
    const[Username,setUsername] = useState("");
    const[Id,setId] = useState(localStorage.getItem('id'));

    const[e,setE] = useState(false);

    const[err,setErr] = useState("");
    const[msg,setMsg] = useState("");
    
    useEffect(()=>
    {
        axiosConfig.get(`/employees/${Id}`)
        .then
        (
            (rsp)=>
            {
                setName(rsp.data.name);
                setEmail(rsp.data.email);
                setPhone(rsp.data.phone);
                setAddress(rsp.data.address);
                setCity(rsp.data.city);
                setPincode(rsp.data.pincode);
                setDegree(rsp.data.degree);
                setBankAccount(rsp.data.bankaccount);
                setUsername(rsp.data.username);
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
    },
    []);

    const handleForm=(event)=>
    {
        event.preventDefault();
        var data = {Id:Id,Name:Name,Email:Email,Phone:Phone,Address:Address,City:City,Pincode:Pincode,Degree:Degree,BankAccount:BankAccount,Username:Username};

        axiosConfig.post("/employees/update",data)
        .then
        (
            (rsp)=>
            {
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

                setErr('');
                console.log(rsp.data);
                setMsg(rsp.data);
                window.location.href="/employee/home";
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
            <LoggedEmpNavbar/><br></br>
            <h1 align="center">Update Profile</h1>
            <br/>
            <Form onSubmit={handleForm} align="center">
                <FloatingLabel controlId="floatingInput" label="Name" className="mb-3">
                    <Form.Control type="text" placeholder='Name' name="Name" value={Name} onChange={(e)=>{setName(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{e? err[0]:''}</span>
                    </Form.Text>
                </FloatingLabel>

                <FloatingLabel controlId="floatingInput" label="Email" className="mb-3">
                    <Form.Control type="email" placeholder='Email' name="Email" value={Email} onChange={(e)=>{setEmail(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{e? err[1]:''}</span>
                    </Form.Text>
                </FloatingLabel>

                <FloatingLabel controlId="floatingInput" label="Phone" className="mb-3">
                    <Form.Control type="text" placeholder='Phone' name="Phone" value={Phone} onChange={(e)=>{setPhone(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{e? err[2]:''}</span>
                    </Form.Text>
                </FloatingLabel>

                <FloatingLabel controlId="floatingInput" label="Address" className="mb-3">
                    <Form.Control type="text" placeholder='Address' name="Address" value={Address} onChange={(e)=>{setAddress(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{e? err[3]:''}</span>
                    </Form.Text>
                </FloatingLabel>

                <FloatingLabel controlId="floatingInput" label="City" className="mb-3">
                    <Form.Control type="text" placeholder='City' name="City" value={City} onChange={(e)=>{setCity(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{e? err[4]:''}</span>
                    </Form.Text>
                </FloatingLabel>

                <FloatingLabel controlId="floatingInput" label="Pincode" className="mb-3">
                    <Form.Control type="text" placeholder='Pincode' name="Pincode" value={Pincode} onChange={(e)=>{setPincode(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{e? err[5]:''}</span>
                    </Form.Text>
                </FloatingLabel>

                <FloatingLabel controlId="floatingInput" label="Degree" className="mb-3">
                    <Form.Select aria-label="Default select example"  name="Degree" value={Degree} onChange={(e)=>{setDegree(e.target.value)}}>
                        <option value="" selected>Select</option>
                        <option value="Bachelor's">Bachelor's</option>
                        <option value="Master's">Master's</option>
                        <option value="Doctorate">Doctorate</option>
                    </Form.Select>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{e? err[6]:''}</span>
                    </Form.Text>
                </FloatingLabel>

                <FloatingLabel controlId="floatingInput" label="BankAccount" className="mb-3">
                    <Form.Control type="text" placeholder='BankAccount' name="BankAccount" value={BankAccount} onChange={(e)=>{setBankAccount(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{e? err[7]:''}</span>
                    </Form.Text>
                </FloatingLabel>

                <FloatingLabel controlId="floatingInput" label="Username" className="mb-3">
                    <Form.Control type="text" placeholder='Username' name="Username" value={Username} onChange={(e)=>{setUsername(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{e? err[8]:''}</span>
                    </Form.Text>
                </FloatingLabel><br></br>
                <Button variant="primary" type="submit">Update</Button>
            </Form>
        </div>
    )
}

export default UpdateSalary;