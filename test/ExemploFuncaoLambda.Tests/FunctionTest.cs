using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using ExemploFuncaoLambda;

namespace ExemploFuncaoLambda.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestToUpperFunction()
        {
            var function = new Function();
            var context = new TestLambdaContext();
            var rua = function.FunctionHandlerAsync("01001000", context).Result;

            Assert.Equal("Praça da Sé", rua);//01311-100
        }
    }
}
