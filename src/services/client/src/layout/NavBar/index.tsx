import React from 'react'

function NavBar() {
    
    return (
        <div className="d-flex flex-column flex-md-row align-items-center pb-3 mb-4 border-bottom">
            <a href="/" className="d-flex align-items-center text-dark text-decoration-none">
            <span className="fs-4">The Great Neuron</span>
            </a>
  
            <nav className="d-inline-flex mt-2 mt-md-0 ms-md-auto">
            <a className="me-3 py-2 text-dark text-decoration-none" href="/admin/signup/">TmpAdmin</a>
            <a className="py-2 text-dark text-decoration-none" href="#">Login</a>
            </nav>
      </div>
    )
}

export default NavBar
