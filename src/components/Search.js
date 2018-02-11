import React, {Component} from 'react';
import './search.css';

export default class Search extends Component {
    render() {
        return (
            <div className='search-component'>
                <input type="text" placeholder="Search"/>
                <i className="material-icons">search</i>
            </div>
        )
    }
}