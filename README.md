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

Toliau pateikiamas naudotojo sąsajos projektas. Kiekvienam langui pateikiamas to lango wireframe, o po to realizacija.

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

Toliau pateikiama kiekvieno API metodo specifikcija. Jeigu kuri nors aprašo dalis yra praleista, reiškia, jog tos dalies nėra pačioje funkcijoje.

### Auth

#### \[POST\] /api/Auth/Register

##### Parametrai

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| email | string | Naudotojo elektroninio pašto adresas |
| password | string | Naudotojo slaptažodis |

##### Atsako laukai

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| - | string | Rezultato apibūdinimas |

##### Galimi atsako kodai

200, 400

##### Naudojimo pavyzdys

Užklausa

```
{
  "email": "user@example.com",
  "password": "stringstr"
}
```

Atsakas

```
Code: 200
Registered successfully
```

#### \[POST\] /api/Auth/Login

##### Parametrai

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| email | string | Naudotojo elektroninio pašto adresas |
| password | string | Naudotojo slaptažodis |

##### Atsako laukai

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| - | string | Naudotojo JSON Web Token |

##### Galimi atsako kodai

200, 400

##### Naudojimo pavyzdys

Užklausa

```
{
  "email": "user@example.com",
  "password": "stringstr"
}
```

Atsakas

```
Code: 200
eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ1c2VyQGV4YW1wbGUuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IjEyIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQ2xpZW50IiwiZXhwIjoxNjcxNTQwNTY3fQ.FCAN72ahkdgygrOfriZCGBysAwwMP5xCq_fzF9aZ9uA
```

### Delivery

#### \[GET\] /api/Delivery

##### Atsako laukai

Toliau pateikiamos struktūros elementų sąrašas

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| id | int | pristatymo ID |
| deliveryVehicleId | int | pristatymo automobilio ID |
| deliveryCourierId | int | kurjerio, atlikusio pristatymą, ID |
| route | string | bendras pristatymo maršrutas |
| deliveryDate | string | pristatymo data |

##### Galimi atsako kodai

200, 401, 403

##### Naudojimo pavyzdys

Atsakas

```
Code: 200
[
  {
    "id": 1,
    "deliveryVehicleId": 1,
    "deliveryCourierId": 3,
    "route": "Length town",
    "deliveryDate": "2022-09-15T11:19:21.334"
  },
  {
    "id": 4,
    "deliveryVehicleId": 2,
    "deliveryCourierId": 4,
    "route": "Length Town",
    "deliveryDate": "2022-09-15T11:19:21.334"
  },
  {
    "id": 8,
    "deliveryVehicleId": 1,
    "deliveryCourierId": 4,
    "route": "Width town",
    "deliveryDate": "2022-09-15T11:19:21.33"
  },
  {
    "id": 9,
    "deliveryVehicleId": 2,
    "deliveryCourierId": 4,
    "route": "Width Town",
    "deliveryDate": "2022-10-01T15:55:33.338447"
  }
]
```

#### \[POST\] /api/Delivery

##### Parametrai

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| deliveryVehicleId | int | pristatymo automobilio ID |
| deliveryCourierId | int | kurjerio, atlikusio pristatymą, ID |
| route | string | bendras pristatymo maršrutas |
| deliveryDate | string | pristatymo data |

##### Atsako laukai

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| id | int | pristatymo ID |
| deliveryVehicleId | int | pristatymo automobilio ID |
| deliveryCourierId | int | kurjerio, atlikusio pristatymą, ID |
| route | string | bendras pristatymo maršrutas |
| deliveryDate | string | pristatymo data |

##### Galimi atsako kodai

201, 400, 401, 403

##### Naudojimo pavyzdys

Užklausa

```
{
  "deliveryVehicleId": 2,
  "deliveryCourierId": 5,
  "route": "string",
  "deliveryDate": "2022-12-19T13:05:32.487Z"
}
```

Atsakas

```
Code: 201
{
  "id": 10,
  "deliveryVehicleId": 2,
  "deliveryCourierId": 5,
  "route": "string",
  "deliveryDate": "2022-12-19T13:05:32.487Z"
}
```

#### \[GET\] /api/Delivery/{id}

##### Atsako laukai

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| id | int | pristatymo ID |
| deliveryVehicleId | int | pristatymo automobilio ID |
| deliveryCourierId | int | kurjerio, atlikusio pristatymą, ID |
| route | string | bendras pristatymo maršrutas |
| deliveryDate | string | pristatymo data |

