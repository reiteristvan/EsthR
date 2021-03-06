﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EsthR.Tests
{
    [TestClass]
    public class EsthRTests
    {
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
    }
}
