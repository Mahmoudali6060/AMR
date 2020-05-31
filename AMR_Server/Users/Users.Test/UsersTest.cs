using Users.DataAccessLayer;
using DataBase.Entities;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using AutoMapper;
using System.Linq;

namespace Users.Test
{
    public class UsersTest
    {
        private readonly Mock<IUserDetailDAL> _mockUserDetailDAL;
        public UsersTest()
        {
            _mockUserDetailDAL = new Mock<IUserDetailDAL>();

            //IList<UserDetail> userDetail = new List<UserDetail>()
            //{
            //     new UserDetail
            //     {
            //        Id = 001,
            //        UserName="Mahmoud"
            //     },
            //     new UserDetail
            //     {
            //        Id = 002,
            //        UserName="Ali"
            //     }
            //};

            //DataSource dataSource = new DataSource()
            //{
            //    PageNumber = 1,
            //    PageSize = 3
            //};

            //_mockUserDetailDAL.Setup(repo =>
            //repo.GetAllUser(dataSource)).ReturnsAsync(userDetail.ToList());

            //_mockUserDetailDAL.SetupAllProperties();

        }

        [Fact]
        public async Task GetAllUserTest()
        {
            //Arrange >>> Unit Cases
            //int rowNumbers = 2;
            //----------------------------------------------------------------------

            //Act >>> Real code excuution
            //DataSource dataSource = new DataSource()
            //{
            //    PageNumber = 1,
            //    PageSize = 2
            //};
            //var userDetails = await _mockUserDetailDAL.Object.GetAllUser(dataSource);
            //_mockUserDetailDAL.Setup(x => x.GetAllUser(dataSource).Result.Count()).Returns(2);
            //Assert.Equal(rowNumbers, userDetails.Count);

            //-----------------------------------------------------------------------

            _mockUserDetailDAL.Setup(x => x.Test()).Returns(1);
            //var num = _mockUserDetailDAL.Object.Test();
            //Assert.Equal(1, num);

            //Assert  >>>Comparing
            //Assert.Equal(rowNumbers, userDetailList.Count);


        }
    }
}