##### Galimi atsako kodai

200, 401, 403, 404

##### Naudojimo pavyzdys

Užklausa

```
id : 4
```

Atsakas

```
Code: 200
{
  "id": 4,
  "deliveryVehicleId": 2,
  "deliveryCourierId": 4,
  "route": "Length Town",
  "deliveryDate": "2022-09-15T11:19:21.334"
}
```

#### \[PUT\] /api/Delivery/{id}

##### Parametrai

(Visi laukai nėra reikalaujami, užtenka įvesti vieną)

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| deliveryVehicleId | int | pristatymo automobilio ID |
| deliveryCourierId | int | kurjerio, atlikusio pristatymą, ID |
| route | string | bendras pristatymo maršrutas |
| deliveryDate | string | pristatymo data |

##### Atsako laukai

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| id | int | pristatymo ID |
| deliveryVehicleId | int | pristatymo automobilio ID |
| deliveryCourierId | int | kurjerio, atlikusio pristatymą, ID |
| route | string | bendras pristatymo maršrutas |
| deliveryDate | string | pristatymo data |

##### Galimi atsako kodai

200, 400, 401, 403, 404

##### Naudojimo pavyzdys

Užklausa

```
id : 10
{
  "route": "Cool city"
}
```

Atsakas

```
Code: 200
{
  "id": 10,
  "deliveryVehicleId": 2,
  "deliveryCourierId": 5,
  "route": "Cool city",
  "deliveryDate": "2022-12-19T13:05:32.487"
}
```

#### \[DELETE\] /api/Delivery/{id}

##### Atsako laukai

/-

##### Galimi atsako kodai

204, 400, 401, 403, 404

##### Naudojimo pavyzdys

Užklausa

```
id : 10
```

Atsakas

```
Code: 204
```

### Package

#### \[GET\] /api/Package

##### Atsako laukai

Toliau pateikiamos struktūros elementų sąrašas

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| id | int | siuntos ID |
| size | string | apibendrintas siuntos dydis |
| weight | float | siuntos svoris |
| address | string | siuntos gavėjo adresas |
| recipientId | int | siuntos gavėjo ID |
| assignedToDeliveryId | int | pristatymo ID, kuriam priskirta siunta |
| state | string | siuntos pristatymo būsena |

##### Galimi atsako kodai

200, 401, 403

##### Naudojimo pavyzdys

Atsakas

```
Code: 200
[
  {
    "id": 5,
    "size": "small",
    "weight": 1,
    "address": "Long st. 39",
    "recipientId": 7,
    "assignedToDeliveryId": 1,
    "state": "In warehouse"
  },
  {
    "id": 6,
    "size": "small",
    "weight": 10,
    "address": "Short st. 40",
    "recipientId": 1,
    "assignedToDeliveryId": 1,
    "state": "Being delivered"
  },
  {
    "id": 7,
    "size": "large",
    "weight": 16,
    "address": "Wide st. 2A",
    "recipientId": 1,
    "assignedToDeliveryId": 8,
    "state": "In warehouse"
  }
]
```

#### \[POST\] /api/Package

##### Parametrai

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| size | string | apibendrintas siuntos dydis |
| weight | float | siuntos svoris |
| address | string | siuntos gavėjo adresas |
| recipientId | int | siuntos gavėjo ID |
| assignedToDeliveryId | int | pristatymo ID, kuriam priskirta siunta |
| state | string | siuntos pristatymo būsena |

##### Atsako laukai

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| id | int | siuntos ID |
| size | string | apibendrintas siuntos dydis |
| weight | float | siuntos svoris |
| address | string | siuntos gavėjo adresas |
| recipientId | int | siuntos gavėjo ID |
| assignedToDeliveryId | int | pristatymo ID, kuriam priskirta siunta |
| state | string | siuntos pristatymo būsena |

##### Galimi atsako kodai

201, 400, 401, 403

##### Naudojimo pavyzdys

Užklausa

```
{
  "size": "small",
  "weight": 3,
  "address": "string",
  "recipientId": 1,
  "state": "in warehouse"
}
```

Atsakas

```
Code: 201
{
  "id": 15,
  "size": "small",
  "weight": 3,
  "address": "string",
  "recipientId": 1,
  "assignedToDeliveryId": null,
  "state": "in warehouse"
}
```

#### \[GET\] /api/Package/{id}

