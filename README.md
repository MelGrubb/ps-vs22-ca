# ps-vs22-ca "Greenfield" project
Demo project assets for my Pluralsight course "Code Analysis with Visual Studio 2022"

## Overview
The Greenfield project is a simple set of objects and pages that represent the start of a short-term vacation rental site with a twist. Instead of renting someone's apartment, you're renting their undeveloped property to use for day use or overnight camping trips. It's like a regular apartment rental site, but without the apartment.

## Getting started
- Clone the application locally, and do a build.
- From the Package Manager Console, run an `update-database` to create the starter database in your LocalDB instance.

## Users
The database is seeded with two users
- greenfield.admin@globomantics.com / P@55w0rd
- greenfield.test@globomantics.com / P@55w0rd

## Entities
The following are the Entity Framework models defined and used by the system.

### User
A user is anyone in the system. It could be someone offering space for rent or someone looking for those spaces. A user can be both if they want.

| Name         | Type        | Description |
| ------------ | ----------- | ----------- |
| Id           | Guid        |             |
| FirstName    | string(25)  |             |
| LastName     | string(25)  |             |
| EmailAddress | string(256) |             |

### Location
A location that can be made available for rent

| Name          | Type         | Description                                                                |
| ------------- | ------------ | -------------------------------------------------------------------------- |
| Id            | Guid         |                                                                            |
| Name          | string(50)   |                                                                            |
| Description   | string(1000) | A long description of the location                                         |
| AddressLine1  | string(50)   |                                                                            |
| AddressLine2  | string(50)   |                                                                            |
| City          | string(25)   |                                                                            |
| StateProvince | string(25)   | The state or province, depending on the country                            |
| PostalCode    | string(10)   | The zip code or postal code of the property                                |
| Condition     | Condition    | An enumeration value that described the overall condition of the location. |

### TimeSlot
A time slot available to be reserved.

| Name  | Type           | Description                    |
| ----- | -------------- | ------------------------------ |
| Id    | Guid           |                                |
| Start | DateTimeOffset | The beginning of the time slot |
| End   | DateTimeOffset | The end of the time slot       |

### Reservation
The combination of a timeslot and a user who has reserved that time slot.

| Name           | Type | Description                                    |
| -------------- | ---- | ---------------------------------------------- |
| Id             | Guid |                                                |
| AvailabilityId | Guid | The available time slot that has been reserved |
| UserId         | Guid | The user who has reserved the time slot        |

## Enumerations

### Condition
Describes the overall average condition of the location. 

| Id  | Value      | Description                                                   |
| --- | ---------- | ------------------------------------------------------------- |
| 0   | Unknown    | The location has no specified condition                       |
| 1   | Primitive  | The site is in a natural state                                |
| 2   | Maintained | The site has been "tamed". Usually means it's at least mowed. |
| 3   | Manicured  | The site is meticulously maintained. The sites are pristine.                                                              |

