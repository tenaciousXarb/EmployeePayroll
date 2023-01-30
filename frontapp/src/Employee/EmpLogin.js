import {useState} from 'react';
import axiosConfig from '../axiosConfig';
import LoggedOutNavbar from '../Navigation/LoggedOutNavbar';
import Form from 'react-bootstrap/Form';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Button from 'react-bootstrap/Button';

const EmpLogin=()=>
{
    const[Username,setUsername] = useState("");
    const[Password,setPassword] = useState("");

    const[flaw, setFlaw] = useState(false);

    const[err,setErr] = useState("");
    const[msg,setMsg] = useState("");

    const handleForm=(event)=>
    {
        event.preventDefault();
        var data = {Username:Username,Password:Password};

        axiosConfig.post("/employee/login",data)
        .then
        (
            (rsp)=>
            {
                setErr('');
                axiosConfig.get(`/employees/getbyname/${Username}`)
                .then(
                    (rsp)=>
                    {
                        localStorage.setItem('_authToken',rsp.data.tkey);
                        localStorage.setItem('username',rsp.data.username);
                        localStorage.setItem('id',rsp.data.id);
                        localStorage.setItem('name',rsp.data.name);
                        localStorage.setItem('address',rsp.data.address);
                        localStorage.setItem('email',rsp.data.email);
                        localStorage.setItem('phone',rsp.data.phone);
                        localStorage.setItem('city',rsp.data.city);
                        localStorage.setItem('bank',rsp.data.bankAccount);
                        localStorage.setItem('pincode',rsp.data.pincode);
                        localStorage.setItem('degree',rsp.data.degree);
                        localStorage.setItem('designation',rsp.data.designation);
                        localStorage.setItem('branch',rsp.data.branch);
                        localStorage.setItem('deptid',rsp.data.deptid);
                        localStorage.setItem('status',rsp.data.status);
                        window.location.href="/employee/home";
                    }
                )
            },
            (er)=>
            {
                if(er.response.status==400)
                {
                    setFlaw(true);
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
            <LoggedOutNavbar/><br></br>
            <h1 align="center">Employee Login</h1>
            <br/>
            <Form onSubmit={handleForm} align="center">
                <FloatingLabel controlId="floatingInput" label="Username" className="mb-3">
                    <Form.Control type="text" placeholder='Username' name="Username" value={Username} onChange={(e)=>{setUsername(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{flaw ? (err["errors"]? (err["errors"]["Username"]? err["errors"]["Username"][0] : '') : '') : ''}</span>
                    </Form.Text>
                </FloatingLabel>
                <FloatingLabel controlId="floatingPassword" label="Password">
                    <Form.Control type="password" placeholder='Password' name="Password" value={Password} onChange={(e)=>{setPassword(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{flaw ? (err["errors"]? (err["errors"]["Password"]? err["errors"]["Password"][0] : '') : err) : ''}</span>
                    </Form.Text>
                </FloatingLabel><br></br>
                <Button variant="primary" type="submit">Sign in</Button>
            </Form>
        </div>
    )
}
export default EmpLogin;