using System;
using System.Linq;
using Ninject;
using Ninject.Modules;

namespace Danny.Ninject.CustomModuleLoader
{
    /// <summary>
    /// Allows loading all types inheriting from the LoadableModule class to be loaded into a Ninject kernel.
    /// </summary>
    public class NinjectModuleLoader : INinjectModuleLoader
    {
        /// <summary>
        /// Gets all module types inheriting from the TModule class. 
        /// Then proceeds to call LoadModule with the as TModule generic argument, loading the modules into the kernel.
        /// </summary>
        /// <typeparam name="TModule">Module type inheriting from LoadableModule</typeparam>
        /// <param name="kernel">The Ninject kernel to load the modules in.</param>
        public void LoadAllModules<TModule>(IKernel kernel) where TModule : LoadableModule
        {
            var moduleType = typeof(TModule);
            var method = typeof(NinjectModuleLoader).GetMethod("LoadModule");

            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(a => moduleType.IsAssignableFrom(a) && a.FullName != moduleType.FullName)
                .Foreach(module => method.MakeGenericMethod(module).Invoke(this, new []{kernel}));
        }

        /// <summary>
        /// Gets all types inheriting from the LoadableModule class. 
        /// Then proceeds to call LoadModule with the as TModule generic argument, loading the modules into the kernel.
        /// </summary>
        /// <param name="kernel">
        /// The Ninject kernel to load the modules in.
        /// </param>
        public void LoadAllModules(IKernel kernel)
        {
            LoadAllModules<LoadableModule>(kernel);
        }

        /// <summary>
        /// Load a module in the kernel
        /// </summary>
        /// <typeparam name="TModule">
        /// The INinjectModule type to load into the Ninject kernel.
        /// </typeparam>
        /// <param name="kernel">
        /// The Ninject kernel to load the module in.
        /// </param>
        public void LoadModule<TModule>(IKernel kernel)
            where TModule : INinjectModule, new()
        {
            kernel.Load<TModule>();
        }
    }
}
