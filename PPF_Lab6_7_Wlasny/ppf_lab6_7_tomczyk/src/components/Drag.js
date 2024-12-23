import React, {Component} from "react";
import './Drag.css'
class Drag extends Component {
    constructor(){
        super()
        this.state={tekst:""}
        this.dragging = this.dragging.bind(this)
        this.drop = this.drop.bind(this)
    }

    dragStart(event){
        event.dataTransfer.setData("Text", event.target.id);
    }
    dragging(event) {
        this.setState({tekst:"przeciągnięcia elementu"})
    }
    allowDrop(event) {
        event.preventDefault();
    }
    drop(event) {
        event.preventDefault();
        var data = event.dataTransfer.getData("Text");
        event.target.appendChild(document.getElementById(data));
        this.setState({tekst:"upuszczenia elementu"})
    }
    render(){
        return(
            <div className="box" id="ostatniechyba">
                <h1>Boxy ze zdarzeniami: dragStart, dragging, allowDrop, drop
                </h1>
                
                <div id="div">
                <div id="box2">
                    <div className="droptarget" onDrop={this.drop} onDragOver={this.allowDrop}>

                    <p onDragStart={this.dragStart} onDrag={this.dragging} draggable="true" id="dragtarget">Przeciągnij mnie</p>

                    </div>

                    <div className="droptarget" onDrop={this.drop} onDragOver={this.allowDrop}></div>
                </div>
                <h2>Dokonano: {this.state.tekst}</h2>
                </div>

            </div>
        )
    }
}
export default Drag