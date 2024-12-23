import React, {Component} from "react";
import './Glowna.css'
import Header from "./Header";
import Nav from "./Nav";
import { Home } from "./Home";
import MainPage from "./MainPage";
import { LastPage } from "./LastPage";

export default class Body extends Component{
    constructor(props){
        super(props)
        this.state={
            st:1
        }
    }
    /*
    stateChange1 = () =>{
        this.setState({st:1})
        console.log("1")
    }
    stateChange2 = () =>{
        this.setState({st:2})
        console.log("2")
    }
    stateChange3 = () =>{
        this.setState({st:3})
        console.log("3")
    }*/
    render(){
        return(
            <div id="bodyBox">
                <Header/>
                <Nav/>
                <MainPage/>
            </div>
        )
    }
}