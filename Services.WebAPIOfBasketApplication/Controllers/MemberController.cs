#region Added Project References and General Usings
using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Managers.ManagerOfBasketApplication.Abstracts;
#endregion Added Project References and General Usings

namespace Services.WebAPIOfBasketApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(contentType: MediaTypeNames.Application.Json)]
    public class MemberController : ControllerBase
    {
        #region Global Private Readonly Properties
        private readonly IManagerOfMembers ManagerOfMembers;
        #endregion Global Private Readonly Properties


        #region Constructors
        public MemberController(IManagerOfMembers managerOfMembers)
        {
            this.ManagerOfMembers = managerOfMembers;
        }
        #endregion Constructors


        #region Public Service Functions

        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [HttpPost(Name = "{memberId:guid}"), Route(template: "fetch-any-member-by-member-id")]
        public IActionResult FetchAnyMemberByMemberId([FromBody]Guid memberId)
        {
            var resultFromFetchAnyMemberById = this.ManagerOfMembers
                                                   .FetchMemberById(idOfMember: memberId);

            return StatusCode(statusCode: StatusCodes.Status200OK,
                              value: resultFromFetchAnyMemberById);
        }

        #endregion Public Service Functions
    }
}