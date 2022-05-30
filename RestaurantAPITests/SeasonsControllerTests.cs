using IEAPTLab2.Controllers;
using IEAPTLab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPITests
{
    public class SeasonsControllerTests
    {
        private Season _season;
        private SeasonsController _controller;
        private void SetUp()
        {
            var context = CreateContext();
            _controller = new SeasonsController(context);
            _season = new Season
            {
                Name = "Summer",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Description = "summer season"
            };
        }
        private RestaurantAPIContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<RestaurantAPIContext>().UseInMemoryDatabase("RestaursntAPI");
            RestaurantAPIContext context = new RestaurantAPIContext(options.Options);
            return context;
        }
        [Fact]
        public void Create_Season_Ok()
        {
            SetUp();

            var responce = _controller.Create(_season);

            Assert.IsType<Task<IActionResult>>(responce);
        }
        [Fact]
        public void Index_Ok()
        {
            SetUp();

            var responce = _controller.Index();

            Assert.IsType<Task<IActionResult>>(responce);
        }
        [Fact]
        public void Edit_Season_Ok()
        {
            SetUp();
            _controller.Create(_season);
            _season.Name = "Fall";
            var responce = _controller.Edit(_season);

            Assert.IsType<Task<IActionResult>>(responce);
        }
        [Fact]
        public void Delete_Season_Ok()
        {
            SetUp();
            _controller.Create(_season);
            var responce = _controller.Delete(_season.Id);

            Assert.IsType<Task<IActionResult>>(responce);
        }
    }
}