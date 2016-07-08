using Ninject;

namespace CompanyProject.Domain
{
    public class CompositionRoot
    {
        private IKernel _container;
        public CompositionRoot()
        {
            _container = new StandardKernel();
        }
    }
}
