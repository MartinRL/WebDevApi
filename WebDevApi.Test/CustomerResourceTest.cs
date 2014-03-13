using FluentAssertions;
using Nancy;
using Nancy.Testing;
using Xunit;

namespace WebDevApi.Test
{
	public class CustomerResourceTest
	{
		[Fact]
		public void get_should_return_customer_as_json()
		{
			var browser = new Browser(new Bootstrapper());

			var response = browser.Get("/customers/1", with =>
			{
				with.Header("accept", "application/json");
				with.HttpRequest();
			});

			response.StatusCode.Should().Be(HttpStatusCode.OK);
			response.Body.AsString().Should().Be(
@"{
	""customer"": {
		""id"": 1,
		""cpr"": 180173XXXX,
		""secondaryPhoneNumber"": ""+46707318625"",
		""name"": {
			""first"": ""Martin"",
			""last"": ""Rosén-Lidholm""
		}
		""email"": ""mrol@telenor.dk"",
		""address"": {
			""street"": ""Nils Anderssons gata"",
			""houseNumber"": 12,
			""postalCode"": 21836,
			""city"": ""Bunkeflostrand"",
			""country"": ""Sverige"",
		}
		""balance"": 322.50,
		""electiveServices"": [
			{ ""name"": ""5 GB data"" }, 
			{ ""name"": ""Udlandsopkald"" },
		]
		""receivePromomotionsPermissions"": {
			""sms"": false,
			""email"": true,
			""phoneCall"": false
		}
	}
}");
		}

		[Fact]
		public void put_to_existing_id_should_update_customer()
		{
			var browser = new Browser(new Bootstrapper());

			var response = browser.Put("/customers/1", browserContext => browserContext.Body(
@"{
	""customer"": {
		""id"": 1,
		""cpr"": 180173XXXX,
		""secondaryPhoneNumber"": ""+46707318625"",
		""name"": {
			""first"": ""Martin"",
			""last"": ""Rosén-Lidholm""
		}
		""email"": ""mrl@mvno.dk"",
		""address"": {
			""street"": ""Nils Anderssons gata"",
			""houseNumber"": 12,
			""postalCode"": 21836,
			""city"": ""Bunkeflostrand"",
			""country"": ""Sverige"",
		}
		""balance"": 322.50,
		""electiveServices"": [
			{ ""name"": ""5 GB data"" }, 
			{ ""name"": ""Udlandsopkald"" },
		]
		""receivePromomotionsPermissions"": {
			""sms"": true,
			""email"": true,
			""phoneCall"": false
		}
	}
}")).Then.Get("/customers/1", with =>
				{
					with.Header("accept", "application/json");
					with.HttpRequest();
				});

			response.StatusCode.Should().Be(HttpStatusCode.OK);
			response.Body.AsString().Should().Be(
@"{
	""customer"": {
		""id"": 1,
		""cpr"": 180173XXXX,
		""secondaryPhoneNumber"": ""+46707318625"",
		""name"": {
			""first"": ""Martin"",
			""last"": ""Rosén-Lidholm""
		}
		""email"": ""mrl@mvno.dk"",
		""address"": {
			""street"": ""Nils Anderssons gata"",
			""houseNumber"": 12,
			""postalCode"": 21836,
			""city"": ""Bunkeflostrand"",
			""country"": ""Sverige"",
		}
		""balance"": 322.50,
		""electiveServices"": [
			{ ""name"": ""5 GB data"" }, 
			{ ""name"": ""Udlandsopkald"" },
		]
		""receivePromomotionsPermissions"": {
			""sms"": true,
			""email"": true,
			""phoneCall"": false
		}
	}
}");
		}

		[Fact]
		public void put_to_insert_should_return_forbidden()
		{
			var browser = new Browser(new Bootstrapper());

			var response = browser.Put("/customers/2", browserContext => browserContext.Body(
@"{
	""customer"": {
		""id"": 2,
		""cpr"": 180173XXXX,
		""secondaryPhoneNumber"": ""+46707318625"",
		""name"": {
			""first"": ""Martin"",
			""last"": ""Rosén-Lidholm""
		}
		""email"": ""mrl@mvno.dk"",
		""address"": {
			""street"": ""Nils Anderssons gata"",
			""houseNumber"": 12,
			""postalCode"": 21836,
			""city"": ""Bunkeflostrand"",
			""country"": ""Sverige"",
		}
		""balance"": 322.50,
		""electiveServices"": [
			{ ""name"": ""5 GB data"" }, 
			{ ""name"": ""Udlandsopkald"" },
		]
		""receivePromomotionsPermissions"": {
			""sms"": true,
			""email"": true,
			""phoneCall"": false
		}
	}
}"));

			response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
		}
	}
}
