import React, {Component} from "react";
import './LadowanieObrazow.css'
import jsonData from '../res2/text.json'
import jsonData2 from '../res2/text2.json'
class LadowanieObrazow extends Component {
    constructor(){
        super()
        this.state={}
        this.txtData=()=>JSON.parse(JSON.stringify(jsonData))
        this.txtData2=()=>JSON.parse(JSON.stringify(jsonData2))
        const imgContext = require.context('../res2/',false,/\.png$/)
        let img={}
        this.imgs=imgContext.keys().reduce((icons,file)=>{
            const cname = imgContext(file)
            const label = file.slice(2, -4)
            img[label] = cname
            return img 
        },{})
    }
    render(){
        const items=[]
        for(let i=0;i<this.txtData().count;i++){
            let value = this.txtData().text[i]
            items.push(
                <div className="div1">
                    <img className="img" src={this.imgs['img'+(i+1)]} alt=""/>
                    <p className="text1">{value}</p>
                </div>
            ) 
        }
        const tabData = this.txtData2().data;
        const items2 = tabData.map((item)=>(
            <div className="div1" id={`"div${item.id}"`}>
                <img className="img" src={this.imgs[item.img]} alt=""/>
                <p className="text1">{item.text}</p>
            </div>
        ))
        return(
            <div>
                <h1>Obrazy ładowane dynamicznie metodą pierwszą :</h1>
                {items}
                <h1>Obrazy ładowane dynamicznie metodą drugą :</h1>
                {items2}
            </div>
        )
    }
}

export default LadowanieObrazow