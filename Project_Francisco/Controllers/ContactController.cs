using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Project_Francisco.Models.DAO;
using Project_Francisco.Models.DTO;

namespace Project_Francisco.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactDao _contactDao = new ContactDao();
        private readonly string _apiUrl = "https://saacapps.com/payout/contact.php";
        private readonly string _token = "b951c19c7e115f5a0c2f502635541937";

        public async Task<ActionResult> Index()
        {
            List<ContactDto> contacts = await _contactDao.GetContactsAsync(_apiUrl, _token);
            return View(contacts);
        }

        public async Task<ActionResult> DetailsByEmail(string email)
        {
            ContactDto contact = await _contactDao.GetContactByEmailAsync(_apiUrl, _token, email);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ContactDto newContact)
        {
            if (ModelState.IsValid)
            {
                bool success = await _contactDao.CreateContactAsync(_apiUrl, _token, newContact);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(newContact);
        }
    }
}