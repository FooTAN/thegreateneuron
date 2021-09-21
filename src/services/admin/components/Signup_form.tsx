import React, { useState } from "react";
import axios, { AxiosError } from 'axios';

// this is bad, so only temporary to end the day with the application at a working state
const SignupForm = () => {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [errors, setErrors] = useState({});
    const [stringyfiedErrors, setStringyfiedErrors] = useState('');

    const onSubmit = async (event: React.FormEvent) => {
        event.preventDefault();

        try{
            const response = await axios.post('/api/auth/account/createuser',{userName, password});
            console.log("Res: "+JSON.stringify(response.data));

        }
        catch(err: any){
            setStringyfiedErrors(JSON.stringify(err.response.data.errors));
            console.log("ERR::: "+ stringyfiedErrors);
        }
    }

    return (
    <form onSubmit={onSubmit}>
        <h1>Sign Up</h1>
        <div className="form-group">
            <label>User Name</label>
            <input value={userName} onChange={e => setUserName(e.target.value)} className="form-control"></input>
        </div>
        <div className="form-group">
            <label>Password</label>
            <input value={password} onChange={e => setPassword(e.target.value)} type="password" className="form-control"></input>
        </div>
        <div className="alert alert-danger" role="alert">
            {stringyfiedErrors}
        </div>        
        <button className="btn btn-primary">Sign Up</button>
    </form>);
}

export default SignupForm