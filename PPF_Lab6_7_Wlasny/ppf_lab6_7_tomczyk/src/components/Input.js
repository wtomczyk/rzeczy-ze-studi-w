import React, {Component} from "react";
import './Input.css'
class Input extends Component {
    constructor(){
        super()
        this.state={tekst:"",value:"tekst w inpucie"}
        this.zmiana = this.zmiana.bind(this)
    }
    zmiana(event){
        this.setState({value:event.target.value})
    }


    oncopy = () =>{
        this.setState({tekst:"skopiowania tekstu"})
    }
    onkeypress = () =>{
        this.setState({tekst:"wpisania tekstu"})
    }
    onfocus = () =>{
        this.setState({tekst:"sfocusowania się na inpucie"})
    }
    onblur = () =>{
        this.setState({tekst:"odfocusowania się od inputu (blur)"})
    }
    oncut = () =>{
        this.setState({tekst:"wycięcia tekstu (wytnij, nie usuń)"})
    }

    render(){
        return(
            <div id="box">
                <h1>Input ze zdarzeniami: onCopy, onKeyPress, onFocus, onBlur, onCut
                </h1>
                <div id="div">
                <input
                onCopy={this.oncopy}
                onKeyPress={this.onkeypress}
                onFocus={this.onfocus}
                onBlur={this.onblur}
                onCut={this.oncut}

                value={this.state.value} onChange={this.zmiana}
                id="input" type="text"/>
                <h2>Dokonano: {this.state.tekst}</h2>
                </div>

            </div>
        )
    }
}
export default Input