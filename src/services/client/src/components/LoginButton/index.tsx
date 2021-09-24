import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faUserCircle } from '@fortawesome/free-solid-svg-icons';
import './style.scss';

function LoginButton() {
    return (
        <span>
            <FontAwesomeIcon icon={faUserCircle} size="lg" className="icon me-1"/>
            <a className="py-2 text-dark text-decoration-none" href="#">Login</a>
        </span>
    )
}

export default LoginButton
