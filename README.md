# Grupp7-Cirkus
Projektarbete Grupp 7
Mittuniversitetet
Avdelningen för data- och systemvetenskap
IK102G, Datamodellering och Databaser, 7,5 HP
VT-17
Uppgift 8 – programmera mot databas – cirkus kul och bus
Cirkusdirektören har efter nogsamt övervägande kommit fram till att man vill skapa ett
datorbaserat informationssystem till cirkusskolan.
Det system som ska tas fram ska vara moduluppbyggt, och därmed kunna utvecklas och växa.
Den första modul som ni ska realisera ska hantera närvarorapportering.
Närvarorapportering
Cirkus kul och bus har aktiviteter/träningsgrupper med ett antal deltagare. I samband med varje
träningspass ska ledaren för aktiviteten registrera närvaron på samtliga personer. Om ett barn
bara kan vara med på en del av träningen räknas man ändå som närvarande.
Medlemsregister med barn och ledare
För att det ska gå att registrera närvaro måste det finnas medlemmar i systemet. Som
administratör ska man kunna lägga till, ändra och ta bort medlemmar och ledare.
Närvarolistor
Cirkusens administratör ska kunna ta fram listor över den inregistrerade närvaron. Alla utskrifter
ska synas på skärmen. Om ni vill glänsa kan ni även lägga till funktioner för utskrift, men detta är
inget krav.
Administratören ska kunna välja lite olika parametrar för utsökningen av närvaron. Extra bonus
för om ert system klarar av att hantera parametrarna i kombinationer.
1. Datumintervall
2. En, eller flera, specifika träningsgrupper
3. Alla träningsgrupper som en specifik ledare har
Utskrifterna ska innehålla följande uppgifter
1. Datum och klockslag för varje träningstillfälle
2. Vilken aktivitet man har genomfört (matas in av respektive ledare). Aktiviteten kan vara
samma, eller varias, för varje tillfälle
3. Vilka medlemmar/barn som var med vid respektive tillfälle samt deras födelsedata
år/månad/dag
4. Namnen på ledarna
5. Summering av antalet medlemmar vid varje träningstillfälle
6. Summering av totala antalet träningstillfällen på aktiviteten under perioden
Nedan ser du hur den befintliga närvarorapporten ser ut. Den som ert system tar fram behöver
inte följa samma grafiska utseende.
Tekniska förutsättningar
Programmet kommer att köras på en pc med Windows 7 installerat. Pc:n kommer att ha tillgång
till en databasserver med databashanteraren PostgreSQL installerad.
Förutsättningar för att genomföra uppgiften
Uppgiften genomförs i grupper om 3. Uppgiften redovisas skriftligt. Följande dokumentation ska
lämnas in och utgör den skriftliga redovisningen:
1. Källkoden som utgör själva Windowsprogrammet.
2. Databasbackup med data
3. Ett dokument som kortfattat beskriver hur ni inom gruppen arbetat med att lösa
uppgiften, samt en kort beskrivning över vem som har gjort vad.
.
