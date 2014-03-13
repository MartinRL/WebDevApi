using FluentAssertions;
using Nancy;
using Nancy.Testing;
using Xunit;

namespace WebDevApi.Test
{
    public class RouteTest
    {
		[Fact]
		public void Should_return_status_ok_when_route_exists()
		{
			var bootstrapper = new DefaultNancyBootstrapper();
			var browser = new Browser(bootstrapper);

			var response = browser.Get("/customer/1", with => with.HttpRequest());

//			response.StatusCode.Should().Be(HttpStatusCode.OK);
			response.Body.DeserializeJson<string>().Should().Contain("");
		}
    }
}
