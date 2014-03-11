using Nancy;

public class CustomersModule : NancyModule
{
	public CustomersModule()
	{
		Get["/customers/{id}"] = _ => 
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
			""street"": ""Frederikskaj"",
			""houseNumber"": 8,
			""postalCode"": 1780,
			""city"": ""København S"",
			""country"": ""Danmark"",
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
