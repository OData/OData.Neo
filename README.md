# OData.NxT

This is OData NxT. The next generation of OData Protocol implementation for the .NET ecosystem. This implementation will incorporate three new fundamental design capabilities to OData.NET. These capabilities are:

## 0. Protocol Agnosticism
The new implementation is aiming towards creating a communication protocol-agnostic library. Which means that OData may no longer be tied up to RESTful APIs communication and can be used broadly across any system-to-system integration.

For instance, if two systems decided to use gRPC or SOAP or any other protocol to communicate, these protocols will not be impediment in establishing that connection while leveraging the powerful capabilities of OData.

Protocol-Agnostic OData shall expand the reach of OData to systems that don't neccearily use REST. But more importantly, this priority will allow OData to become an adapative technology that can withstand the challenge of time in a forever changing industry.

The concept of adaptibility will be driving most of our architecture and design decisions throughtout this project and all other complimantry components that will built to support this effort.


## 1. Modularity
Modular technology allows the community of engineering to develop and contribute to any platform to make it more useful to fit particular scenarios that may be beyond the priorities of the core engineering team.

Querying data can come in all different shapes and forms. And while the standard OData protocol offers plenty of options to query data in terms of shaping, selecting, ordering and so many other options, it's still limited in terms of allowing the engineering community to drive larger impact through plug-n-play modules for querying.

OData NxT is aiming to become a marketplace for all things related to data querying. We want to allow anyone, anywhere to offer more querying capabilities so others can benefit from these capabilities at scale.

At it's core design, OData NxT shall be completely, and easily rewritable to allow any engineering team to optimize for performance. We will be avoiding the common mistake of creating un-replaceable, un-rewritable core components that becomes a pain down the road for any team who are trying to push for higher performance or even a better implementation.

Modularity as a second priority will allow OData NxT Marketplace to expand beyond it's current capabilities, and we can't wait to see how our community is going to form their own modules to make OData NxT suitable perfectly for their businesses.


## 2. Transcendance
Modern software architecture demands certain capabilities in terms of integration. We want to allow OData queries to pass through any number of microservices/lambdas to land on the data-owner service and successfully execute and retrieve a query.

Transcendance in it's essence is the ability to allow a microservice to receive and pass an OData query to it's dependencies. This priority is important in terms of adapting to modern design like microservices, serverless and any other patterns that may occur in the future.

But Transcendance also aims for aggregation and control. We want to allow software engineers to develop microservices that can receive one single OData query and execute that query across multiple services or data-owning services. I will call that Query-Fanning and let's visualize it as follows:

<div align=center>
    <img src="https://user-images.githubusercontent.com/1453985/148118524-4a96ed49-aa6c-44f4-af53-ce9361531950.png" />
</div>
