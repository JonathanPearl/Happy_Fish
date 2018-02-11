import React, {Component} from 'react';
import './search.css';
import {withRouter} from "react-router-dom";
import createHistory from "history/createBrowserHistory"

export default class Search extends Component {
    constructor(props) {
        super(props);

        this.state = {
            search: ''
        }
    }

    searchProducts(e) {
        e.preventDefault();
        console.log(this.props);

        window.location =  `/search?${this.state.search}`;

    }

    render() {
        return (
            <form action="" onSubmit={this.searchProducts.bind(this)}>
                <div className='search-component'>
                    <input type="text" placeholder="Search" onChange={(e)=> this.setState({search:e.target.value})}/>
                    <i className="material-icons">search</i>
                </div>
            </form>
        )
    }
}

withRouter(Search);