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
window.onload = function(){
    //document.cookie = "id= ; expires = Thu, 01 Jan 1970 00:00:00 GMT"
    //document.cookie = "cel= ; expires = Thu, 01 Jan 1970 00:00:00 GMT"
    //document.cookie = "data= ; expires = Thu, 01 Jan 1970 00:00:00 GMT"
    for(var a=0;a<4;a++){
        document.getElementsByClassName("medic_button")[a].onclick = function(b){
            var lekarz = b.target.id.slice(1)
            if(database[lekarz].available){
                document.cookie = "id=a" + database[lekarz].id
                console.log(document.cookie)
                location.href="./date.html";
            }
        }
    }
}

