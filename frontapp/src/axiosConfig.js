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
        config.headers["Allow"] = localStorage.getItem('role');
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
            /*console.log(err.response.headers.get("Allow"));
            if(err.response.headers.get("Allow"))
            {
                err.response.headers.Allow == "employee" ? window.location.href="/employee/home" : window.location.href="/admins/show"
            }
            else
            {
                localStorage.clear();
                window.location.href="/";
            }*/
        }
        return Promise.reject(err);
    }
);

export default instance;