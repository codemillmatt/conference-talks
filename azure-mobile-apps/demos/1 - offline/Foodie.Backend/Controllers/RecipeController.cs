using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using Foodie.Backend.DataObjects;
using Foodie.Backend.Models;

namespace Foodie.Backend.Controllers
{
    public class RecipeController : TableController<Recipe>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Recipe>(context, Request);
        }

        // GET tables/Recipe
        public IQueryable<Recipe> GetAllRecipes()
        {
            return Query();
        }

        // GET tables/Recipe/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Recipe> GetRecipe(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Recipe/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Recipe> PatchRecipe(string id, Delta<Recipe> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/Recipe
        public async Task<IHttpActionResult> PostRecipe(Recipe item)
        {
            Recipe current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Recipe/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteRecipe(string id)
        {
            return DeleteAsync(id);
        }
    }
}