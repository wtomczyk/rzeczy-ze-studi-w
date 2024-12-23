import React, {Component} from "react";
import './a3.css'
import A4 from "./a4";
class A3 extends Component{
    constructor(props) {
        super(props);
        this.state = {a:0,b:0};
    }
    stateChange = () =>{
        this.setState({a:(this.state.a+0.01)})
    }
    componentDidMount() {
        this.interval = setInterval(() =>{
                if(document.getElementById("div3")==undefined){
                    clearInterval(this.interval)
                }
                if(this.state.a<46 && this.state.b == 0){
                    this.setState({a:(this.state.a+1)})
                }
                else if(this.state.a>=46 && this.state.b <=46){
                    this.setState({b:(this.state.b+1)})
                }
                else if(this.state.a>=0 && this.state.b >=46){
                    this.setState({a:(this.state.a-1)})
                }
                else{
                    this.setState({b:(this.state.b-1)})
                }
                document.getElementById("div3").style.top=this.props.a+'px'
                document.getElementById("div3").style.left=this.props.b+'px'
        }, 5);
      }
    render(){
        return(
            <div id="div3">
            <A4 a={this.state.a} b={this.state.b}/>
            </div>
        )
    }
}
export default A3