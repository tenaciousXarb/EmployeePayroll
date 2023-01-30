import axiosConfig from '../axiosConfig';
import LoggedAdminNavbar from "../Navigation/LoggedAdminNavbar";
import React, { useState,useEffect,PureComponent } from 'react';
import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, Legend, PieChart, Pie, Radar, RadarChart, PolarGrid, PolarAngleAxis, PolarRadiusAxis } from 'recharts';


const Barchart=()=>
{
  const[data,setData] = useState();

  const[err,setErr] = useState("");
  const[msg,setMsg] = useState("");

  const data1 = [
    { name: "Group A", value: 400 },
    { name: "Group B", value: 300 },
    { name: "Group C", value: 300 },
    { name: "Group D", value: 200 },
    { name: "Group E", value: 278 },
    { name: "Group F", value: 189 }
  ];

  useEffect(()=>
  {
        axiosConfig.get("/employees")
        .then(
            (rsp)=>
            {
              setData(rsp.data);
              console.log(rsp.data);
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
    },[]);
  
  return (
    <div>
      <LoggedAdminNavbar/><br></br>
      <u><h3 className="text-center mt-3 mb-3">Branch-wise Average Salary</h3></u>
      <center>
        <BarChart
          width={800}
          height={300}
          data={data}
          margin={{
            top: 5,
            right: 30,
            left: 20,
            bottom: 5
          }}
        >
          <CartesianGrid strokeDasharray="6 3" />
          <XAxis dataKey="branch" />
          <YAxis />
          <Tooltip />
          <Legend />
          <Bar dataKey="salary" fill="#0AC998" />
        </BarChart>
      </center><br></br>
      <u><h3 className="text-center mt-3 mb-3">Number of Employees (Department-wise)</h3></u>
      <center>
      <PieChart width={400} height={400}>
      <Pie
        dataKey="deptId"
        startAngle={180}
        endAngle={0}
        data={data}
        cx={200}
        cy={200}
        outerRadius={150}
        fill="#BF271F"
        label
      />
    </PieChart>
      </center><br></br>
      <u><h3 className="text-center mt-3 mb-3">% of Leaves (Per Month)</h3></u>
      <center>
        <RadarChart
          cx={300}
          cy={250}
          outerRadius={150}
          width={500}
          height={500}
          data={data}
        >
          <PolarGrid />
          <PolarAngleAxis dataKey="designation" />
          <PolarRadiusAxis />
          <Radar
            dataKey="remLeave"
            stroke="#8884d8"
            fill="#8884d8"
            fillOpacity={2.9}
          />
        </RadarChart>
      </center>      
    </div>
    
  );
}

export default Barchart;