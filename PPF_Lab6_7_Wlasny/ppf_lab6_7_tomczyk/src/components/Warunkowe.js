import React, {Component} from "react";
import './Warunkowe.css'
import Warunek1 from "./warunek1";
import Warunek2 from "./warunek2";
class Warunkowe extends Component{
    constructor(props) {
        super(props);
        this.state = {true:true};
    }
    stateChange = () =>{
        if(this.state.true){
            this.setState({true:false})
        }
        else{
            this.setState({true:true})
        }
    }
    render(){
        return(
            <div>
               <h1 id="warunekh1">Warunkowe ładowanie komponentów</h1>
                <button id="button" onClick={this.stateChange}>
                    Naciśnij, aby zmienić komponent poniżej
                </button>
                {this.state.true ? <Warunek1/> : <Warunek2/>}
            </div>
        )
    }
}
export default Warunkowe