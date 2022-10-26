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

Toliau pateikiami metodai ir rolės, kurių atstovai gali juos pasiekti

Client - Klientas; Courier - Kurjeris; Admin - Administratorius

#### Siuntų (Package) metodai

- **Get** (Courier; Admin)
- **Get{id}** (Client(Tik pačiam priklausančias); Courier; Admin)
- **Put{id}** (Courier(Laisvas ar pačiam priklausančias); Admin)
- **Post** (Admin)
- **Delete** (Admin)

#### Pristatymų (Delivery) metodai

- **Get** (Courier; Admin)
- **Get{id}** (Courier; Admin)
- **Put{id}** (Courier(Tik pačiam priklausančias); Admin)
- **Post** (Courier; Admin)
- **Delete** (Admin)

#### Pristatymo automobilių (Vehicle) metodai

- **Get** (Courier; Admin)
- **Get{id}** (Courier; Admin)
- **Put{id}** (Admin)
- **Post** (Admin)
- **Delete** (Admin)
- **Get{id}/Packages** (Courier; Admin)

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