import React, {Component} from "react";
import './Header.css'
import logo from '../res/logo.png'
class Header extends Component{
    render(){
        return(
            <div id="header">
                <a href="/"><img src={logo} id="logoImg"></img></a>
            </div>
        )
    }
}
export default Header