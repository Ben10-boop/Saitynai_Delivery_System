# Siuntų pristatymo sistema

Šis projektas skirtas Saityno taikomųjų programų projektavimo modulio užduotims atlikti.

## Sprendžiamo uždavinio aprašymas

### Sistemos paskirtis

Projekto tikslas - pagerinti siuntas pristatinėjančios įmonės darbą, suteikiant galimybę 
administratoriui patogiai valdyti kurjerius, vertinti jų atliktą darbą, be to, suteikti
siuntų gavėjams galimybę sekti savo siuntos būseną.

Administratorius sukuria siuntą. Kurjerio darbas yra siuntą pristatyti, todėl kurjeris
gali keisti su pristatymu susijusius siuntos parametrus, o pristatymo proceso metu
klientas gali peržiūrėti jam skirtos siuntos būseną.

### Funkciniai reikalavimai

#### Registruotas naudotojas **Klientas** gali

- Pateikęs siuntos numerį peržiūrėti jos būseną.

#### Administratoriaus sukurtas naudotojas **Kurjeris** gali

- Sukurti pristatymą (priskirtą sau), jį redaguoti;
- Priskirti savo pristatymui siuntą;
- Keisti sau priskirtos siuntos būseną.

#### Išoriškai pridedamas naudotojas **Administratorius** gali

- valdyti (peržiūrėti, pridėti, redaguoti, šalinti) automobilius;
- valdyti (peržiūrėti, pridėti, redaguoti, šalinti) siuntas;
- valdyti (peržiūrėti, pridėti, redaguoti, šalinti) pristatymus;
- valdyti (peržiūrėti, pridėti, redaguoti, šalinti) kurjerius.

### Sistemos struktūra

Toliau pateikiama sistemos esybių ryšių diagrama. CRUD metodai kuriami Delivery (pristatymas), Package (Siunta),
DeliveryVehicle (Pristatymo automobilis) esybėms.

![Esybių ryšių diagrama](https://cdn.discordapp.com/attachments/890247339648909322/1021432081542287431/unknown.png "Esybių ryšių diagrama")

## Sistemos architektūra

Sistemos sudedamosios dalys:

- Kliento pusė (ang. Front-End) – naudojant React.js;
- Serverio pusė (angl. Back-End) – naudojant C# .NET 6 Web API. Duomenų bazė – MS SQL Server 2019.

Toliau pavaizduota sistemos diegimo diagrama. Sistemos talpinimui naudojamas Azure serveris. Visos sistemos
dalys talpinamos tame pačiame serveryje.

![Sistemos diegimo diagrama](https://cdn.discordapp.com/attachments/890247339648909322/1019520678443094127/Sait_Deployment.png "Sistemos diegimo diagrama")