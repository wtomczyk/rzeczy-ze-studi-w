import React, {Component} from "react";
import './a4.css'
class A4 extends Component{
    constructor(props) {
        super(props);
        this.state = {a:0,b:0};
    }
    componentDidMount() {
        this.interval = setInterval(() =>{
            if(document.getElementById("div4")==undefined){
                clearInterval(this.interval)
            }
                document.getElementById("div4").style.top=this.props.a+'px'
                document.getElementById("div4").style.left=this.props.b+'px'
        }, 5);
      }
    render(){
        
        return(
            <div id="div4">
               
            </div>
        )
    }
}
export default A4