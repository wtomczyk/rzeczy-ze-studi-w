import React, {Component} from "react";
import './Formularz.css'
class Formularz extends Component{
    constructor(props) {
        super(props);
        this.state = {value:"", tekst:""};
        this.zmiana = this.zmiana.bind(this)
        this.submit = this.submit.bind(this)
    }
    zmiana(event){
        this.setState({value:event.target.value})
    }
    submit(event){
        alert(this.state.value)
        event.preventDefault()
        this.setState({tekst:this.state.value})
    }
    render(){
        return(
            <div>
                <h1>Podaj poniżej tekst do formularza, który wyświetli się w alercie</h1>
                <div className="div">
                <form onSubmit={this.submit}>   

                        <label>
                            Podaj tekst : 
                            <input className="input" id="normalnytekst" type="text" value={this.state.value} onChange={this.zmiana} />        
                        </label>
                        <input className="input" id="wyslij" type="submit" value="Wyślij" />
                    </form>
                    <h3>Ostatnio wyświetlony tekst: {this.state.tekst}</h3>
                </div>
            </div>
        )
    }
}
export default Formularz