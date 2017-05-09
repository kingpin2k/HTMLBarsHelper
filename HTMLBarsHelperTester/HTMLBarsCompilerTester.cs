using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HTMLBarsHelper;

namespace HTMLBarsHelperTester
{
    [TestClass]
    public class HandlebarsCompilerTester
    {
        [TestMethod]
        public void TestCompiler()
        {
            //lazy test
            var hc = new HTMLBarsCompiler();
            var template = hc.Precompile("asdf {{asdf}}", false);
            Assert.IsNotNull(template);
            Assert.IsTrue(template.IndexOf("asdf") > 0);
        }

        [TestMethod]
        public void TestAction()
        {
            //another lazy test
            var hc = new HTMLBarsCompiler();
            var template = hc.Precompile("asdf {{asdf}} <div {{action 'hello'}}>goodbye</div>", false);
            Assert.IsNotNull(template);
            Assert.IsTrue(template.IndexOf("hello") > 0);
        }
    }
}
