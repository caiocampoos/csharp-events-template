# Events as System Architecture

The purpose of this template is to facilitate and acelerate development of event driven Apis and Workers. As for experimentation of new tecnologies and patterns. This repository will change based on this principles.

# Structure

This repository is divided in Generator and Consumer, based looselly on CQRS pattern, decoupling reads and writes completly, all the validation logic that ensures faster and reliable writes will be placed in the Generator and all logic for reads will be placed in the Consumer, the idea behind this pattern is to have a separation of behaviours in order to implement logic in a more direct and concise way, allowing the escalability of using the same event stream for multiple consumers open the oportunity to develop new functionalitys with no impact on the events generated.

Tests can be made with distinc aproaches based on what side of the application we are testing from unit to integration the test base is also segregated.
 

## Architecture Design

![Basic Design](/docs/diagram.png)


## Todo

- [ ] Add Endpoint for Client Authentication (Issuer of Tokens for authenticathed users)
- [ ] Unit Tests for Services and Aplication
- [ ] Add validation checksum for ensure secure transactions  
- [ ] Add endpoint for Api Monitoring  

### In Progress

- [ ] Base App Consumer
- [ ] Data Visualization Service
- [ ] Report System based on Event Stream and BD data
- [ ] Unit Tests
- [ ] Integration Tests
- [ ] Code quality tracking with SonarQube and Eslint
- [ ] Load Test

### Done ✓
- [x] Arquitechture
- [x] Base Generator

---
To run this project you will need:

- RabbitMq running locally or in a docker container
- MongoDB uri and db config on the appSettings.json 



