using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ReactiveUI;

namespace RXUITest
{
    public partial class RXUITestViewController : UIViewController,
        IViewFor<RXUITestViewModel>, IViewFor
    {
        public RXUITestViewController () : base ("RXUITestViewController", null)
        {
            ViewModel = new RXUITestViewModel();
        }

        #region IViewFor implementation

        public RXUITestViewModel ViewModel { get; set; }

        #endregion

        #region IViewFor implementation

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (RXUITestViewModel) value; }
        }

        #endregion

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
            
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            this.Bind(ViewModel, (vm)=> vm.TheGuid, (view) => view.TheGuid.Text);
            this.BindCommand(ViewModel, (vm)=> vm.GenerateCmd, (view) => view.GenerateButton);
        }

        public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
        {
            // Return true for supported orientations
            return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
        }
    }
}

