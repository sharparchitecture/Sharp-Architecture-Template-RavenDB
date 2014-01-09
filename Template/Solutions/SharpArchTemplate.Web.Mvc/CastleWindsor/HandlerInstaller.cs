namespace SharpArchTemplate.Web.Mvc.CastleWindsor
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using SharpArch.Domain.Commands;
    using SharpArch.Domain.Events;

    public class HandlersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Types.FromAssemblyNamed("SharpArchTemplate.Tasks")
                    .BasedOn(typeof(ICommandHandler<>))
                    .WithService.FirstInterface().LifestylePerWebRequest());

            container.Register(
                Types.FromAssemblyNamed("SharpArchTemplate.Tasks")
                    .BasedOn(typeof(ICommandHandler<,>))
                    .WithService.FirstInterface().LifestylePerWebRequest());

            container.Register(
                Types.FromAssemblyNamed("SharpArchTemplate.Tasks")
                    .BasedOn(typeof(IHandles<>))
                    .WithService.FirstInterface().LifestylePerWebRequest());
        }
    }
}