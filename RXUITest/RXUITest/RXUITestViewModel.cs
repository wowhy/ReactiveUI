using System;
using ReactiveUI;

namespace RXUITest
{
    public class RXUITestViewModel : ReactiveObject
    {
        string theGuid;

        public string TheGuid
        {
            get { return theGuid; }
            set { this.RaiseAndSetIfChanged(ref theGuid, value); }
        }

        private ReactiveCommand generateCmd;

        public ReactiveCommand GenerateCmd
        {
            get
            {
                if (generateCmd == null)
                {
                    generateCmd = new ReactiveCommand(null);

                    generateCmd.Subscribe((x)=> TheGuid = Guid.NewGuid().ToString());
                }

                return generateCmd;
            }
        }

    }
}

