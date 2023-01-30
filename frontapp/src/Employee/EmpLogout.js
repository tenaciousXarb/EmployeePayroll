import {useState,useEffect} from 'react';
import axiosConfig from '../axiosConfig';

const EmpLogout=()=>
{
    const[err,setErr] = useState("");
    const[msg,setMsg] = useState("");

    useEffect((config)=>
    {
        axiosConfig.get("/emp/logout")
        .then
        (
            (rsp)=>
            {
                localStorage.clear();
                window.location.href="/";
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
    
    return(
        <div></div>
    )
}
export default EmpLogout;