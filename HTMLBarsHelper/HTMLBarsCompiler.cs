using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yahoo.Yui.Compressor;

namespace HTMLBarsHelper
{
    public class HTMLBarsCompiler
    {
        Jurassic.ScriptEngine Engine;
        JavaScriptCompressor Compressor;

        public HTMLBarsCompiler()
        {
            Engine = new Jurassic.ScriptEngine();
            var ass = typeof(HTMLBarsCompiler).Assembly;
            Engine.Execute("var exports = {};");
            Engine.Execute("var module = {};");
            Engine.Execute("var global = this;");
            Engine.Execute(GetEmbeddedResource("HTMLBarsHelper.Scripts.ember-template-compiler.js", ass));
            Engine.Execute("var precompile = module.exports.precompile;");
            Compressor = new JavaScriptCompressor();
        }

        public string Precompile(string template, bool compress)
        {
            var compiled = Engine.CallGlobalFunction<string>("precompile", template, false);
            if (compress)
            {
                compiled = Compressor.Compress(compiled);
            }
            return compiled;
        }

        public string GetEmbeddedResource(string resource, Assembly ass)
        {
            using (var reader = new StreamReader(ass.GetManifestResourceStream(resource)))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
