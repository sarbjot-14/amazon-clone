# Amazon Clone App

Amazon Clone to learn about microservices and full stack development

Demo: https://youtube.com/playlist?list=PLxzCb6HSo0uubPsKuPAy9dqSFemfO8Tfc&si=u1iHTdMB_eS_OrbE

![image](https://github.com/sarbjot-14/amazon-clone/assets/38801533/d908b9ed-a618-4eaa-9c1b-3812db12f08a)

## Tech Stack
* **.NET** 
    * Created an order and inventory service that communicate via message queue, and are also exposed to web through http api
    * Entity Framwork to query the SQL database
    * Used events and background workers to listen to messager queue

* **Angular 17**
    * Rxjs to handle asynchronous data
    * NGRX to handle global store
    * Style multiple compononts and pages with SCSS
    
* **RabbitMQ** :
    * Implemented event driven microservice architecture using this message queue

* **Database** :
    * SQL
* **Redis** :
    * Implemented a redis cache and deployed using kubernetes
    * Reduced calls to sql database by caching products with redis
   
* **Kubernetes**
    * Deploy .NET services for product ordering and inventory management
    * Deploy SQL database with persist claim which will preserve data even if container is killed
    * Deploy services such that pods can communicate with each other
    * Deployed Ingress load balancer
    * Deployed RabbitMQ server
    

## Kubernetes Architecture:
![Screenshot 2024-01-17 at 8 08 38 PM](https://github.com/sarbjot-14/amazon-clone/assets/38801533/40c41569-48fd-4283-95aa-493beb58cf02)









