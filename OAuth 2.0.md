## It has 4 Roles
- Resource Owner
    - Usualy means the end user. The person who ownes a resource
- Resource Server
    - The protected resource that needs a token to be accessed. Is is a stateless server.
- Client
    - The application that needs acces to a resource.
    It does not handle the authentication. Only needs the access token to forward it to Resource server.
- Authorization server
    - It is does the havy lifting in terms of authentication. It is issuing authentication tokens and authenticate users.