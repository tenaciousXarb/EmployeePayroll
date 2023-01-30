import {useParams} from 'react-router-dom';
import { useState,useEffect } from 'react';
import axiosConfig from '../axiosConfig';
import { Link } from 'react-router-dom';
import LoggedAdminNavbar from '../Navigation/LoggedAdminNavbar';

const DeleteAdmin=(props)=>
{
    const {id} = useParams();

    const[err,setErr] = useState("");
    const[msg,setMsg] = useState("");
    
    useEffect(()=>
    {
        axiosConfig.get(`/admins/delete/${id}`)
        .then
        (
            (rsp)=>
            {
                window.location.href="/admins/show";
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
    [

    ]);

    return(
        <div>
            <LoggedAdminNavbar/>
            <h1>{msg}</h1>
        </div>
    )
}

export default DeleteAdmin;