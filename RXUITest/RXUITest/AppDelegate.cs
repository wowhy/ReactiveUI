using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ReactiveUI;
using System.Threading;


namespace RXUITest
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register ("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        /// <summary>
        /// Ensure that the Monotouch linker won't optimize away the platform assembly
        /// </summary>
        Type ReactiveUICocoaPlatformKeepAlive = typeof(ReactiveUI.Cocoa.Registrations);

        // class-level declarations
        UIWindow window;
        RXUITestViewController viewController;
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // ReactiveUI initialization
            RxApp.Initialize();

            window = new UIWindow(UIScreen.MainScreen.Bounds);

            // make sure the app won't get terminated on the device due to hitting a breakpoint at startup 
            ThreadPool.QueueUserWorkItem((x)=>
            {
                NSThread.Current.InvokeOnMainThread(() => 
                {
                    viewController = new RXUITestViewController();
                    window.RootViewController = viewController;
                    window.MakeKeyAndVisible();
               });
            }, null);

                
            return true;
        }
    }
}

