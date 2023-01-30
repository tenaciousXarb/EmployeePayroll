import {useState} from 'react';
import axiosConfig from '../axiosConfig';
import Form from 'react-bootstrap/Form';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Button from 'react-bootstrap/Button';
import LoggedOutNavbar2 from '../Navigation/LoggedOutNavbar2';

const AddEmployee=()=>
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
    const[Password,setPassword] = useState("");

    const[flaw, setFlaw] = useState(false);

    const[err,setErr] = useState();
    const[msg,setMsg] = useState();

    const handleForm=(event)=>
    {
        event.preventDefault();
        var data = {Name:Name,Email:Email,Phone:Phone,Address:Address,City:City,Pincode:Pincode,Degree:Degree,BankAccount:BankAccount,Username:Username,Password:Password};

        axiosConfig.post("/employees/create",data)
        .then
        (
            (rsp)=>
            {
                setErr('');
                console.log(rsp.data);
                setMsg(rsp.data.msg);
                window.location.href = "/employee/registration";
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
            <LoggedOutNavbar2/><br></br>
            {msg}
            <h1 align="center">Employee Registration</h1>
            <br/>
            <Form onSubmit={handleForm} align="center">
                <FloatingLabel label="Name" className="mb-3">
                    <Form.Control type="text" placeholder='Name' name="Name" value={Name} onChange={(e)=>{setName(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{flaw ? (err["errors"]? (err["errors"]["Name"]? err["errors"]["Name"][0] : '') : '') : ''}</span>
                    </Form.Text>
                </FloatingLabel>

                <FloatingLabel label="Email" className="mb-3">
                    <Form.Control type="email" placeholder='Email' name="Email" value={Email} onChange={(e)=>{setEmail(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{flaw ? (err["errors"]? (err["errors"]["Email"]? err["errors"]["Email"][0] : '') : '') : ''}</span>
                    </Form.Text>
                </FloatingLabel>

                <FloatingLabel label="Phone" className="mb-3">
                    <Form.Control type="text" placeholder='Phone' name="Phone" value={Phone} onChange={(e)=>{setPhone(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{flaw ? (err["errors"]? (err["errors"]["Phone"]? err["errors"]["Phone"][0] : '') : '') : ''}</span>
                    </Form.Text>
                </FloatingLabel>

                <FloatingLabel label="Address" className="mb-3">
                    <Form.Control type="text" placeholder='Address' name="Address" value={Address} onChange={(e)=>{setAddress(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{flaw ? (err["errors"]? (err["errors"]["Address"]? err["errors"]["Address"][0] : '') : '') : ''}</span>
                    </Form.Text>
                </FloatingLabel>

                <FloatingLabel label="City" className="mb-3">
                    <Form.Control type="text" placeholder='City' name="City" value={City} onChange={(e)=>{setCity(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{flaw ? (err["errors"]? (err["errors"]["City"]? err["errors"]["City"][0] : '') : '') : ''}</span>
                    </Form.Text>
                </FloatingLabel>

                <FloatingLabel label="Pincode" className="mb-3">
                    <Form.Control type="text" placeholder='Pincode' name="Pincode" value={Pincode} onChange={(e)=>{setPincode(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{flaw ? (err["errors"]? (err["errors"]["Pincode"]? err["errors"]["Pincode"][0] : '') : '') : ''}</span>
                    </Form.Text>
                </FloatingLabel>

                <FloatingLabel label="Degree" className="mb-3">
                    <Form.Select aria-label="Default select example"  name="Degree" value={Degree} onChange={(e)=>{setDegree(e.target.value)}}>
                        <option value="" disabled selected>Select</option>
                        <option value="Bachelor's">Bachelor's</option>
                        <option value="Master's">Master's</option>
                        <option value="Doctorate">Doctorate</option>
                    </Form.Select>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{flaw ? (err["errors"]? (err["errors"]["Degree"]? err["errors"]["Degree"][0] : '') : '') : ''}</span>
                    </Form.Text>
                </FloatingLabel>

                <FloatingLabel label="Bank Account" className="mb-3">
                    <Form.Control type="text" placeholder='BankAccount' name="BankAccount" value={BankAccount} onChange={(e)=>{setBankAccount(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{flaw ? (err["errors"]? (err["errors"]["BankAccount"]? err["errors"]["BankAccount"][0] : '') : '') : ''}</span>
                    </Form.Text>
                </FloatingLabel>

                <FloatingLabel label="Username" className="mb-3">
                    <Form.Control type="text" placeholder='Username' name="Username" value={Username} onChange={(e)=>{setUsername(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{flaw ? (err["errors"]? (err["errors"]["Username"]? err["errors"]["Username"][0] : '') : '') : ''}</span>
                    </Form.Text>
                </FloatingLabel>

                <FloatingLabel label="Password" className="mb-3">
                    <Form.Control type="password" placeholder='Password' name="Password" value={Password} onChange={(e)=>{setPassword(e.target.value)}}/>
                    <Form.Text style={{color: 'red'}} className="text-muted">
                        <span style={{color: 'red'}}>{flaw ? (err["errors"]? (err["errors"]["Password"]? err["errors"]["Password"][0] : '') : '') : ''}</span>
                    </Form.Text>
                </FloatingLabel><br></br>
                <Button variant="primary" type="submit">Register</Button>
            </Form><br/><br/>
        </div>
    )
}
export default AddEmployee;