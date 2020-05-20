﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Pages.Conference
{
    public class AddModel : PageModel
    {       
        public IApiClientService ApiClient { get; }

        [BindProperty]
        public ConferenceResponse Conference { get; set; }


        public AddModel(IApiClientService apiClientService)
        {
            ApiClient = apiClientService;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            Conference.ID = 0;
            ///TODO
            ///COnfigure the input of the Conference.Tags to be as a List<string>

            var result = ApiClient.CreateConferenceAsync(Conference).Result;
            if (result.Item1 == false)
                return RedirectToPage("/Error");

            return RedirectToPage($"/Conference/Index", new { conference_id = result.Item2 });
        }

    }
}

