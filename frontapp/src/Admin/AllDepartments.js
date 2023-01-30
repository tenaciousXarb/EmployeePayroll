import React from 'react';
import Table from 'react-bootstrap/Table';
import { Link } from 'react-router-dom';

const AllDepartments=({ jobs, loading })=>
{
    if (loading)
    {
        return(
            <div>
                <h1 align="center">Loading...</h1>
                <br/><br/>
            </div>
        )
    }

    return(
        <div>
            <u><h1 align="center">Departments</h1></u>
            <br/>
            <Table striped bordered hover variant="dark">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Travel Allowance</th>
                        <th>Medical Allowance</th>
                        <th>Maximum Leaves</th>
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {
                        jobs.map((st)=>(
                            <tr>
                                <td>{st.name}</td>
                                <td>{st.tallowance}</td>
                                <td>{st.mallowance}</td>
                                <td>{st.leave}</td>
                                <td><Link to={`/departments/show/${st.id}`}>Department</Link></td>
                                <td><Link to={`/departments/delete/${st.id}`}>Delete</Link></td>
                            </tr>
                        ))
                    }
                </tbody>
            </Table>
        </div>
    )
}
export default AllDepartments;