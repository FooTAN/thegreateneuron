import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faUserCircle } from '@fortawesome/free-solid-svg-icons';
import './style.scss';
import { ButtonGroup, Dropdown, DropdownButton, Button } from 'react-bootstrap';

function LoginButton() {

    
    return (
    <>
        <Dropdown as={ButtonGroup}>
            <Dropdown.Toggle className="login_btn login_btn__border--focus">
            <span>
                <FontAwesomeIcon icon={faUserCircle} size="lg" className="icon me-1"/>
            </span>
            Login</Dropdown.Toggle>
            <Dropdown.Menu className="super-colors">
            <Dropdown.Item eventKey="1">Action</Dropdown.Item>
            <Dropdown.Item eventKey="2">Another action</Dropdown.Item>
            <Dropdown.Item eventKey="3" active>
                Active Item
            </Dropdown.Item>
            <Dropdown.Divider />
            <Dropdown.Item eventKey="4">Separated link</Dropdown.Item>
            </Dropdown.Menu>
        </Dropdown>
    </>
    )
}

export default LoginButton
