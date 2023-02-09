import {useState} from 'react';
import axiosConfig from '../axiosConfig';
import { useEffect } from 'react';
import LoggedOutNavbar from '../Navigation/LoggedOutNavbar';
import Form from 'react-bootstrap/Form';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Button from 'react-bootstrap/Button';

const Login=()=>
{
    const[Username,setUsername] = useState("");
    const[Password,setPassword] = useState("");
    
    const[flaw,setFlaw] = useState(false);

    const[err,setErr] = useState("");
    const[msg,setMsg] = useState("");

    const handleForm=(event)=>
    {
        event.preventDefault();
        var data = {Username:Username,Password:Password};

        axiosConfig.post("/login",data)
        .then
        (
            (rsp)=>
            {
                localStorage.setItem('_authToken',rsp.data.tkey);
                localStorage.setItem('username',rsp.data.username);
                setErr('');
                console.log(rsp.data);
                setMsg(rsp.data);
                window.location.href="/admins/show";
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
            <h1 align="center">Admin Login</h1>
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
export default Login;