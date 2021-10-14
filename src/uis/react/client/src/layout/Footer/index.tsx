import React from 'react'
import ScaffoldComponent from '../../components/ScaffoldComponent'

function Footer() {
    return (
        <div className="row">
            <div className="col-12 col-md">
            <ScaffoldComponent title="Summary and copyright" height="256px"></ScaffoldComponent>
            </div>
            <div className="col-6 col-md">
            </div>
            <div className="col-6 col-md">
            </div>
            <div className="col-6 col-md">
            <ScaffoldComponent title="Internal links" height="256px"></ScaffoldComponent>
            </div>
      </div>
    )
}

export default Footer
