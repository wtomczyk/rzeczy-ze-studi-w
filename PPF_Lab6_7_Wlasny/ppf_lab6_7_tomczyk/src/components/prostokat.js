import React, {Component} from "react";
import './prostokat.css'
class Prostokat extends Component {
    constructor(){
        super()
        this.state={r:255,g:255,b:0}
    }
    mousedown = () =>{
        this.setState({r:0,g:255,b:255})
    }
    mouseleave = () =>{
        this.setState({r:255,g:255,b:0})
    }
    mouseenter = () =>{
        this.setState({r:255,g:0,b:255})
    }
    mousemove = () =>{
        if(this.state.r>0){
            this.setState({r:this.state.r-1})
        }
        if(this.state.b>0){
            this.setState({b:this.state.b-1})
        }
        if(this.state.r==0 && this.state.g!=255){
            this.setState({g:this.state.g+1})
        }
    }
    mouseup = () =>{
        this.setState({r:127,g:255,b:127})
    }
    render(){
        return(
            <div id="box">
                <h1>Prostokąt ze zdarzeniami: onMouseDown, onMouseLeave, onMouseEnter, onMouseMove i onMouseUp
                </h1>
                <div id="div">
                   <div id="prostokat"
                        onMouseDown={this.mousedown}
                        onMouseLeave={this.mouseleave}
                        onMouseEnter={this.mouseenter}
                        onMouseMove={this.mousemove}
                        onMouseUp={this.mouseup}
                    style={{backgroundColor:"rgb("+this.state.r+","+this.state.g+","+this.state.b+")"}} >
                    </div> 
                </div>
            </div>
        )
    }
}
export default Prostokat