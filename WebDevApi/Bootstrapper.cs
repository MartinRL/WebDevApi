using Nancy.TinyIoc;
using WebDevApi.Domain;

namespace WebDevApi
{
	using Nancy;

	public class Bootstrapper : DefaultNancyBootstrapper
	{
		protected override void ConfigureApplicationContainer(TinyIoCContainer container)
		{
			container.Register<CustomerRepository, CustomerRepository>().AsSingleton();
		}
	}
}
