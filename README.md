EsthR
=====

EsthR is a tool which helps testing HTTP requests and responses. It provide a simple "chainging" syntax
to configure the request and the expected response.

In the following example we make a request to StackOverflow and expect a response with the HTTP statuscode
of 200 and a response body with length greater then zero.

```cs
[TestMethod]
public void TestRequest()
{
    EsthR.Instance
        .Send(new Request()
            .WithUri("https://api.stackexchange.com/2.2/tags")
            .WithMethod("GET")
            .WithUriParameter("site", "stackoverflow")
            .WithUriParameter("order", "desc"))
        .Expect(new Response().WithStatusCode(200));
}
```

Alternatively you can use a json file to build a request or response:

```json
{
	"uri" : "https://api.stackexchange.com/2.2/tags",
	"method" : "GET",
	"headers" : [ 
		{"key" : "Accept", "value" : "text/json" },
	],
	"url_parameters" : [
		{"key" : "site", "value" : "stackoverflow" },
		{"key" : "order", "value" : "desc" }
	]
}
```

Then load this file:

```cs
var request = Request.FromConfig(@".\testInput\RequestInput.json");
```

You can use a custom condition on responses. Below we test if a response's body length greater then zero:

```cs
[TestMethod]
public void TestConditionFunction()
{
    EsthR.Instance
    .Send(new Request()
        .WithUri("https://api.stackexchange.com/2.2/tags")
        .WithMethod("GET")
        .WithUriParameter("site", "stackoverflow")
        .WithUriParameter("order", "desc"))
    .Expect(new Response()
        .WithCondition(response => response.Body.Length > 0));
}
```
