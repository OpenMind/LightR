using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightR.Services.Logging;
using Magnum.Extensions;
using Magnum.TestFramework;
using NUnit.Framework;

namespace LightR.TestFramework.Fixtures
{
    [TestFixture]
    public class AbstractTestFixture
    {
        [TestFixtureSetUp]
        public void AbstractTestFixtureSetup()
        {
            OutputTestName(GetType());

            _timer = Stopwatch.StartNew();
        }

        [TestFixtureTearDown]
        public void AbstractTestFixtureTeardown()
        {
            if (_timer != null)
            {
                _timer.Stop();
                Log.InfoFormat("Elapsed Time: {0}ms", _timer.ElapsedMilliseconds);
            }

            Log.Info("");
        }

        private Stopwatch _timer;

        protected static readonly ILog Log;

        static AbstractTestFixture()
        {
            Log = Logger.Get("Test");
        }

        private void OutputTestName(Type type)
        {
            string prefix = "";
            int depth = -1;

            GetTestStack(type)
                .Where(x => x.GetAttribute<ScenarioAttribute>() != null)
                .Select(x => x.Name.Replace("_", " "))
                .Each(x =>
                {
                    string s = x.Split(' ')[0];
                    if (s != prefix)
                    {
                        depth++;
                        prefix = s;
                    }
                    else
                    {
                        x = "And" + x.Substring(prefix.Length);
                    }

                    Log.Info(new string(' ', depth * 4) + x);
                });
        }

        private static IEnumerable<Type> GetTestStack(Type type)
        {
            if (type.BaseType != null)
            {
                foreach (Type next in GetTestStack(type.BaseType))
                {
                    yield return next;
                }
            }

            yield return type;
        }
    }
}
