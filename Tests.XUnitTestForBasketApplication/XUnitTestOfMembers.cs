#region Added Project References and General Usings
using Xunit;
using System;
using Managers.ManagerOfBasketApplication.Abstracts;
using Managers.ManagerOfBasketApplication.Concretes;
#endregion Added Project References and General Usings

namespace Tests.XUnitTestForBasketApplication
{
    public class XUnitTestOfMembers
    {
        #region Private Readonly Properties
        private readonly IManagerOfMembers ManagerOfMembers;
        #endregion Private Readonly Properties


        #region Constructors
        public XUnitTestOfMembers()
        {
            this.ManagerOfMembers = new ManagerOfMembers();
        }
        #endregion Constructors


        #region Test Functions
        [Fact]
        public void FetchMemberByInvalidId()
        {
            var resultToReturnFromFetchMemberId = this.ManagerOfMembers.FetchMemberById(idOfMember: Guid.Empty);
        }

        [Fact]
        public void FetchMemberByWrongMemberId()
        {
            var resultToReturnFromFetchMemberId = this.ManagerOfMembers.FetchMemberById(idOfMember: Guid.Parse(input: "1e4bca33-a260-4841-95e0-5eeb42a37c78"));
        }

        [Fact]
        public void FetchMemberById()
        {
            var resultToReturnFromFetchMemberId = this.ManagerOfMembers.FetchMemberById(idOfMember: Guid.Parse(input: "4e2bd134-1a19-40bf-b480-b85c59bde0f0"));
            Assert.True(condition: resultToReturnFromFetchMemberId.SuccessInformation.IsResultSuccessful);
        }
        #endregion Test Functions
    }
}
