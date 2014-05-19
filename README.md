EsthR
=====

EsthR is a tool which helps testing HTTP requests and responses. It provide a simple "chainging" syntax
to configure the request and the expected response.

In the following example we make a request to StackOverflow and expect a response with the HTTP statuscode
of 200 and a response body with length greater then zero.

'''cs
EsthR.Instance
.Send(new Request()
    .WithUri("https://api.stackexchange.com/2.2/tags")
    .WithMethod("GET")
    .WithUriParameter("site", "stackoverflow")
    .WithUriParameter("order", "desc"))
.Expect(new Response()
    .WithStatusCode(200)
    .WithCondition(response => response.Body.Length > 0));