##### Atsako laukai

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| id | int | siuntos ID |
| size | string | apibendrintas siuntos dydis |
| weight | float | siuntos svoris |
| address | string | siuntos gavėjo adresas |
| recipientId | int | siuntos gavėjo ID |
| assignedToDeliveryId | int | pristatymo ID, kuriam priskirta siunta |
| state | string | siuntos pristatymo būsena |

##### Galimi atsako kodai

200, 401, 403, 404

##### Naudojimo pavyzdys

Užklausa

```
id : 15
```

Atsakas

```
Code: 200
{
  "id": 15,
  "size": "small",
  "weight": 3,
  "address": "string",
  "recipientId": 1,
  "assignedToDeliveryId": null,
  "state": "in warehouse"
}
```

#### \[PUT\] /api/Package/{id}

##### Parametrai

(Visi laukai nėra reikalaujami, užtenka įvesti vieną)

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| size | string | apibendrintas siuntos dydis |
| weight | float | siuntos svoris |
| address | string | siuntos gavėjo adresas |
| recipientId | int | siuntos gavėjo ID |
| assignedToDeliveryId | int | pristatymo ID, kuriam priskirta siunta |
| state | string | siuntos pristatymo būsena |

##### Atsako laukai

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| id | int | siuntos ID |
| size | string | apibendrintas siuntos dydis |
| weight | float | siuntos svoris |
| address | string | siuntos gavėjo adresas |
| recipientId | int | siuntos gavėjo ID |
| assignedToDeliveryId | int | pristatymo ID, kuriam priskirta siunta |
| state | string | siuntos pristatymo būsena |

##### Galimi atsako kodai

200, 400, 401, 403, 404

##### Naudojimo pavyzdys

Užklausa

```
id : 15
{
  "address": "Wide st. 56"
}
```

Atsakas

```
Code: 200
{
  "id": 15,
  "size": "small",
  "weight": 3,
  "address": "Wide st. 56",
  "recipientId": 1,
  "assignedToDeliveryId": null,
  "state": "in warehouse"
}
```

#### \[DELETE\] /api/Package/{id}

##### Atsako laukai

/-

##### Galimi atsako kodai

204, 401, 403, 404

##### Naudojimo pavyzdys

Užklausa

```
id : 15
```

Atsakas

```
Code: 204
```

### Vehicle

#### \[GET\] /api/Vehicle

##### Atsako laukai

Toliau pateikiamos struktūros elementų sąrašas

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| id | int | automobilio ID |
| regNumbers | int | automobilio registracijos numeriai |
| brand | int | automobilio markė |
| model | string | automobilio modelis |
| maxPayload | string | maksimali automobilio apkrova (kg) |
| driverId | string | automobilio vairuotojo ID |

##### Galimi atsako kodai

200, 401, 403

##### Naudojimo pavyzdys

Atsakas

```
Code: 200
[
  {
    "id": 1,
    "regNumbers": "AAA111",
    "brand": "Mercedes",
    "model": "Sprinter",
    "maxPayload": 2675,
    "driverId": 3
  },
  {
    "id": 2,
    "regNumbers": "BBB666",
    "brand": "Audi",
    "model": "A6",
    "maxPayload": 500,
    "driverId": 4
  }
]
```

#### \[POST\] /api/Vehicle

##### Parametrai

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| regNumbers | int | automobilio registracijos numeriai |
| brand | int | automobilio markė |
| model | string | automobilio modelis |
| maxPayload | string | maksimali automobilio apkrova (kg) |
| driverId | string | automobilio vairuotojo ID |

##### Atsako laukai

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| id | int | automobilio ID |
| regNumbers | int | automobilio registracijos numeriai |
| brand | int | automobilio markė |
| model | string | automobilio modelis |
| maxPayload | string | maksimali automobilio apkrova (kg) |
| driverId | string | automobilio vairuotojo ID |

##### Galimi atsako kodai

201, 400, 401, 403

##### Naudojimo pavyzdys

Užklausa

```
{
  "regNumbers": "LLL676",
  "brand": "Subaru",
  "model": "Forester",
  "maxPayload": 800
}
```

Atsakas

```
Code: 201
{
  "id": 4,
  "regNumbers": "LLL676",
  "brand": "Subaru",
  "model": "Forester",
  "maxPayload": 800,
  "driverId": null
}
```

#### \[GET\] /api/Vehicle/{id}

