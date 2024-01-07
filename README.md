# Disability-map-api

## Table of contents

- [About the Project](#Description)
- [Used Technologies](#Used-Technologies)
- [Used Aure Services](#Used-Aure-Services)
- [Endpoints](#Endpoints)
- [UI](#UI)


# Description
Aplication provides a map on which user can check, add and rate places comfortable to people with disabilities. Users can also make a reservation on facility.
Markers on the map indicate the type of place and accessibility rating. The application enables geolocation.

This is Backend part of project if you want to see React Single Pagel App code go to:
https://github.com/wobrozek/disabled-facilities-map

### Used Technologies
- ASP .NET Core WebApi
- Entity Framework
- JwtBearerToken
- xunit

   
- React
- TypeScript
- React Leaflet
- Material UI
- SASS

### Used Aure Services
- Azure Service Bus
- Azure Storage
- Azure Web App
- Azure Functions
- Azure Sql Databases
  
# Endpoints
Token Based Authentication

![image](https://github.com/wobrozek/disability-map-api/assets/64639878/3d3fb6fd-b1a4-47e4-8b39-9d427d834ee2)
Due to individual endpoint to photos is possible to send photo immediately after upload to input input.

![image](https://github.com/wobrozek/disability-map-api/assets/64639878/d66bfa10-0e8d-4273-bf67-a9f7b81686d0)

Crud Places can be accessed by radius and filtered by type

![image](https://github.com/wobrozek/disability-map-api/assets/64639878/10d5b126-1924-45e2-b8ba-1280ad258106)
![image](https://github.com/wobrozek/disability-map-api/assets/64639878/4d807280-f24e-4194-bbaf-8544e9f288c2)

Score contains information about likes from database and forsquare api.

![image](https://github.com/wobrozek/disability-map-api/assets/64639878/c8566ab5-cd49-4233-880c-2122fe6deb5c)
![image](https://github.com/wobrozek/disability-map-api/assets/64639878/b71699e4-e4bd-4355-8ef3-b0e4c9bfd734)

# UI

![scrn1overall](https://github.com/wobrozek/disability-map-api/assets/64639878/44dae02a-6c4a-4235-8d4e-fad5f3991047)


Navigation is adapted to the needs of people with limited mobility.

![scrn2panel](https://github.com/wobrozek/disability-map-api/assets/64639878/b00ec7aa-9b1f-4869-b8ba-e00134c018d6)

Users can filter places and facilities by type, see the list of reservations and added places.

![filtering places](https://media.giphy.com/media/XooGriLsvm68zvqkZF/giphy.gif)

![making a reservation](https://media.giphy.com/media/ik4KE8ezCX1eKz6DQm/giphy.gif)

![adding new place](https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExN29kbGJ1bnk2b2FhY3VrajBmOGFzZjhmajdpeDMxY2xlZTNsbzA2YiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/V4S3H4Zd1xxCk3nSTl/giphy.gif)

