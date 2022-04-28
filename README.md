# OData.NxT

[![Discord Shield](https://discordapp.com/api/guilds/934133164790644777/widget.png?style=shield)](https://discord.gg/Nr8w6wxv)

This is OData NxT. The next generation of OData Protocol implementation for the .NET ecosystem. This implementation will incorporate three new fundamental design capabilities to OData.NET. These capabilities are:

## 0. Protocol Agnosticism
The new implementation is aiming towards creating a communication protocol-agnostic library. Which means that OData may no longer be tied up to RESTful APIs communication and can be used broadly across any system-to-system integration.

For instance, if two systems decided to use gRPC or SOAP or any other protocol to communicate, these protocols will not be impediment in establishing that connection while leveraging the powerful capabilities of OData. here's an illustration of this approach:

<br />
    <div align=center>
        <img src="https://user-images.githubusercontent.com/1453985/148163343-d5c1ba7f-ab14-463e-8391-ea2d4cb5e644.png">
    </div>
<br />

The APIs in the above example will simply receive an odata query and turn it into an expression and vice versa. It has absolutely no attachment to any particular protocol of communication which makes it more powerful to integrate with any system.

Protocol-Agnostic OData shall expand the reach of OData to systems that don't neccearily use REST. But more importantly, this priority will allow OData to become an adapative technology that can withstand the challenge of time in a forever changing industry.

The concept of adaptibility will be driving most of our architecture and design decisions throughtout this project and all other complimantry components that will built to support this effort.


## 1. Modularity
Modular technology allows the community of engineering to develop and contribute to any platform to make it more useful to fit particular scenarios that may be beyond the priorities of the core engineering team.

Querying data can come in all different shapes and forms. And while the standard OData protocol offers plenty of options to query data in terms of shaping, selecting, ordering and so many other options, it's still limited in terms of allowing the engineering community to drive larger impact through plug-n-play modules for querying.

OData NxT is aiming to become a marketplace for all things related to data querying over the wire. We want to allow anyone, anywhere to offer more querying capabilities so others can benefit from these capabilities at scale.

At it's core design, OData NxT shall be completely, and easily rewritable to allow any engineering team to optimize for performance. We will be avoiding the common mistake of creating un-replaceable, un-rewritable core components that becomes a pain down the road for any team who are trying to push for higher performance or even a better implementation.

We have split OData NxT into three main components as follows:

<br />
    <div align=center>
        <img src="https://user-images.githubusercontent.com/1453985/148162083-15a82b29-1f90-4ed6-9614-31fee4914c49.png" />
    </div>
<br />

Let's talk the components of OData NxT here in detail:

#### 1.0 Substrate
The substrate or the Lakehouse is a new pattern I will be experimenting with to push decoupling of any system components beyond interfaces and dependency injections. Ideally components should be subscribed to one and only one dependency at all times and execute all their communications through that substrate.

The lakehouse pattern will be very similar to queues, except that it allows components to fire-n-observe instead of just fire-n-foreget. This way we allow any component to be plugged into the system even in runtime without impacting the existing flow. Here's an example:

Assume that our API client is `ODataClient` which exposes a function `Query(string odataQuery)`. During integration the client would look something like this:

```csharp
public async ValueTask<IQueryable<T>> QueryAsync(string query) =>
    this.dataLikeService.SendObserve(new Message(query), Events.Query);
```

The substrate will handle communicating with listeners to the `Query` event and communicate with all the subscribers to that event. This pattern is very similar to the subscriber pattern except that the publisher is waiting on the other side for the listeners to respond.

This way, the API client can send events to any number of subscribers without having to know anything about these subscribers or their contracts. The same thing goes for the subscribers with the publishers. Software engineers now may develop components that plug into the substrate, listen to events in the system and act on it.

#### 1.1 APIs
[Exposure](https://github.com/hassanhabib/The-Standard/blob/master/3.%20Exposers/3.%20Exposers.md) components like the exposed APIs from the core library will mainly focusing on two basic functionality:
 - String to Expression Capability
 - Expression to String Capability

 Both are very important to allow engineers to fully control incoming OData queries or generate ones out of simple expressions in the system so they can push it further to other systems.

 APIs shall be easily mockable for N-Tier system architecture engineers but also modular to allow for expansion in the future for further capabilities.

 #### 1.2 Services
 [Services](https://github.com/hassanhabib/The-Standard/blob/master/2.%20Services/2.%20Services.md) are the core business logic of OData NxT. Services will contain all the routines and sub-routines needed to digest and map an OData query into expressions, and strongly typed collections or collection interfaces so they are easily consumable by API developers.

 Services can be of three different types, Foundations that hold primitive operations. Processing that holds higher-order business logic and lastly Orchestrations that combine multiple entity types for processing with a unified contract.

 #### 1.3 Brokers
 [Brokers](https://github.com/hassanhabib/The-Standard/blob/master/1.%20Brokers/1.%20Brokers.md) will abstract away native or external dependencies the OData NxT core functions may need so they are replaceable down the road with better dependencies without changing the business logic of the library.

Modularity as a second priority will allow OData NxT Marketplace to expand beyond it's current capabilities, and we can't wait to see how our community is going to form their own modules to make OData NxT suitable perfectly for their businesses.


## 2. Transcendance
Modern software architecture demands certain capabilities in terms of integration. We want to allow OData queries to pass through any number of microservices/lambdas to land on the data-owner service and successfully execute and retrieve a query.

Transcendance in it's essence is the ability to allow a microservice to receive and pass an OData query to it's dependencies. This priority is important in terms of adapting to modern design like microservices, serverless and any other patterns that may occur in the future.

But Transcendance also aims for aggregation and control. We want to allow software engineers to develop microservices that can receive one single OData query and execute that query across multiple services or data-owning services. I will call that Query-Fanning and let's visualize it as follows:

<div align=center>
    <img src="https://user-images.githubusercontent.com/1453985/148118524-4a96ed49-aa6c-44f4-af53-ce9361531950.png" />
</div>

While aggregation is possible today with the current version of OData. It is not as seamlessly as it can be. We aim to make Transcendance a plug-n-play capability. All you got to do as an engineer is to break an incoming expression into smaller expressions with the new OData.NxT library and then post and aggregate responses.

The new implementation of OData will be strictly following [The Standard](https://github.com/hassanhabib/The-Standard) to ensure the software is at the highest quality possible with Test-Driven approach and ongoing pushes for [code rubs](https://hassanhabib.com/2020/02/09/code-rub/) and [pure coding](https://hassanhabib.medium.com/pure-coding-7bb2d44640ba) to ensure a systematic intentional engagement of our community in the development of the new technology and it shall also help with the maintainability of the system since it's being built in the open.

I'm going to document every single step of the way with blogs, videos and pull requests to help newcomers and contributors understand where we were, and where we are today and where we are headed with this technology.

## 3. Roadmap
Now, let's discuss the roadmap for OData NxT. This prilimanary roadmap will set the initial tentative expectations for deliverables as follows:

<br />
    <div align=center>
        <img src="https://user-images.githubusercontent.com/1453985/148167448-f99e1d59-e898-447b-b731-a10d4f6cd73b.png" />
    </div>
<br />

There are few things that I need everyone to understand about this roadmap, which are as follows:
1. Quality over quantity. If we need more time to make something right, covering more scenarios we will adjust as we go.
2. The roadmap is only there to help us and our community of engineers understand what the next step may be. It is a subject to change and enhance as needed.
3. This roadmap is very high-level. There will be a further breakdown in our sessions (weekly standup) to breakdown the timeline into more detailed deliverables.

And With the aforementioned priorities we believe that we can explore new realms of software integration where OData can have an even further reach than what it already has today from the smallest APIs and applications to the largest enterprise-size platforms that already serve millions of customers today.

If you have any questions, comments or followups please reach out to me (@hassanhabib) or Sam Xu (@xuzhg).
