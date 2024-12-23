database=[
    {
        id:1,
        name:"lek. med. Błażej Przybysławski",
        spec:"Pediatra",
        available:true,
        src:"bp"
    },
    {
        id:2,
        name:"lek. Jakub Jonkisz",
        spec:"Pediatra",
        available:true,
        src:"jj"
    },
    {
        id:3,
        name:"proktolog Mateusz Szmit",
        spec:"Lekarz rodzinny",
        available:false
    },
    {
        id:4,
        name:"lek. med. Zbigniew Wójcicki",
        spec:"Lekarz rodzinny",
        available:true,
        src:"zw"
    }
]
daty=[]
wybrane = "Wizyta kontrolna"
godzina = ""
niebieskie = ""
window.onload = function(){
    document.getElementById("notchosen").style.display="none"
    //console.log(document.cookie.split(";"))
    var info=(document.cookie.split(";")[1]).split("=")[1].split("")[1]
    //console.log(info)  
    document.getElementsByClassName("photo")[0].setAttribute("src","lib/"+database[info-1].src+".jpg") 
    document.getElementById("profesja").innerHTML=database[info-1].spec
    document.getElementById("imie").innerHTML=database[info-1].name

    for(var b=0;b<160;b++){
        c = Math.floor(Math.random() * (10));
        if(c%2==0){
            daty[b]=true
        }
        else{
            daty[b]=false
        }
    }
    /*
    for(var a=0;a<160;a++){
        var box=document.createElement("div")
        box.classList.add("date_box")
        if(database.zw.dates[a]){
            box.style.backgroundColor = "green"
        }
        else{
            box.style.backgroundColor = "red"
        }
        document.getElementsByClassName("available_dates_box")[0].appendChild(box)
    }
    */
    var selekt = ""
    for(var a=0;a<40;a++){
        var bigbox=document.createElement("div")
        bigbox.classList.add("date_bigbox")
        for(var b=0;b<4;b++){
            var box=document.createElement("div")
            box.classList.add("date_box")
            box.setAttribute('id',"box_"+(a*4+b))
            if(daty[a*4+b]){
                box.style.backgroundColor = "green"
                var minuty = 0
                switch (b){
                    case 0:
                        minuty = "00";
                        break;
                    case 1:
                        minuty = 15;
                        break;
                    case 2:
                        minuty = 30;
                        break;
                    case 3:
                        minuty = 45;
                        break;
                }
                var godziny = 10;
                var val1 = 0;
                val1 = a%8;
                godziny = godziny + val1;

                var dzien = 0
                var val2 = 0
                val2 = Math.floor((a*4+b)/32)
                switch (val2){
                    case 0:
                        dzien = 21;
                        break;
                    case 1:
                        dzien = 22;
                        break;
                    case 2:
                        dzien = 23;
                        break;
                    case 3:
                        dzien = 24;
                        break;
                    case 4:
                        dzien = 25;
                        break;
                }
                selekt = selekt + "<option id=option_"+(a*4+b) +" value='Czerwiec "+ dzien + " " + godziny + ":"+minuty +"'>"  + "Czerwiec " + dzien + " " + godziny + ":"+minuty + "</option>"
            }
            else{
                box.style.backgroundColor = "red"
            }
            bigbox.appendChild(box)
        }
        document.getElementsByClassName("available_dates_box")[0].appendChild(bigbox)
    }
    document.getElementById("selekt").innerHTML += selekt;
    document.getElementById('selekt').addEventListener('change', function(e) {
        var aaa = e.target.options[e.target.selectedIndex].getAttribute('id')
        if(niebieskie!=""){
            document.getElementById(niebieskie).style.backgroundColor="green"
        }
        var bbb = aaa.split("_")[1]
        console.log(bbb)
        var ccc = "box_"+bbb
        niebieskie = ccc
        document.getElementById(niebieskie).style.backgroundColor="blue"
    });

    document.getElementsByClassName("rezerwacja")[0].onclick = function(){
        //console.log(wybrane)
        //console.log(document.getElementById("selekt").value)
        //console.log(document.cookie.split(";")[1].split("=")[1])
        if(document.getElementById("selekt").value!=""){
            document.cookie = "cel="+wybrane
            document.cookie = "data=" + document.getElementById("selekt").value
            location.href="./confirm.html";
        }
        else{
            document.getElementById("notchosen").style.display="flex"
        }
    }
}
function funkcja(a){
    wybrane = a.value
}

//document.cookie = "cookiename= ; expires = Thu, 01 Jan 1970 00:00:00 GMT"