# Events as System Architecture

The purpose of this template is to facilitate and acelerate development of event driven Apis and Workers. As for experimentation of new tecnologies and patterns. This repository will change based on this principles.

# Structure

This repository is divided in Generator and Consumer, based looselly on CQRS pattern, decoupling reads and writes completly, all the validation logic that ensures faster and reliable writes will be placed in the Generator and all logic for reads will be placed in the Consumer, the idea behind this pattern is to have a separation of behaviours in order to implement logic in a more direct and concise way, allowing the escalability of using the same event stream for multiple consumers open the oportunity to develop new functionalitys with no impact on the events generated.
 

## Architecture Design

![Basic Design](https://github.com/caiocampoos/csharp-events-template/blob/main/docs/diagram.png)


## Todo

- [ ] Add Endpoint for Client Authentication (Issuer of Tokens for authenticathed users)
- [ ] Add validation checksum for ensure secure transactions  
 - [ ] Add endpoint for Api Monitoring  

### In Progress

- [ ] Base App Consumer   

### Done ✓

- [x] Base Generator

---
To run this project you will need:

- RabbitMq running locally or in a docker container
- MongoDB uri and db config on the appSettings.json 



