const Signin = () => {
    return (
    <form>
        <h1>Sign In</h1>
        <div className="form-group">
            <label>User Name</label>
            <input className="form-control"></input>
        </div>
        <div className="form-group">
            <label>Password</label>
            <input type="password" className="form-control"></input>
        </div>
        <button className="btn btn-primary">Sign In</button>
    </form>);
}

export default Signin