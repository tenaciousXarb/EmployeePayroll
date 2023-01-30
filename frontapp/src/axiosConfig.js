import axios from 'axios';

const instance = axios.create
(
    {
        baseURL:'https://localhost:7023/api'
    }
);

instance.interceptors.request.use(
    (config)=>
    {
        config.headers["Authorization"] = localStorage.getItem('_authToken');
        return config;
    },
    (err)=>
    {
        return Promise.reject(err);
    }
);

instance.interceptors.response.use(
    (rsp)=>
    {
        return rsp;
    },
    (err)=>
    {
        if(err.response.status === 401)
        {
            localStorage.clear();
            window.location.href="/";
        }
        return Promise.reject(err);
    }
);

export default instance;