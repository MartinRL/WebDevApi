using Nancy;

namespace WebDevApi
{
	public class CustomerModule : NancyModule
	{
		public CustomerModule()
		{
			Get ["/customers/{id}"] = _ =>
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
}";
		}
	}
}
