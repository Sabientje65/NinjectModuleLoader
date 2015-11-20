using Ninject.Modules;

namespace Danny.Ninject.CustomModuleLoader
{
    /// <summary>
    /// Abstract class inheriting from NinjectModule allowing it to be loaded into a Ninject kernel.
    /// </summary>
    public abstract class LoadableModule : NinjectModule{};
}
