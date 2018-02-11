import React, {Component} from 'react';
import './tanks.css';
import {Link} from "react-router-dom";

let tank_background = ['#064273', '#76b6c4', '#7fcdff', '#1da2d8', '#def3f6'];

export default class Tanks extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="tanks">
                <div className="heading">Tanks</div>

                <div className="tank-list">
                    {
                        this.props.tanks.map((tank, index) => {
                            let background = (Math.floor(Math.random() * tank_background.length));
                            console.log(tank_background[background]);
                            console.log(background);
                            return (
                                <div className="tank-item" key={tank.name}
                                     style={{background: tank_background[background]}}>
                                    <div className='title' style={{color: '#fff !important'}}>{tank.name}</div>
                                    <Link to='/tanks' onClick={() => this.props.setTank(index)}>
                                        <button>View Details</button>
                                    </Link>
                                </div>
                            )
                        })
                    }
                </div>
            </div>
        )
    }
}

