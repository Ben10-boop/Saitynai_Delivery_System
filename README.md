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

## Naudotojo sąsajos projektas

#### Prisijungimas

![Prisijungimo wireframe](https://cdn.discordapp.com/attachments/890247339648909322/1054323023911604325/image.png "Prisijungimo wireframe")

![Prisijungimo langas](https://cdn.discordapp.com/attachments/890247339648909322/1054323512724181012/image.png "Prisijungimo langas")

#### Registracija

![Registracijos wireframe](https://cdn.discordapp.com/attachments/890247339648909322/1054324145518809088/image.png "Registracijos wireframe")

![Registracijos langas](https://cdn.discordapp.com/attachments/890247339648909322/1054323763526770748/image.png "Registracijos langas")

#### Namų langas

![Namų lango wireframe](https://cdn.discordapp.com/attachments/890247339648909322/1054324801931591720/image.png "Namų lango wireframe")

![Namų langas](https://cdn.discordapp.com/attachments/890247339648909322/1054325168220164146/image.png "Namų langas")

#### Siuntų sąrašas

![Siuntų sąrašo wireframe](https://cdn.discordapp.com/attachments/890247339648909322/1054325675642859550/image.png "Siuntų sąrašo wireframe")

![Siuntų sąrašo langas](https://cdn.discordapp.com/attachments/890247339648909322/1054326025351340093/image.png "Siuntų sąrašo langas")

#### Siuntos pridėjimas

![Siuntos pridėjimo wireframe](https://cdn.discordapp.com/attachments/890247339648909322/1054326499920060426/image.png "Siuntos pridėjimo wireframe")

![Siuntos pridėjimo langas](https://cdn.discordapp.com/attachments/890247339648909322/1054326799921848400/image.png "Siuntos pridėjimo langas")

#### Siuntos redagavimas

![Siuntos redagavimo wireframe](https://cdn.discordapp.com/attachments/890247339648909322/1054327697595170876/image.png "Siuntos redagavimo wireframe")

![Siuntos redagavimo langas](https://cdn.discordapp.com/attachments/890247339648909322/1054328021743575080/image.png "Siuntos redagavimao langas")

#### Siuntos paieška

![Siuntos paieškos wireframe](https://cdn.discordapp.com/attachments/890247339648909322/1054333359930753024/image.png "Siuntos paieškos wireframe")

![Siuntos paieškos langas](https://cdn.discordapp.com/attachments/890247339648909322/1054333450691280946/image.png "Siuntos paieškos langas")

#### Pristatymų sąrašas

![Pristatymų sąrašo wireframe](https://cdn.discordapp.com/attachments/890247339648909322/1054328426896564255/image.png "Pristatymų sąrašo wireframe")

![Pristatymų sąrašo langas](https://cdn.discordapp.com/attachments/890247339648909322/1054328587777474630/image.png "Pristatymų sąrašo langas")

#### Pristatytmo pridėjimas

![Pristatytmo pridėjimo wireframe](https://cdn.discordapp.com/attachments/890247339648909322/1054328970935545877/image.png "Pristatytmo pridėjimo wireframe")

![Pristatytmo pridėjimo langas](https://cdn.discordapp.com/attachments/890247339648909322/1054329066905403432/image.png "Pristatytmo pridėjimo langas")

#### Pristatymo redagavimas

![Pristatymo redagavimo wireframe](https://cdn.discordapp.com/attachments/890247339648909322/1054330921123319878/image.png "Pristatymo redagavimo wireframe")

![Pristatymo redagavimo langas](https://cdn.discordapp.com/attachments/890247339648909322/1054331045039841300/image.png "Pristatymo redagavimo langas")

#### Automobilių sąrašas

![Automobilių sąrašo wireframe](https://cdn.discordapp.com/attachments/890247339648909322/1054331469864128572/image.png "Automobilių sąrašo wireframe")

![Automobilių sąrašo langas](https://cdn.discordapp.com/attachments/890247339648909322/1054331556979806248/image.png "Automobilių sąrašo langas")

#### Automobilio pridėjimas

![Automobilio pridėjimo wireframe](https://cdn.discordapp.com/attachments/890247339648909322/1054331891702059018/image.png "Automobilio pridėjimo wireframe")

![Automobilio pridėjimo langas](https://cdn.discordapp.com/attachments/890247339648909322/1054331952972451850/image.png "Automobilio pridėjimo langas")

#### Automobilio redagavimas

![Automobilio redagavimo wireframe](https://cdn.discordapp.com/attachments/890247339648909322/1054332731032600586/image.png "Automobilio redagavimo wireframe")

![Automobilio redagavimo langas](https://cdn.discordapp.com/attachments/890247339648909322/1054332935970488360/image.png "Automobilio redagavimo langas")

## API specifikacija

### Auth

#### \[Post\] /api/Auth/Register

##### Parameters

| Name | Type | Description |
| --- | --- | --- |
| email | string | User's email address |
| password | string | User's password |

##### Response fields

| Name | Type | Description |
| --- | --- | --- |
| - | string | Rseult description |

##### Possible response codes

200, 400

##### Usage example

Request

```
{
  "email": "user@example.com",
  "password": "stringstr"
}
```

Response

```
Registered successfully
```

#### \[Post\] /api/Auth/Login
