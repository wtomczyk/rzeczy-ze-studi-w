import csv
import statistics

# row[0] - distance row[1], - total freight cost EUR
# row[2] - total gross kg, row[3] - volume m^3
# row[4] - user,row[5] - disp. date
# row[6] - Csee, row[7] - city
# row[8] - postal code, row[9] - CntryD
# row[10] - type of transport, row[11] - forwarder, row[12] - incotern
path = 'C:/Users/admin/Desktop/baza.csv'

packageVolume = []
users = []
csee = []
cities = []
cntryD = []
transportTypes = []
forwarders = []
incoterns = []
tablica = [packageVolume, users, csee, cities, cntryD, transportTypes, forwarders, incoterns]

# zmienne zad1
cities_vol = []
transportTypes_vol = []
vol_cost = []

with open(path, 'r') as file:
    # wstępne przygotowania tablic do prac
    plik = csv.reader(file)
    for row in plik:
        counter = 0
        licznik = 0
        for val in row:
            if counter in (3, 4, 6, 7, 9, 10, 11, 12):
                if val not in tablica[licznik]:
                    tablica[licznik].append(val)
                licznik = licznik + 1
            counter = counter + 1
# zad1
with open(path, 'r') as file:
    plik = csv.reader(file)
    for row in plik:
        cities_vol.append([float(row[3]), row[7]])
        transportTypes_vol.append([float(row[3]), row[10]])
        vol_cost.append([float(row[3]), float(row[1])])
    for i in cities:
        print("Dla miasta", i, "dane wyglądają tak:")
        tab = []
        vol_tab = []
        for j in cities_vol:
            if j[1] == i:
                tab.append(float(j[0]))
                if j[0] not in vol_tab:
                    vol_tab.append([j[0], 0])
                for l in vol_tab:
                    if l[0] == j[0]:
                        l[1] = l[1] + 1
        print('Minimalna zanotowana wielkość paczki:', min(tab), 'm^3')
        print('Maksymalna zanotowana wielkość paczki:', max(tab), 'm^3')
        print('Średnia zanotowana wielkość paczki:', round(sum(tab) / len(tab), 3), 'm^3')
        print('Mediana zanotowanych wielkości paczek:', round(statistics.median(tab), 3), 'm^3')
        mostCommon = max(vol_tab, key=lambda x: x[1])
        print('Najczęściej występująca wielkość paczek:', mostCommon[0], 'm^3 w ilości', mostCommon[1])
        print(" ")
    for a in transportTypes:
        print("Dla typu transportu", a, "dane wyglądają tak:")
        tab = []
        vol_tab = []
        for b in transportTypes_vol:
            if b[1] == a:
                tab.append(float(b[0]))
                if b[0] not in vol_tab:
                    vol_tab.append([b[0], 0])
                for d in vol_tab:
                    if d[0] == b[0]:
                        d[1] = d[1] + 1
        print('Minimalna zanotowana wielkość paczki:', min(tab), 'm^3')
        print('Maksymalna zanotowana wielkość paczki:', max(tab), 'm^3')
        print('Średnia zanotowana wielkość paczki:', round(sum(tab) / len(tab), 3), 'm^3')
        print('Mediana zanotowanych wielkości paczek:', round(statistics.median(tab), 3), 'm^3')
        mostCommon = max(vol_tab, key=lambda x: x[1])
        print('Najczęściej występująca wielkość paczek:', mostCommon[0], 'm^3 w ilości', mostCommon[1])
        print(" ")
    tab_cost = []
    tab_vol = []
    suma1 = 0
    suma2 = 0
    licznik = 0
    for a in vol_cost:
        tab_cost.append(a[1])
        if a[0] not in tab_vol:
            tab_vol.append([a[0], 0])
        for d in tab_vol:
            if d[0] == a[0]:
                d[1] = d[1] + 1
        suma1 = suma1 + a[0]
        suma2 = suma2 + a[1]
        licznik = licznik + 1
    maxCost = max(tab_cost)
    minCost = min(tab_cost)
    mostCommon = max(tab_vol, key=lambda x: x[1])
    commonPrice = 0
    licznik2 = 0
    for e in vol_cost:
        if e[0] == mostCommon[0]:
            commonPrice = commonPrice + e[1]
            licznik2 = licznik2 + 1
    print("Średnia cena wynosi:", round((suma2 / licznik), 2), 'EUR dla paczkek o średniej objętości:',
          round((suma1 / licznik), 2), 'm^3')
    print("Maksymalna cena paczki wyniosła:", maxCost, 'EUR')
    print("Minimalna cena paczki wyniosła:", minCost, 'EUR')
    print('Najczęściej występująca wielkość paczek:', mostCommon[0], 'm^3 w ilości', mostCommon[1],
          'miała średnią cenę', round((commonPrice / licznik2), 2), 'EUR')
    print(" ")
