import {useParams} from 'react-router-dom';
import { useState,useEffect } from 'react';
import axiosConfig from '../axiosConfig';
import LoggedAdminNavbar from '../Navigation/LoggedAdminNavbar';

const DeleteDepartment=(props)=>
{
    const {id} = useParams();

    const[err,setErr] = useState("");
    const[msg,setMsg] = useState("");
    
    useEffect(()=>
    {
        axiosConfig.get(`/departments/delete/${id}`)
        .then
        (
            (rsp)=>
            {
                window.location.href="/departments";
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
        </div>
    )
}

export default DeleteDepartment;