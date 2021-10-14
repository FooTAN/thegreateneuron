import React from 'react'
import './style.scss';

interface Props{
    width?: string,
    height?: string,
    title?: string,
    className?: string
}
function ScaffoldComponent({ width = '256px', height='28px', title = 'FooBar', className }: Props) {

    return (
    <>
            <div className={`d-flex justify-content-center scaffold-component align-self-stretch ${className}`} style={{width: width, height: height}}>
            <span className='scaffold-component__text'>{title} Goes here</span>
        </div>
    </>
    )
}

export default ScaffoldComponent
