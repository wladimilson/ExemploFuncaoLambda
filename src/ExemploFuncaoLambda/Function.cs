using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using ExemploFuncaoLambda.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ExemploFuncaoLambda
{
    public class Function
    {
        private static readonly HttpClient client = new HttpClient();
        
        /// <summary>
        /// A simple function that takes a brazilian zip code and return the street name
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<string> FunctionHandlerAsync(string input, ILambdaContext context)
        {
            if(input != null){
                var streamTask = await client.GetStreamAsync($"https://viacep.com.br/ws/{input}/json/");
                var endereco = await JsonSerializer.DeserializeAsync<Endereco>(streamTask);
                return endereco.logradouro;
            }
            return "CEP não informado";
        }
    }
}
