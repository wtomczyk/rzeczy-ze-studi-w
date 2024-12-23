import React from "react";
import './LastPage.css'
import LadowanieObrazow from "./LadowanieObrazow";
import { Film } from "./Film";
import A1 from "./a1";
import Warunkowe from "./Warunkowe";
import Formularz from "./Formularz";
export const LastPage = (props) =>{
    return(
        <div>
            <h1>Witaj na stronie trzeciej</h1>
            <LadowanieObrazow/>
            <Film/>
            <h1>Komponent zawierający komponent zawierający komponent zawierający komponent</h1>
            <A1/>
            <Warunkowe/>
            <Formularz/>
        </div>
    ) 
}
