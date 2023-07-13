# ShrtLy

This repository contains a refactoring kata. It's supposed to simulate the takeover and delivery of new features in a legacy project.

The company you recently started working for, had accumulated over the years a lot of websites, many of which have very long paths, and use inconsistent conventions to defining the routes.

A while ago one of the junior developers wanted to be able to share links to websites with his colleagues so he started working on a applicaiton that would shorten the links he wanted to share the links would fit better in chats and emails. Unfortunately the original developer has left the company before he could finish this service.

Now one of the managers wants this service to be able to share pretty links with clients, and he asked you to get this application up and running.

## Functional requirements

- The application should be able to accept URLs and shorten them. The shorter tzhe better.
- The application should be able to redirect users to the original URL when they use a shortened link.
- The application should not accept already shortened URLs. Cause why would it.

## Non-functional requirements

- The manager expects to use the application to generate A LOT of link so it should remain fast even after a lot of URLs have already been shortened.
- The application must be super reliable so the clients do not complain about not being able to use the links.
- The manager wants to deploy the applicaition in the cloud since the manager heard that's cheap.
- Since this is an internal project there's not a lot of budget so the application should be cheap to maintain.

## Rules

Feel free to make any changes you think are necessary to the code. 
The manager wants this application to be ready in a few days, so the less time you spend the better.
