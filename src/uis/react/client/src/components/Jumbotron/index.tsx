import React from 'react'
import JumbotronBlock from '../JumbotronBlock';
import './style.scss';

function Jumbotron() {

    return (
    <div className="p-5 mb-4 rounded-3 jumbotron" style={{backgroundImage: "url(/jumbotronBgD.png)"}}>
            <div className="container-fluid py-1">
                <div className="row">
                    <div className="col">
                        <img src='./TGNLogoFull.png' className="jumbotron__img"></img>
                    </div>
                </div>
                <div className="row">
                    <div className="col-md-6 col-12">
                        <JumbotronBlock title="What is this site?">
                            This is a demonstration project. If you want to have a look at the source code, and read up on the project, then go to the <a className="link-light" href="https://github.com/FooTAN/thegreatneuron/wiki">wiki</a>.
                        </JumbotronBlock>
                    </div>
                    <div className="col-md-6 col-12">
                        <JumbotronBlock title="Repository">
                            Follow this link to clone the project at <a className="link-light" href="https://github.com/FooTAN/thegreatneuron">Github</a>
                        </JumbotronBlock>
                    </div>
                </div>

        </div>
    </div>)
}

export default Jumbotron







