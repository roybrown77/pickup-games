# Pickup Games

Create, join and track pickup games.

http://qpiga.apphb.com 

*may take up to 15 seconds for site to come up since https://appharbor.com spins up iis when sleep

# Tek Stak

Client:

- Angular 1
- Bootstrap
- Google Maps

Backend:

- .Net Web Api / C#
- Google Maps
- Architected/organized using DDD principles

Continuous integration and hosting server:

- https://appharbor.com which uses Amazon cloud

# To run application locally

1. open in visual studio

2. i'll eliminate this step in a later version:

comment out line:

var serviceBase = 'http://qpiga.apphb.com/';

uncomment line:

var serviceBase = 'http://localhost:59512/';

3. hit f5