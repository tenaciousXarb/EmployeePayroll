import React, { useState, useEffect } from 'react';
import AllAdmin from './AllAdmin';
import Pagi from './Pagi';
import axiosConfig from '../axiosConfig';

const PagAllAdmin = () =>
{
    const[jobs,setJobs] = useState([]);

    
    const [loading, setLoading] = useState(false);
    const [currentPage, setCurrentPage] = useState(1);
    const [postsPerPage] = useState(25);

    useEffect(() => 
    {
        const fetchPosts = async () =>
        {
            setLoading(true);
            const res = await axiosConfig.get("/admins");
            console.log(res.data);
            setJobs(res.data);
            setLoading(false);
        };
        fetchPosts();
    },
    []);

    const indexOfLastPost = currentPage * postsPerPage;
    const indexOfFirstPost = indexOfLastPost - postsPerPage;
    const currentPosts = jobs.slice(indexOfFirstPost, indexOfLastPost);

    // Change page
    const paginate = pageNumber => setCurrentPage(pageNumber);

    return (
    <div>
        <AllAdmin jobs={currentPosts} loading={loading}/>
        <Pagi
            postsPerPage={postsPerPage}
            totalPosts={jobs.length}
            paginate={paginate}
        />
    </div>
    );
};

export default PagAllAdmin;