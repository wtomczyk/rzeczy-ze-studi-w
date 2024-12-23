import React, {Component} from "react";
import './Media.css'
import film from '../res/cta.mp4'
class Media extends Component {
    constructor(){
        super()
        this.state={tekst:""}
    }
    oncanplay = () =>{
        this.setState({tekst:"film jest gotowy do odpalenia"})
    }
    onpause = () =>{
        this.setState({tekst:"zapauzowania filmu"})
    }
    onplay = () =>{
        this.setState({tekst:"rozpoczęcia/wznowienia filmu"})
    }
    onvolumechange = () =>{
        this.setState({tekst:"zmiany głośności filmu"})
    }
    onended = () =>{
        this.setState({tekst:"film się skończył"})
    }
    //wiem, że w instrukcji było napisane, aby nie dodawać filmu do plików bo rozmiar, dlatego też wybrałem taki, co waży praktycznie nic
    render(){
        return(
            <div id="box">
                <h1>Media ze zdarzeniami: onCanPlay, onPause, onPlay, onVolumeChange, onEnded
                </h1>
                <div id="div">
                <video 
                onCanPlay={this.oncanplay}
                onPause={this.onpause}
                onPlay={this.onplay}
                onVolumeChange={this.onvolumechange}
                onEnded={this.onended}
                controls>
                    <source src={film} type="video/mp4" />
                </video> 
                <h2>Dokonano: {this.state.tekst}</h2>
                </div>

            </div>
        )
    }
}
export default Media