using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReactiveUI;
using ReactiveUI.Routing;
using Xunit;

namespace Foobar.ViewModels
{
    public interface IFooBarViewModel<out T> : IRoutableViewModel<T> {}

    public interface IBazViewModel<out T> : IRoutableViewModel<T> { }

    public class FooBarViewModel : ReactiveObject<FooBarViewModel>, IFooBarViewModel<FooBarViewModel>
    {
        public string UrlPathSegment { get { return "foo"; } }
        public IScreen HostScreen { get; private set; }

        public FooBarViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;
        }
    }

    public class BazViewModel : ReactiveObject<BazViewModel>, IBazViewModel<BazViewModel>
    {
        public string UrlPathSegment { get { return "foo"; } }
        public IScreen HostScreen { get; private set; }

        public BazViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;
        }
    }
}

namespace Foobar.Views
{
    using ViewModels;

    public class FooBarView : IViewFor<IFooBarViewModel<FooBarViewModel>> 
    {
        object IViewFor.ViewModel { get { return ViewModel; } set { ViewModel = (IFooBarViewModel<FooBarViewModel>)value; } }
        public IFooBarViewModel<FooBarViewModel> ViewModel { get; set; }
    }

    public interface IBazView : IViewFor<IBazViewModel<BazViewModel>> { }

    public class BazView : IBazView 
    {
        object IViewFor.ViewModel { get { return ViewModel; } set { ViewModel = (IBazViewModel<BazViewModel>)value; } }
        public IBazViewModel<BazViewModel> ViewModel { get; set; }
    }
}

namespace ReactiveUI.Routing.Tests
{
    using Foobar.Views;
    using Foobar.ViewModels;

    public class RxRoutingTests : IEnableLogger
    {
        [Fact]
        public void ResolveExplicitViewType()
        {
            var resolver = new ModernDependencyResolver();
            resolver.InitializeResolver();
            resolver.Register(() => new BazView(), typeof(IBazView));

            using (resolver.WithResolver()) {
                var fixture = new DefaultViewLocator();
                var vm = new BazViewModel(null);

                var result = fixture.ResolveView(vm);
                this.Log().Info(result.GetType().FullName);
                Assert.True(result is BazView);
            }
        }
    }
}
