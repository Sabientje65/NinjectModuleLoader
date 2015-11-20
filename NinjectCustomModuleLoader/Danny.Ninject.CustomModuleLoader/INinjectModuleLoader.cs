using Ninject;
using Ninject.Modules;

namespace Danny.Ninject.CustomModuleLoader
{
    /// <summary>
    /// Allows loading all types inheriting from the LoadableModule class to be loaded into a Ninject kernel.
    /// </summary>
    public interface INinjectModuleLoader
    {
        /// <summary>
        /// Gets all types inheriting from the LoadableModule class. 
        /// Then proceeds to call LoadModule with the as TModule generic argument, loading the modules into the kernel.
        /// </summary>
        /// <param name="kernel">
        /// The Ninject kernel to load the modules in.
        /// </param>
        void LoadAllModules(IKernel kernel);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModule">
        /// The INinjectModule type to load into the Ninject kernel.
        /// </typeparam>
        /// <param name="kernel">
        /// The Ninject kernel to load the module in.
        /// </param>
        void LoadModule<TModule>(IKernel kernel) where TModule : INinjectModule, new();
    }
}
