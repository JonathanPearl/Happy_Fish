import React, {Component} from 'react';
import * as _ from 'lodash';
import './tanks.css'
import Chart from 'chart.js';
import {RaisedButton} from "material-ui";
import Search from "material-ui/svg-icons/action/search";
import Save from "material-ui/svg-icons/content/save";

export default class Tank extends Component {
    constructor(props) {
        super(props);

        this.state = {
            dynamic_data: []
        }
    }

    createDynamicData() {
        let dynamic_data = [];

        for (let i = 0; i <= 10; i++) {
            console.log(i);
            dynamic_data.push(Math.floor(Math.random() * 100));
        }

        let temperature_level_colors = ['240,10,10', '178,0,0', '93,86,124', '25,75,255', '0,34,201'];
        let temperature_level_color = temperature_level_colors[2];
        let ph_level_colors = ['254,0,2', '217,253,7', '55,167,55', '0,77,255', '68,0,139'];
        let ph_level_color = ph_level_colors[4];

        const ctx = document.getElementById("tank-health-chart");
        new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["1 - 2 Weeks", "2 - 3 Weeks", "3 - 4 Weeks", "4 - 5 Weeks"],
                datasets: [{
                    label: "Oxygen (02)",
                    fill: false,
                    lineTension: 0.2,
                    backgroundColor: "rgba(0, 102, 204, 0.4)",
                    borderColor: "#0066cc", // The main line color
                    borderWidth: 2,
                    borderCapStyle: 'square',
                    borderJoinStyle: 'miter',
                    pointBorderColor: "#0066cc",
                    pointBackgroundColor: "#0066cc",
                    pointBorderWidth: 1,
                    pointHoverRadius: 8,
                    pointHoverBackgroundColor: "#0066cc",
                    pointHoverBorderColor: "#0066cc",
                    pointHoverBorderWidth: 2,
                    pointRadius: 4,
                    pointHitRadius: 10,
                    data: this.state.dynamic_data,
                }, {
                    label: "PH",
                    fill: true,
                    lineTension: 0.1,
                    backgroundColor: `rgba(${ph_level_color}, 0.4)`,
                    borderColor: `rgb(${ph_level_color})`,
                    borderWidth: 2,
                    borderCapStyle: 'butt',
                    borderJoinStyle: 'miter',
                    pointBorderColor: `rgb(${ph_level_color})`,
                    pointBackgroundColor: `rgb(${ph_level_color})`,
                    pointBorderWidth: 1,
                    pointHoverRadius: 8,
                    pointHoverBackgroundColor: ph_level_color,
                    pointHoverBorderColor: ph_level_color,
                    pointHoverBorderWidth: 2,
                    pointRadius: 4,
                    pointHitRadius: 10,
                    data: [10, 20, 60, 95, 64, 78, 90, 70, 40, 70, 89],
                }, {
                    label: "Ammonia (NH3)",
                    fill: true,
                    lineTension: 0.1,
                    backgroundColor: "rgba(0,0,0,0.4)",
                    borderColor: "#180000",
                    borderWidth: 2,
                    borderCapStyle: 'butt',
                    borderDash: [],
                    borderDashOffset: 0.0,
                    borderJoinStyle: 'miter',
                    pointBorderColor: "white",
                    pointBackgroundColor: "black",
                    pointBorderWidth: 1,
                    pointHoverRadius: 8,
                    pointHoverBackgroundColor: "black",
                    pointHoverBorderColor: "black",
                    pointHoverBorderWidth: 2,
                    pointRadius: 4,
                    pointHitRadius: 10,
                    data: [89, 70, 60, 45, 30, 22, 45, 50, 70, 70, 90],
                }, {
                    label: "Temperature",
                    fill: true,
                    lineTension: 0.1,
                    backgroundColor: `rgba(${temperature_level_color}, 0.4)`,
                    borderColor: `rgb(${temperature_level_color}, 0.4)`,
                    borderWidth: 2,
                    borderCapStyle: 'butt',
                    borderDash: [],
                    borderDashOffset: 0.0,
                    borderJoinStyle: 'miter',
                    pointBorderColor: "white",
                    pointBackgroundColor: "black",
                    pointBorderWidth: 1,
                    pointHoverRadius: 8,
                    pointHoverBackgroundColor: `rgba(${temperature_level_color}, 0.4)`,
                    pointHoverBorderColor: `rgba(${temperature_level_color}, 0.4)`,
                    pointHoverBorderWidth: 2,
                    pointRadius: 4,
                    pointHitRadius: 10,
                    data: [20, 70, 30, 45, 30, 22, 45, 56, 70, 70, 90],
                }

                ]
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        },
                        scaleLabel: {
                            display: true,
                            labelString: 'Environment Health',
                            fontSize: 16
                        }
                    }],
                    xAxes: [{
                        scaleLabel: {
                            display: true,
                            labelString: 'Date',
                            fontSize: 16
                        }
                    }]
                }
            }
        });

        this.setState({dynamic_data}, () => console.log(dynamic_data));
    }

    componentDidMount() {
        this.createDynamicData();

        setInterval(() => this.createDynamicData(), 5000);

        let ph_level_colors = ['254,0,2', '217,253,7', '55,167,55', '0,77,255', '68,0,139'];
        let ph_level_color = ph_level_colors[4];

        const ctx_chart2 = document.getElementById("tank-health-chart2");
        new Chart(ctx_chart2, {
            type: 'line',
            data: {
                labels: ["1 - 2 Weeks", "2 - 3 Weeks", "3 - 4 Weeks", "4 - 5 Weeks"],
                datasets: [{
                    label: "Tilapia",
                    fill: false,
                    lineTension: 0.2,
                    backgroundColor: "rgba(0, 102, 204, 0.4)",
                    borderColor: "#0066cc", // The main line color
                    borderWidth: 2,
                    borderCapStyle: 'square',
                    borderJoinStyle: 'miter',
                    pointBorderColor: "#0066cc",
                    pointBackgroundColor: "#0066cc",
                    pointBorderWidth: 1,
                    pointHoverRadius: 8,
                    pointHoverBackgroundColor: "#0066cc",
                    pointHoverBorderColor: "#0066cc",
                    pointHoverBorderWidth: 2,
                    pointRadius: 4,
                    pointHitRadius: 10,
                    data: [65, 59, 80, 81, 56, 55, 40, 60, 55, 30, 78],
                }, {
                    label: "Tilapia 2",
                    fill: true,
                    lineTension: 0.1,
                    backgroundColor: `rgba(${ph_level_color}, 0.4)`,
                    borderColor: `rgb(${ph_level_color})`,
                    borderWidth: 2,
                    borderCapStyle: 'butt',
                    borderJoinStyle: 'miter',
                    pointBorderColor: `rgb(${ph_level_color})`,
                    pointBackgroundColor: `rgb(${ph_level_color})`,
                    pointBorderWidth: 1,
                    pointHoverRadius: 8,
                    pointHoverBackgroundColor: ph_level_color,
                    pointHoverBorderColor: ph_level_color,
                    pointHoverBorderWidth: 2,
                    pointRadius: 4,
                    pointHitRadius: 10,
                    data: [10, 20, 60, 95, 64, 78, 90, 70, 40, 70, 89],
                }, {
                    label: "Tilapia 3",
                    fill: true,
                    lineTension: 0.1,
                    backgroundColor: "rgba(0,0,0,0.4)",
                    borderColor: "#180000",
                    borderWidth: 2,
                    borderCapStyle: 'butt',
                    borderDash: [],
                    borderDashOffset: 0.0,
                    borderJoinStyle: 'miter',
                    pointBorderColor: "white",
                    pointBackgroundColor: "black",
                    pointBorderWidth: 1,
                    pointHoverRadius: 8,
                    pointHoverBackgroundColor: "black",
                    pointHoverBorderColor: "black",
                    pointHoverBorderWidth: 2,
                    pointRadius: 4,
                    pointHitRadius: 10,
                    data: [89, 70, 60, 45, 30, 22, 45, 50, 70, 70, 90],
                }

                ]
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        },
                        scaleLabel: {
                            display: true,
                            labelString: 'Products Health',
                            fontSize: 16
                        }
                    }],
                    xAxes: [{
                        scaleLabel: {
                            display: true,
                            labelString: 'Date',
                            fontSize: 16
                        }
                    }]
                }
            }
        });
    }

    upDateEnv(value, env_to_update) {
        this.props.upDateEnv(value, env_to_update)
    }

    render() {
        return (
            <div className="tank-component">

                <div className="heading">Tank Details</div>
                <div className="single-tank-details">
                    <div className="products-in-tank">

                        <div className="product-wrapper">
                            <div className="tank-item">
                                <div className='title'>{this.props.tanks[this.props.selected_tank].name}</div>
                            </div>
                            <div className="product-details">
                                <div className="title"><span><i
                                    className="material-icons">shopping_basket</i>&nbsp; Market</span> | Price <input
                                    type="text" placeholder='R10'/> +
                                    units/ <input type="text" placeholder='kg'/></div>

                                <hr/>

                                <div className="title"><span><i
                                    className="material-icons">favorite</i>&nbsp; Life Stage</span> | <input
                                    type="text" placeholder='Fingerling' style={{width: '150px'}}/></div>

                                <div className="title"><span><i
                                    className="material-icons">line_weight</i>&nbsp; Weight </span> | <input
                                    type="text" placeholder='1kg' style={{width: '150px'}}/></div>

                                <hr/>

                                <div className="title" style={{flexDirection: 'column', alignItems: 'flex-start'}}>
                                    <span><i
                                        className="material-icons">nature</i>&nbsp; Environment</span>
                                    <br/>
                                    <div className="invironement-list">
                                        <div className="invironement-item">
                                            <label htmlFor="ph">
                                                <i className="material-icons">opacity</i>&nbsp;PH
                                            </label>
                                            <input type="number" placeholder='PH' defaultValue={this.props.ph_value}
                                                   onChange={(e) => this.upDateEnv(e.target.value, 'ph_value')}/>
                                            <div className="invironement-item-scale">
                                                <div className={this.props.ph_value < 7 ? 'active' : ''}/>
                                                <div
                                                    className={this.props.ph_value >= 7 && this.props.ph_value <= 9 ? 'active' : ''}/>
                                                <div className={this.props.ph_value > 9 ? 'active' : ''}/>
                                            </div>
                                        </div>
                                    </div>

                                    <div className="invironement-list">
                                        <div className="invironement-item">
                                            <label htmlFor="ph">
                                                <i className="material-icons">opacity</i>&nbsp;NH3
                                            </label>
                                            <input type="number" placeholder='NH3' defaultValue={this.props.nh3_value}
                                                   onChange={(e) => this.upDateEnv(e.target.value, 'nh3_value')}/>
                                            <div className="invironement-item-scale">
                                                <div className={this.props.nh3_value < .1 ? 'active' : ''}/>
                                                <div
                                                    className={this.props.nh3_value >= .1 && this.props.nh3_value <= 7.1 ? 'active' : ''}/>
                                                <div className={this.props.nh3_value > 7.1 ? 'active' : ''}/>
                                            </div>
                                        </div>
                                    </div>

                                    <div className="invironement-list">
                                        <div className="invironement-item">
                                            <label htmlFor="ph">
                                                <i className="material-icons">opacity</i>&nbsp;O<sup>2</sup>
                                            </label>
                                            <input type="number" placeholder='O2' defaultValue={this.props.o2_value}
                                                   onChange={(e) => this.upDateEnv(e.target.value, 'o2_value')}/>
                                            <div className="invironement-item-scale">
                                                <div className={this.props.o2_value < 7 ? 'active' : ''}/>
                                                <div
                                                    className={this.props.o2_value >= 7 && this.props.o2_value <= 100 ? 'active' : ''}/>
                                                <div className={this.props.o2_value > 100 ? 'active' : ''}/>
                                            </div>
                                        </div>
                                    </div>

                                    <div className="invironement-list">
                                        <div className="invironement-item">
                                            <label htmlFor="ph">
                                                <i className="material-icons">opacity</i>&nbsp;<sup>o</sup>C
                                            </label>
                                            <input type="number" placeholder='OC'
                                                   defaultValue={this.props.temperature_value}
                                                   onChange={(e) => this.upDateEnv(e.target.value, 'temperature_value')}/>
                                            <div className="invironement-item-scale">
                                                <div className={this.props.temperature_value < 21 ? 'active' : ''}/>
                                                <div
                                                    className={this.props.temperature_value >= 21 && this.props.temperature_value <= 29 ? 'active' : ''}/>
                                                <div className={this.props.temperature_value > 29 ? 'active' : ''}/>
                                            </div>
                                        </div>
                                    </div>

                                    <div className="invironement-list">
                                        <div className="invironement-item">
                                            <label htmlFor="ph">
                                                <i className="material-icons">opacity</i>&nbsp;k
                                            </label>
                                            <input type="number" placeholder='k'
                                                   defaultValue={this.props.conductivity_value}
                                                   onChange={(e) => this.upDateEnv(e.target.value, 'conductivity_value')}/>
                                            <div className="invironement-item-scale">
                                                <div className={this.props.conductivity_value < 35 ? 'active' : ''}/>
                                                <div
                                                    className={this.props.conductivity_value >= 35 && this.props.conductivity_value <= 87 ? 'active' : ''}/>
                                                <div className={this.props.conductivity_value > 87 ? 'active' : ''}/>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <hr/>

                                <div className="title" style={{flexDirection: 'column', alignItems: 'flex-start'}}>
                                    <span><i
                                        className="material-icons">restaurant_menu</i>&nbsp; Nutrition</span>
                                    <br/>

                                    <ol>
                                        {_.map(this.props.nutrition, (item, index) => (
                                            <li key={index}>{item.name} | {item.quantity} | {item.time}</li>
                                        ))}
                                    </ol>

                                    <div className="button-group"
                                         style={{display: 'flex', justifyContent: 'space-between', width: '100%'}}>
                                        <RaisedButton
                                            label="Discover"
                                            labelPosition="before"
                                            primary={true}
                                            icon={<Search/>}
                                            style={{backgroundColor: '#004080', color: '#fff'}}
                                        />

                                        <RaisedButton
                                            label="Save"
                                            labelPosition="before"
                                            primary={true}
                                            icon={<Save/>}
                                            style={{backgroundColor: '#004080', color: '#fff'}}
                                        />
                                    </div>
                                </div>

                            </div>
                        </div>

                        <hr/>

                    </div>
                    <div className="tank-health-chart">
                        <canvas id="tank-health-chart" width="600" height="300"/>
                        <br/>
                        <hr/>
                        <br/>
                        <canvas id="tank-health-chart2" width="600" height="300"/>
                    </div>
                </div>
            </div>
        )
    }
}