##### Atsako laukai

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| id | int | automobilio ID |
| regNumbers | int | automobilio registracijos numeriai |
| brand | int | automobilio markė |
| model | string | automobilio modelis |
| maxPayload | string | maksimali automobilio apkrova (kg) |
| driverId | string | automobilio vairuotojo ID |

##### Galimi atsako kodai

200, 401, 403, 404

##### Naudojimo pavyzdys

Užklausa

```
id : 4
```

Atsakas

```
Code: 200
{
  "id": 4,
  "regNumbers": "LLL676",
  "brand": "Subaru",
  "model": "Forester",
  "maxPayload": 800,
  "driverId": null
}
```

#### \[PUT\] /api/Vehicle/{id}

##### Parametrai

(Visi laukai nėra reikalaujami, užtenka įvesti vieną)

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| regNumbers | int | automobilio registracijos numeriai |
| brand | int | automobilio markė |
| model | string | automobilio modelis |
| maxPayload | string | maksimali automobilio apkrova (kg) |
| driverId | string | automobilio vairuotojo ID |

##### Atsako laukai

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| id | int | automobilio ID |
| regNumbers | int | automobilio registracijos numeriai |
| brand | int | automobilio markė |
| model | string | automobilio modelis |
| maxPayload | string | maksimali automobilio apkrova (kg) |
| driverId | string | automobilio vairuotojo ID |

##### Galimi atsako kodai

200, 400, 401, 403, 404

##### Naudojimo pavyzdys

Užklausa

```
id : 4
{
  "driverId": 5
}
```

Atsakas

```
Code: 200
{
  "id": 4,
  "regNumbers": "LLL676",
  "brand": "Subaru",
  "model": "Forester",
  "maxPayload": 800,
  "driverId": 5
}
```

#### \[DELETE\] /api/Vehicle/{id}

##### Atsako laukai

/-

##### Galimi atsako kodai

204, 400, 401, 403, 404

##### Naudojimo pavyzdys

Užklausa

```
id : 4
```

Atsakas

```
Code: 204
```

#### \[GET\] /api/Vehicle/{id}/Packages

##### Atsako laukai

Toliau pateikiamos struktūros elementų sąrašas

| Pavadinimas | Tipas | Aprašymas |
| --- | --- | --- |
| id | int | siuntos ID |
| size | string | apibendrintas siuntos dydis |
| weight | float | siuntos svoris |
| address | string | siuntos gavėjo adresas |
| recipientId | int | siuntos gavėjo ID |
| assignedToDeliveryId | int | pristatymo ID, kuriam priskirta siunta |
| state | string | siuntos pristatymo būsena |

##### Galimi atsako kodai

200, 401, 403, 404

##### Naudojimo pavyzdys

Užklausa

```
id : 1
```

Atsakas

```
Code: 200
[
  {
    "id": 5,
    "size": "small",
    "weight": 1,
    "address": "Long st. 39",
    "recipientId": 7,
    "assignedToDeliveryId": 1,
    "state": "In warehouse"
  },
  {
    "id": 6,
    "size": "small",
    "weight": 10,
    "address": "Short st. 40",
    "recipientId": 1,
    "assignedToDeliveryId": 1,
    "state": "Being delivered"
  },
  {
    "id": 7,
    "size": "large",
    "weight": 16,
    "address": "Wide st. 2A",
    "recipientId": 1,
    "assignedToDeliveryId": 8,
    "state": "In warehouse"
  },
  {
    "id": 8,
    "size": "large",
    "weight": 20,
    "address": "Wide st. 2A",
    "recipientId": 6,
    "assignedToDeliveryId": 8,
    "state": "In warehouse"
  }
]
```

## Išvados

1. Kuriant projekto API sąsają, tinkamai aprašius galimas klaidas, sukūrus apribojimus kintamiesiems, lieka mažiau darbo kuriant naudotojo sąsają - joje pasirūpinti šiais elementais yra daug sudėtingiau.
2. JWT autentifikacija yra nesunkiai įgyvendinama ir suteikia patikimą apsaugą. Vienas jos trūkumas yra, kad serverinėje dalyje labai nepatogu kurti atsijungimo funkcijos, nes norint tai padaryti tenka vienaip ar kitaip saugoti JWT serveryje.
3. Prieš pradedant kurti vartotojo sąsają reikia gerai įvertinti, kokias komponentų bibliotekas naudoti ir ar jos suderinamos tarpusavyje.
