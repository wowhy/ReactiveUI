using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Shell;
using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Mobile;
using MobileSample_WP8.Views;

namespace MobileSample_WP8.ViewModels
{
    [DataContract]
    public class AppBootstrapper : ReactiveObject, IApplicationRootState
    {
        [DataMember] RoutingState _Router;

        public IRoutingState Router {
            get { return _Router; }
            set { _Router = (RoutingState) value; } // XXX: This is dumb.
        }

        public AppBootstrapper()
        {
            Router = new RoutingState();

            var resolver = RxApp.MutableResolver;
            resolver.Register(() => new TestPage1ViewModel(this), typeof(TestPage1ViewModel));
            resolver.Register(() => new TestPage1View(), typeof(IViewFor<TestPage1ViewModel>));

            resolver.RegisterConstant(this, typeof(IApplicationRootState));
            resolver.RegisterConstant(this, typeof(IScreen));

            Router.Navigate.Execute(new TestPage1ViewModel(this));
        }
    }
}
