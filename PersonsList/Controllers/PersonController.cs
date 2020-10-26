using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonsList.Data;
using PersonsList.Models;
using PersonsList.Models.SortingModels;
using PersonsList.Models.SortingModels.Comparers;
using PersonsList.Models.SortingModels.Sorters;
using System.Collections.Generic;
using System.Linq;

namespace TestingLab.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly PersonDbContext _personDbContext;

        public PersonController(PersonDbContext personDbContext, UserManager<IdentityUser> userManager)
        {
            _personDbContext = personDbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            List<PersonDto> people = _personDbContext.People                
                .Where(p => p.UserId == _userManager.GetUserId(User))
                .Select(ToDto)
                .ToList();

            return View(people);
        }

        public IActionResult Sort(int method, int field, SortOrder order)
        {
            List<PersonDto> people = _personDbContext.People
                .Where(p => p.UserId == _userManager.GetUserId(User))
                .Select(ToDto)
                .ToList();

            return View("Index", GetSortedPeople(people, method, field, order));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonDto personDto)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person()
                {
                    UserId = _userManager.GetUserId(User),
                    Name = personDto.Name,
                    Surname = personDto.Surname,
                    Middlename = personDto.Middlename,
                    Email = personDto.Email,
                    Age = personDto.Age
                };

                _personDbContext.People.Add(person);
                _personDbContext.SaveChanges();
            }
            else
                return View();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Person person = _personDbContext.People
                .FirstOrDefault(p => p.Id == id);

            if (person != null)
            {
                PersonDto personDto = ToDto(person);
                return View(personDto);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(PersonDto personDto)
        {
            if (ModelState.IsValid)
            {
                Person person = _personDbContext.People
                    .FirstOrDefault(p => p.Id == personDto.Id);

                if (person != null)
                {
                    person.Name = personDto.Name;
                    person.Surname = personDto.Surname;
                    person.Middlename = personDto.Middlename;
                    person.Age = personDto.Age;
                    person.Email = personDto.Email;

                    _personDbContext.SaveChanges();
                }
            }
            else
                return View();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteSubmit(int id)
        {
            Person person = _personDbContext.People
                .FirstOrDefault(p => p.Id == id);

            if (person != null)
            {
                PersonDto personDto = ToDto(person);
                return View(personDto);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Person person = _personDbContext.People
                .FirstOrDefault(p => p.Id == id);

            if (person != null)
            {
                _personDbContext.People.Remove(person);
                _personDbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        private PersonDto ToDto(Person person)
        {
            return new PersonDto()
            {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname,
                Middlename = person.Middlename,
                Email = person.Email,
                Age = person.Age
            };
        }

        private List<PersonDto> GetSortedPeople(List<PersonDto> people, int method, int field, SortOrder order)
        {
            ISorter<PersonDto> sorter = null;

            switch (method)
            {
                case 1:
                    sorter = new BubbleSorter(GetComparer(field, order));
                    break;

                case 2:
                    sorter = new ShakerSorter(GetComparer(field, order));
                    break;

                case 3:
                    sorter = new InsertionSorter(GetComparer(field, order));
                    break;

                case 4:
                    sorter = new SelectionSorter(GetComparer(field, order));
                    break;

                case 5:
                    sorter = new MergeSorter(GetComparer(field, order));
                    break;

                default:
                    break;
            }           

            return sorter?.Sort(people).ToList() ?? people;
        }

        private ISortComparer<PersonDto> GetComparer(int field, SortOrder order)
        {
            ISortComparer<PersonDto> sortComparer = null;

            switch (field)
            {
                case 1:
                    sortComparer = new NameComparer() { Order = order };
                    break;

                case 2:
                    sortComparer = new SurnameComparer() { Order = order };
                    break;

                case 3:
                    sortComparer = new MiddlenameComparer() { Order = order };
                    break;

                case 4:
                    sortComparer = new EmailComparer() { Order = order };
                    break;

                case 5:
                    sortComparer = new AgeComparer() { Order = order };
                    break;

                default:
                    break;
            }

            return sortComparer ?? new NameComparer();
        }
    }
}
