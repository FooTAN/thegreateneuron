<header className="App-header">
<p>
  Go To Admin.
</p>
<a className="App-link" href="http://localhost/admin"> Admin </a>
</header>


function GotoSignup() {
    return (
        <div>
            <p>
            Go To Signup. Currently not a whole lot is working. You can signup, get a token. Token is sent back to you as a response shown in the console as well as a cookie.
            </p>
            <a href="/admin/signup"> <h2>Signup</h2> </a>
        </div>
    );
  }
  
  export default GotoSignup;