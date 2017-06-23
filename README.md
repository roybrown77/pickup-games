# Pickup Games

Create, join and track fitness at pickup games like flag football, basketball, golf, soccer, tennis, chess, etc.

http://qpiga.apphb.com 

*may take up to 15 seconds for site to come up since https://appharbor.com spins up iis when there is no traffic for a given amount of time

# Tek Stak

Client:

- Angular 1 / Javascript
- Bootstrap
- Google Maps API

Backend:

- .Net Web Api / C#
- Google Maps API
- No database as this is a demo app.  Using static internal memory (in mock repositories) to record information which will be removed when iis/server resets.
- Architected/organized using Domain Driven Design (DDD) principles

Continuous integration and hosting server:

- https://appharbor.com which uses Amazon Web Services (AWS)

# To run application locally

1. Open in Visual Studio Professional

2. I'll eliminate this step in a later version:

comment out line:

var serviceBase = 'http://qpiga.apphb.com/';

uncomment line:

var serviceBase = 'http://localhost:59512/';

3. Hit f5