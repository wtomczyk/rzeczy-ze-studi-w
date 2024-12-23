import React, {Component} from "react";
import './a2.css'
import A3 from "./a3";
class A2 extends Component{
    constructor(props) {
        super(props);
        this.state = {a:0,b:0,true:false};
    }
    componentDidMount() {
        this.setState({true:true})
        this.interval = setInterval(() =>{
            if(document.getElementById("div2")==undefined){
                clearInterval(this.interval)
            }
            if(this.state.true){
                if(this.state.a<96 && this.state.b == 0){
                    this.setState({a:(this.state.a+1)})
                }
                else if(this.state.a>=96 && this.state.b <=96){
                    this.setState({b:(this.state.b+1)})
                }
                else if(this.state.a>=0 && this.state.b >=96){
                    this.setState({a:(this.state.a-1)})
                }
                else{
                    this.setState({b:(this.state.b-1)})
                }
                document.getElementById("div2").style.top=this.props.a+'px'
                document.getElementById("div2").style.left=this.props.b+'px'
            }
        }, 5);
      }
    render(){

        return(
            <div id="div2">
            <A3 a={this.state.a} b={this.state.b}/>
            </div>
        )
    }
}
export default A2
