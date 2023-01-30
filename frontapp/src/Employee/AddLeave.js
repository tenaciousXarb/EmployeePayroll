import {useState} from 'react';
import axiosConfig from '../axiosConfig';
import Form from 'react-bootstrap/Form';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import LoggedEmpNavbar from '../Navigation/LoggedEmpNavbar';

const AddLeave=()=>
{
    const[Date,setDate] = useState("");
    const[Nod,setNod] = useState("");
    const[EmpId,setEmpId] = useState(localStorage.getItem('id'));

    const[e, setE] = useState(false);

    const[err,setErr] = useState();
    const[msg,setMsg] = useState();

    const handleForm=(event)=>
    {
        event.preventDefault();
        var data = {EmpId:EmpId,Date:Date,Nod:Nod};

        axiosConfig.post("/vacations/create",data)
        .then
        (
            (rsp)=>
            {
                setErr('');
                console.log(rsp.data);
                setMsg(rsp.data.msg);
                window.location.href="/employee/home";
            },
            (er)=>
            {
                if(er.response.status==400)
                {
                    console.log(er.response.data);
                    setErr(er.response.data);
                    setE(true);
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
            <h1 align="center">Leave Application Form</h1>
            <br/>
            <Form onSubmit={handleForm} align="center">
                <FloatingLabel controlId="floatingInput" label="Date" className="mb-3">
                    <Form.Control type="date" placeholder='Date' name="Date" value={Date} onChange={(e)=>{setDate(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{e? err[0]:''}</span>
                    </Form.Text>
                </FloatingLabel>
                <FloatingLabel controlId="floatingInput" label="Number of Days" className="mb-3">
                    <Form.Control type="text" placeholder='Number of days' name="Nod" value={Nod} onChange={(e)=>{setNod(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{e? err[1]:''}</span>
                    </Form.Text>
                </FloatingLabel><br></br>
                <Button variant="primary" type="submit">Apply</Button>
            </Form>
        </div>
    )
}
export default AddLeave;