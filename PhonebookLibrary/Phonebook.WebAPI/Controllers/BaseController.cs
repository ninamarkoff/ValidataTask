namespace Phonebook.WebAPI.Controllers
{
    using System.Web.Http;
    using Models.Contracts;

    public class BaseController : ApiController
    {
        protected IPhonebookData data;

        public BaseController(IPhonebookData data)
        {
            this.data = data;
        }
    }
}