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
//document.cookie = "cookiename= ; expires = Thu, 01 Jan 1970 00:00:00 GMT"
window.onload = function(){
    var info=(document.cookie.split(";")[1]).split("=")[1].split("")[1]
    var wizyta = (document.cookie.split(";")[2]).split("=")[1]
    var data = (document.cookie.split(";")[3]).split("=")[1]
    console.log(info + " " + wizyta + " " + data)
    document.getElementsByClassName("photo")[0].setAttribute("src","lib/"+database[info-1].src+".jpg") 
    document.getElementById("profesja").innerHTML=database[info-1].spec
    document.getElementById("imie").innerHTML=database[info-1].name
    document.getElementById("data").innerHTML = "Data wizyty: "+ data.split(" ")[0] + " " + data.split(" ")[1] + " 2021 " + data.split(" ")[2]
    document.getElementById("cel").innerHTML = "Cel wizyty: " + wizyta
    var cena
    switch(wizyta){
        case "Wizyta kontrolna":
            cena = "20zł"
            break
        case "Konsultacja":
            cena = "40zł"
            break
        case "Choroba":
            cena = "100 - 300zł"
            break
        case "Wypisanie recepty":
            cena = "45zł"
            break
        case "Szczepienie":
            cena = "140zł"
            break
    }
    document.getElementById("cena").innerHTML = "Cena: " + cena

    document.getElementsByClassName("no")[0].onclick = function(){
        document.cookie = "id= ; expires = Thu, 01 Jan 1970 00:00:00 GMT"
        document.cookie = "cel= ; expires = Thu, 01 Jan 1970 00:00:00 GMT"
        document.cookie = "data= ; expires = Thu, 01 Jan 1970 00:00:00 GMT"
        location.href="./index.html";
    }
}
