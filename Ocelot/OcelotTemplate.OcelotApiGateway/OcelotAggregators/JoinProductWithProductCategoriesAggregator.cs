using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ocelot.Middleware;
using Ocelot.Multiplexer;

namespace OcelotTemplate.OcelotApiGateway.OcelotAggregators;

public class JoinProductWithProductCategoriesAggregator : IDefinedAggregator
{
    public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
    {
        
        

        //Get Products 
        var t = responses[0];
      
        var responseBody = await t.Items.DownstreamResponse().Content.ReadAsStringAsync();
        var jsonSerializerOptions = new JsonSerializerOptions()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };
        var products = JsonSerializer.Deserialize<List<ProductViewModel>>(responseBody,jsonSerializerOptions);



     
       
         responseBody =await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();

         var productCategories =
             JsonSerializer.Deserialize<List<ProductCategoryViewModel>>(responseBody, jsonSerializerOptions);


        var resultContent = products?.Join(productCategories,
            p => p.Fk_ProductCategoryId,
            c => c.Id,
            (p, c) => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Fk_ProductCategoryId = p.Fk_ProductCategoryId,
                ProductCategory = c
            })
            .ToList();

        StringContent stringContent = new StringContent(JsonSerializer.Serialize(resultContent))
        {
            Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
        };
        

        var downstreamResponse = new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");


        return downstreamResponse;
    }
}

