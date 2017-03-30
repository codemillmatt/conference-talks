using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using Foodie.Backend.DataObjects;
using Foodie.Backend.Models;
using System.Security.Claims;

namespace Foodie.Backend.Controllers
{
    [Authorize]
    public class SecureRecipeController : TableController<SecureRecipe>
    {
        public string UserID
        {
            get
            {
                var principal = this.User as ClaimsPrincipal;
                return principal.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
        }
        public void ValidateOwner(string recipeId)
        {
            var result = Lookup(recipeId).Queryable.Where(sr => sr.UserId.Equals(UserID)).FirstOrDefault();

            if (result == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<SecureRecipe>(context, Request);
        }

        // GET tables/SecureRecipe
        public IQueryable<SecureRecipe> GetAllSecureRecipe()
        {
            return Query().Where(sr => sr.UserId.Equals(UserID));
        }

        // GET tables/SecureRecipe/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<SecureRecipe> GetSecureRecipe(string id)
        {
            return new SingleResult<SecureRecipe>(
                Lookup(id).Queryable.Where(sr => sr.UserId.Equals(UserID))
            );
        }

        // PATCH tables/SecureRecipe/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<SecureRecipe> PatchSecureRecipe(string id, Delta<SecureRecipe> patch)
        {
            ValidateOwner(id);
            return UpdateAsync(id, patch);
        }

        // POST tables/SecureRecipe
        public async Task<IHttpActionResult> PostSecureRecipe(SecureRecipe item)
        {
            item.UserId = UserID;

            SecureRecipe current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/SecureRecipe/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSecureRecipe(string id)
        {
            ValidateOwner(id);

            return DeleteAsync(id);
        }
    }
}
