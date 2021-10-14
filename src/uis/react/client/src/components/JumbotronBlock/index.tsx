import React from 'react'
import './style.scss';

interface Props {
    title?: string,
    children?:React.ReactNode
}
function JumbotronBlock({title, children}:Props) {

    return (
    <>
        <div className="container jumbotron-block my-5">
            <div className="container jumbotron-block__title">{title}</div>
            <div className="container jumbotron-block__content">{children}</div>
        </div>
    </>
    )
}

export default JumbotronBlock
