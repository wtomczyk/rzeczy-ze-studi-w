import csv
import random
tab = []
name = 'alefajnatabeleczka.csv'

tab.append(['years','patents','projects','technologies','learning','halfYears','training','education','groupWork','english','overtime','seniority'])

# row[0] - ile masz lat doświadczenia (0 - 5+) * 0,33 - years
# row[1] - opatentowane rozwiązania (0 - 5+) * 0,08 - patents
# row[2] - ile masz wykonanych projektów (0 - 10+) * 0,12 - projects
# row[3] - ile znasz technologii (0-15+) * 0,11 - technologies
# row[4] - jak szybko przyswajasz nową wiedzę (bardzo powoli, powoli, średnio, szybko, bardzo szybko) * 0,08 - learning
# row[5] - w ilu miejscach pracowałeś dłużej niż pół roku (0-10+) * 0,09 - halfYears
# row[6] - udział w szkoleniach (0-10+) * 0,06 - training
# row[7] - jakie masz wykształcenie (Gimnazjum, srednie, inżynier/licencjat, magister, doktor, profesor) * 0,05 - education
# row[8] - jak dobrze pracujesz w grupie (bardzo źle, źle, średnio, dobrze, bardzo dobrze) * 0,04 - groupWork
# row[9] - w jakim stopniu znasz angielski (b2, c1, c2) * 0,03 - english
# row[10] - ilość nadgodzin w miesiącu (0-40+) * 0,01 - overtime
# row[11] - seniority - do obliczenia - seniority

for i in range(2000):
    row = [0.,0.,0.,0.,0.,0.,0.,0.,0.,0.,0.,0]
    maxVal = [5,5,10,15,4,10,10,5,4,2,40]
    #wartości które mogą być kompletnie losowe
    row[4] = random.randint(0, 4)
    row[7] = random.randint(0, 5) #na podstawie wykształcenia będą określane niektóre inne wartości
    row[8] = random.randint(0, 4)
    row[9] = random.randint(0, 2)
    row[10] = random.randint(0, 40)

    row[0] = random.randint(-2,1) + row[7]
    if row[0] < 0:
        row[0] = 0
    if row[0] > 5:
        row[0] = 5

    row[6] = (row[7]-2)*2+random.randint(1,7)
    if row[6] < 0:
        row[6] = 0
    if row[6] > 10:
        row[6] = 10

    row[5] = random.randint(row[0],2*row[0])-1
    if row[5] < 0:
        row[5] = 0

    row[1] = 0
    if row[7] > 2:
        row[1] = (row[7]-3)*2 + random.randint(-3,2)
        if row[1] < 0:
            row[1] = 0
        if row[1] > 5:
            row[1] = 5

    row[2] = (row[7]-1)*2 + random.randint(-2,7)
    if row[2] < 0:
        row[2] = 0
    if row[2] > 10:
        row[2] = 10

    row[3] = (row[7]-2)*random.randint(1,5)+random.randint(0,5)
    if row[3] < 0:
        row[3] = 0
    if row[3] > 15:
        row[3] = 15

    counter = 0
    for i in row:
        if i != 0:
            row[counter] = round(1/maxVal[counter]*i,3)
        counter = counter + 1
    row[11] = round(row[0]*0.33+row[1]*0.08+row[2]*0.12+row[3]*0.11+row[4]*0.08+row[5]*0.09+row[6]*0.06+row[7]*0.05+row[8]*0.04+row[9]*0.03+row[10]*0.01,3)
    tab.append(row)
for i in tab:
    print(i)
with open(name, 'w', newline='') as plik_csv:
    writer = csv.writer(plik_csv)
    writer.writerows(tab)