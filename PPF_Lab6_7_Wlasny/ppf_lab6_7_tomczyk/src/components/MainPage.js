import React, {Component} from "react";
import './MainPage.css'
import Prostokat from "./prostokat";
import Input from "./Input";
import Media from "./Media";
import Drag from "./Drag";
class MainPage extends Component {
    constructor(){
        super()
        this.state={}
    }
    render(){
        return(
            <div>
                <h1>Witaj na stronie głównej, zaprezentowane będą tutaj różne zdarzenia (eventy)</h1>
                <Prostokat/> 
                <Input/>
                <Media/>
                <Drag/>
            </div>
        )
    }
}
export default MainPage