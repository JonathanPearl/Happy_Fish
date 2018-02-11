import React, {Component} from 'react';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import {
    Toolbar, ToolbarGroup, MenuItem
} from "material-ui";
import {BrowserRouter as Router, Route, Link} from "react-router-dom";
import * as _ from 'lodash';
import './Dashboard.css';
import Search from "../components/Search";
import Tanks from "../components/Tanks";
import Tank from "../components/Tank";


export default class Dashboard extends Component {
    constructor(props) {
        super(props);

        this.state = {
            menu_items: [
                {name: 'Tanks', icon: 'local_drink'},
                //{name: 'Producers', icon: 'local_library'},
                //{name: 'Suppliers', icon: 'local_shipping'},
                {name: 'Water Quality', icon: 'poll'},
                {name: 'Manager', icon: 'person_outline'},
                {name: 'Comparison Tools', icon: 'pie_chart'}
            ],
            tanks: [
                {
                    name: 'Tank 1',
                    background_image: 'https://images3.ratemyfishtank.com/photo/2/430x320/1000/605/I-have-2-tanks-and-working-on-my-3rd-The-1st-i-jCJfAG.jpg',
                    description: 'Live plants in an aquarium help to complete the nitrogen cycle, by utilizing nitrate as fertilizer. This 60-litre aquarium contains Anubias barteri and Echinodorus bleheri. A heater and small filter are in the background.'
                },
                {
                    name: 'Tank 2',
                    background_image: 'http://i3.wp.com/impactoffice.biz/view/how-to-choose-good-plants-for-a-tropical-fish-tank-neon-aquarium-plants-enter-image-description-here-enchanting-Black-and-Neon-Blue-Fish_cute-Neon-Aquarium-Background_awe-inspiring-Tetra-Aquarium-Setu.jpg?resize=890,700&strip=all',
                    description: 'Live plants in an aquarium help to complete the nitrogen cycle, by utilizing nitrate as fertilizer. This 60-litre aquarium contains Anubias barteri and Echinodorus bleheri. A heater and small filter are in the background.'
                },
                {
                    name: 'Tank 3',
                    background_image: 'https://m.media-amazon.com/images/S/aplus-seller-content-images-us-east-1/ATVPDKIKX0DER/A7L9OYZZBIOR5/B01IQKHBPC/hc0XcEFTQRWp._UX970_TTW__.jpg',
                    description: 'Live plants in an aquarium help to complete the nitrogen cycle, by utilizing nitrate as fertilizer. This 60-litre aquarium contains Anubias barteri and Echinodorus bleheri. A heater and small filter are in the background.'
                },
                {
                    name: 'Tank 4',
                    background_image: 'http://bestaquariumideas.com/wp-content/uploads/2016/05/small-freshwater-fish-aquarium.jpg',
                    description: 'Live plants in an aquarium help to complete the nitrogen cycle, by utilizing nitrate as fertilizer. This 60-litre aquarium contains Anubias barteri and Echinodorus bleheri. A heater and small filter are in the background.'
                },
            ],
            ph_value: '3', temperature_value: '4', o2_value: '87', nh3_value: '33', conductivity_value: '99',
            nutrition: [
                {name: 'Tilapia intermediate pellet 2grams', quantity: '10', time: '8:00'},
                {name: 'Tilapia intermediate pellet 2grams', quantity: '10', time: '10:00'},
                {name: 'Tilapia intermediate pellet 2grams', quantity: '10', time: '12:00'},
                {name: 'Tilapia intermediate pellet 2grams', quantity: '10', time: '14:00'},
                {name: 'Tilapia intermediate pellet 2grams', quantity: '10', time: '18:00'},
            ],
            selected_tank: 0
        }
    }

    upDateEnv(value, env_to_update) {
        this.setState({
            [env_to_update]: Number(value)
        });
    }

    setTank(tank_index) {
        this.setState({selected_tank: tank_index})
    }

    render() {
        return (
            <div className='dashboard-component'>
                <MuiThemeProvider>

                    <div>
                        <Toolbar style={{background: '#0066cc', textTransform: 'uppercase'}}>
                            <ToolbarGroup>
                            </ToolbarGroup>
                            <ToolbarGroup>
                                <Search/>
                            </ToolbarGroup>
                            <ToolbarGroup/>
                        </Toolbar>

                        <Router>
                        <div className="dash-body">
                            <div className='side-bar'>
                                {
                                    _.map(this.state.menu_items, (item, index) => (
                                        <Link to="/" key={index}>
                                            <MenuItem style={{color: '#fff', textAlign: 'left'}}>
                                                <i className="material-icons">{item.icon}</i> {item.name}
                                            </MenuItem>
                                        </Link>
                                    ))
                                }
                            </div>
                            <div className='main-content-area'>
                                {/*<Router>*/}
                                    <div>
                                        <Route exact path="/" render={() => <Tanks {...this.state}
                                                                                   setTank={this.setTank.bind(this)}/>}/>
                                        <Route exact path="/tanks" render={() => <Tank
                                            tank={this.state.tanks[this.state.selected_tank]} {...this.state}
                                            upDateEnv={this.upDateEnv.bind(this)}/>}/>
                                        <Route exact path="/search" render={() => <Search {...this.state}/>}/>
                                    </div>
                                {/*</Router>*/}
                            </div>
                        </div>
                        </Router>
                    </div>

                </MuiThemeProvider>
            </div>
        )
    }
}