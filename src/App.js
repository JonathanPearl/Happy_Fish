import React, {Component} from 'react';
import logo from './asserts/images/happy-fish-logo.svg';
import './App.css';
import Dashboard from "./screens/Dashboard";

class App extends Component {
    render() {
        return (
            <div className="App happy-fish-main-component">
                <header className="App-header">
                    <span>HAPPY</span> <img src={logo} className="App-logo" alt="logo"/> <span>FISH</span>
                </header>

                <div className="app-body">
                    <Dashboard/>
                </div>
            </div>
        );
    }
}

export default App;
