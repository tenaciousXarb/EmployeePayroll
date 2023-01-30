import React from 'react';
import LoggedAdminNavbar from '../Navigation/LoggedAdminNavbar';
import { useState,useEffect } from 'react';
import axiosConfig from '../axiosConfig';
import Table from 'react-bootstrap/Table';
import { Link } from 'react-router-dom';

const AllAdmin=({ jobs, loading })=>
{
    if (loading)
    {
        return(
            <div>
                <LoggedAdminNavbar/>
                <h1 align="center">Loading...</h1>
                <br/><br/>
            </div>
        )
    }

    return(
        <div>
            <LoggedAdminNavbar/>
            <h1 align="center">All Admins</h1>
            <br/>
            <Table striped bordered hover variant="dark">
                <thead align="center">
                    <tr>
                        <th>ID</th>
                        <th>Username</th>
                        <th colSpan={2}>Action</th>
                    </tr>
                </thead>
                <tbody align="center">
                    {
                        jobs.map((st)=>(
                            <tr>
                                <td>{st.id}</td>
                                <td>{st.username}</td>
                                <td><Link to={`/admins/show/${st.id}`}>Admin</Link></td>
                                <td><Link to={`/admins/delete/${st.id}`}>Delete</Link></td>
                            </tr>
                        ))
                    }
                </tbody>
            </Table>
        </div>
    )
}
export default AllAdmin;