# zad2
with open(path, 'r') as file:
    plik = csv.reader(file)
    tab = [0, 0, 0, 0]
    for row in plik:
        counter = 0
        for i in transportTypes:
            if row[10] == i:
                tab[counter] = tab[counter] + 1
            counter = counter + 1
    max = max(tab)
    indeks = tab.index(max)
    print("Najczęściej wybierany jest rodzaj transportu", transportTypes[indeks], 'w ilości', max)
    print(" ")
# zad3
with open(path, 'r') as file:
    plik = csv.reader(file)
    tabNumbers = []
    tabTransportTypes = []
    tabCntryD = []
    tabCities = []
    tabForwarders = []
    for i in incoterns:
        tabNumbers.append(0)
        tabTransportTypes.append([])
        tabCntryD.append([])
        tabCities.append([])
        tabForwarders.append([])
    for row in plik:
        inc = row[12]
        indeks = incoterns.index(inc)
        tabNumbers[indeks] = tabNumbers[indeks] + 1
        if row[10] not in tabTransportTypes[indeks]:
            tabTransportTypes[indeks].append(row[10])
        if row[9] not in tabCntryD[indeks]:
            tabCntryD[indeks].append(row[9])
        if row[7] not in tabCities[indeks]:
            tabCities[indeks].append(row[7])
        if row[11] not in tabForwarders[indeks]:
            tabForwarders[indeks].append(row[11])
    # print(tabNumbers)
    print(" ")
    print('najpopularniejszym Incotermem jest', incoterns[0], 'o liczbie przesyłek', tabNumbers[0])
    print(" ")
    counter = 0
    for j in incoterns:
        print("Informacje dla incoterna:", incoterns[counter])
        print("Liczba przesyłek:", tabNumbers[counter])
        print('Typy transportów:', tabTransportTypes[counter])
        print('CntryD:', tabCntryD[counter])
        print("Miasta:", tabCities[counter])
        print('Przewoźnicy:', tabForwarders[counter])
        print(" ")
        counter = counter + 1
    # w prezentacji trzeba napisać, że DAP jest najbardziej popularny, bo do największej ilości miast przewozi, ma dużo przewoźników, typy transportu są popularne itd.
# zad4
with open(path, 'r') as file:
    plik = csv.reader(file)
    avrVolCounter = []
    avrVolFor = []
    destinationFor = []
    incotFor = []
    transportTypeFor = []
    for i in forwarders:
        destinationFor.append([])
        avrVolFor.append(0)
        avrVolCounter.append(0)
        incotFor.append([])
        transportTypeFor.append([])
    for row in plik:
        forw = row[11]
        indeks = forwarders.index(forw)
        if row[7] not in destinationFor[indeks]:
            destinationFor[indeks].append(row[7])
        if row[12] not in incotFor[indeks]:
            incotFor[indeks].append(row[12])
        if row[10] not in transportTypeFor[indeks]:
            transportTypeFor[indeks].append(row[10])
        avrVolCounter[indeks] = avrVolCounter[indeks] + 1
        avrVolFor[indeks] = avrVolFor[indeks] + float(row[3])
    counter = 0
    for i in forwarders:
        print('Analiza przewoźnika:', i)
        print('Ilość przesyłek:', round(avrVolCounter[counter], 2))
        print('Całkowita objętość przesyłek:', round(avrVolFor[counter], 2), 'm^3')
        print('Średnia objętość przesyłki:', round(avrVolFor[counter] / avrVolCounter[counter], 2), 'm^3')
        print('Destynacje:', destinationFor[counter])
        print('Incotermy:', incotFor[counter])
        print('Typy transportów:', transportTypeFor[counter])
        print(" ")
        counter = counter + 1
