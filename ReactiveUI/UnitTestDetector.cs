using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUI
{
    public class UnitTestDetector
    {
        /// <summary>
        /// Private constructor to prevent instantiation.
        /// </summary>
        private UnitTestDetector() { }

        static bool? isInUnitTestRunner;
        
        /// <summary>
        /// Detects if the app is running in a Unit Test runner by trying to load
        /// the TestScheduler.
        /// </summary>
        /// <param name="testType">Type of the test.</param>
        /// <returns></returns>
        public static bool IsInUnitTestRunner(string testType = null)
        {
            if (!isInUnitTestRunner.HasValue) {
                // assuming Microsoft.Reactive.Testing is always used
                string testAQN = testType ?? "ReactiveUI.Tests.RxAppTest, ReactiveUI.Tests_Net45";
                isInUnitTestRunner = Type.GetType(testAQN, false) != null;
            }
            return isInUnitTestRunner.GetValueOrDefault(false);
        }
    }
}
