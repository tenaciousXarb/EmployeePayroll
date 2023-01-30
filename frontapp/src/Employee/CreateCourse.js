import {useState} from 'react';
import { jsPDF } from "jspdf";
//import MainNavbar from '../../MainNavbar';
//import Navbar from '../Navigation/Navbar';
import axiosConfig from '../axiosConfig';
import { useEffect } from 'react';
import LoggedOutNavbar from '../Navigation/LoggedOutNavbar';

const CreateCourse=()=>
{
    const[categories,setCategories] = useState("Apple");
    const[classes,setClasses] = useState("");
    const[subjects,setSubjects] = useState("");

    const[err,setErr] = useState("");
    const[msg,setMsg] = useState("");

    /*useEffect(()=>
    {
        if(!localStorage.getItem("_authToken")){
            window.location.href="/tutorlogin";
        }
    },
    []);*/

    const handleForm=(event)=>
    {
        var doc = new jsPDF('portrait','px','a4','false');
        doc.setFont('Helvetica', 'bold');
        doc.text(60, 80, 'Name');
        doc.text(60, 100, 'Name2');
        doc.text(60, 120, 'Name3');
        doc.addPage();
        doc.setFont('Times New Roman', 'italic');
        doc.text(60, 80, categories);
        doc.text(60, 100, 'Name2');
        doc.text(60, 120, 'Name3');
        doc.save('a.pdf');
    }
    
    return(
        <div>
            <LoggedOutNavbar/>
            <button onClick={handleForm}>Download</button>
        </div>
    )
}
export default CreateCourse;