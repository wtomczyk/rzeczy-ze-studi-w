import React, {Component} from "react";
import './a1.css'
import A2 from "./a2";

class A1 extends Component{
    constructor(props) {
        super(props);
        this.state = {a:0,b:0};
    }
    componentDidMount() {
        this.setState({true:true})
        this.interval = setInterval(() =>{
                if(this.state.a<196 && this.state.b == 0){
                    this.setState({a:(this.state.a+1)})
                }
                else if(this.state.a>=196 && this.state.b <=196){
                    this.setState({b:(this.state.b+1)})
                }
                else if(this.state.a>=0 && this.state.b >=196){
                    this.setState({a:(this.state.a-1)})
                }
                else{
                    this.setState({b:(this.state.b-1)})
                }
        }, 5);
      }
    render(){
        return(
            <div id='abox'>
            <div id="div1">
            <A2 a={this.state.a} b={this.state.b} />
            </div>
            </div>
        )
    }
}
export default A1

