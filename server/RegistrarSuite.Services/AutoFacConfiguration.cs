using Autofac;
using NLog;
using RegistrarSuite.Repositories.Metadata;
using RegistrarSuite.Repositories.UOW;
using RegistrarSuite.Services.Metadata;
using RegistrarSuite.Services.Students;

namespace RegistrarSuite.Services
{
    public class AutoFacConfiguration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>)).InstancePerDependency();

            builder.RegisterType<StudentService>().As<IStudentService>().InstancePerDependency();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerDependency();

            builder.RegisterType<FamilyMemberService>().As<IFamilyMemberService>().InstancePerDependency();
            builder.RegisterType<FamilyMemberRepository>().As<IFamilyMemberRepository>().InstancePerDependency();

            builder.RegisterType<CountryService>().As<ICountryService>().InstancePerDependency();
            builder.RegisterType<CountryRepository>().As<ICountryRepository>().InstancePerDependency();

        }
    }
}
