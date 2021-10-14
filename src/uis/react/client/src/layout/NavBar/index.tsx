import React from 'react';
import Logo from '../../components/Logo';
import ScaffoldComponent from '../../components/ScaffoldComponent';

function NavBar() {
    
    return (
        <div className="d-flex flex-column flex-md-row align-items-center pb-3 mb-4 border-bottom">
            
            <div className="float-start">
            <Logo></Logo>
            </div>
  
            <nav className="d-inline-flex mt-2 mt-md-0 ms-md-auto">
            <ScaffoldComponent title="Login" height='44px'></ScaffoldComponent>
            </nav>
      </div>
    )
}

export default NavBar
