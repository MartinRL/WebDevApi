using System.IO;
using Nancy;
using Nancy.IO;
using WebDevApi.Domain;

namespace WebDevApi
{
	public class CustomerModule : NancyModule
	{
		private readonly CustomerRepository customerRepository;

		public CustomerModule(CustomerRepository customerRepository)
		{
			this.customerRepository = customerRepository;

			Get ["/customers/{id}"] = parameters => this.customerRepository.Get(parameters.id);

			Put["/customers/{id}"] = _ =>
			{
				this.customerRepository.Update(Request.Body.ReadAsString());

				return HttpStatusCode.OK;
			};
		}
	}

	public static class RequestBodyExtensions
	{
		public static string ReadAsString(this RequestStream @this)
		{
			using (var reader = new StreamReader(@this))
			{
				return reader.ReadToEnd();
			}
		}
	}
}
