import React, {Component} from "react";
import './Nav.css'
class Nav extends Component{
    render(){
        var aaa = this.props
        return(
            <div id="nav">
                <a href="/Home"><div id="button1" className="button">
                    Strona Home
                </div></a>
                <a href="/Glowna"><div id="button2" className="button">
                    Strona Główna
                </div></a>
                <a href="/Trzecia"><div id="button3" className="button">
                    Strona Trzecia
                </div></a>
            </div>
        )
    }
}
export default Nav