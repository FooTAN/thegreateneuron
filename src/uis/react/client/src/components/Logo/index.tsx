import React from 'react'
import './style.scss';

function Logo() {

    return (
    <>
        <div className="container logo">
            <a href="/" className="text-decoration-none"><img src='./SimpleLogoCF.png' className="logo__image align-top" ></img>
            <span className="logo__text align-bottom">The Great Neuron</span></a>
        </div>
    </>
    )
}

export default Logo
