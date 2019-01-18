using JMAShop.Controllers;
using JMAShop.Models;
using JMAShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using JMAShopTest.Model;

namespace JMAShopTest
{

    public class ItemManagementControllerTests
    {
        [Fact]
        public void Index_ReturnsAViewResult_ContainsAllItems()
        {
            //arrange
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var mockItemRepository = RepositoryMocks.GetItemRepository();

            var itemManagementController = new ItemManagementController(mockItemRepository.Object, mockCategoryRepository.Object);

            //act
            var result = itemManagementController.Index();

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var items = Assert.IsAssignableFrom<IEnumerable<Item>>(viewResult.ViewData.Model);
            Assert.Equal(10, items.Count());
        }

        [Fact]
        public void AddItem_Redirects_ValidItemViewModel()
        {
            //arrange
            var itemEditViewModel = new ItemEditViewModel();
            var mockItemRepository = RepositoryMocks.GetItemRepository();
            var item = mockItemRepository.Object.GetItemById(1);
            itemEditViewModel.Item = item;
            itemEditViewModel.CategoryId = 1;

            var mockCategoryRepository = new Mock<ICategoryRepository>();

            var itemManagementController = new ItemManagementController(mockItemRepository.Object, mockCategoryRepository.Object);

            //act
            var result = itemManagementController.AddItem(itemEditViewModel);

            //assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void AddItem_ReturnsViewResultWithViewModel_InvalidItemViewModel()
        {
            //arrange
            var itemEditViewModel = new ItemEditViewModel();
            var mockItemRepository = RepositoryMocks.GetItemRepository();
            var item = mockItemRepository.Object.GetItemById(1);
            item.IsItemOfTheWeek = true;
            item.InStock = false;

            itemEditViewModel.Item = item;
            itemEditViewModel.CategoryId = 1;

            var mockCategoryRepository = new Mock<ICategoryRepository>();

            var itemManagementController = new ItemManagementController(mockItemRepository.Object, mockCategoryRepository.Object);

            //act
            var result = itemManagementController.AddItem(itemEditViewModel);

            //assert
            var viewResult = Assert.IsType<IActionResult>(result);
            Assert.NotNull(viewResult);
          //  Assert.True(string.IsNullOrEmpty(viewResult));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void AddItem_ReturnsViewResultWithViewModel_InvalidItemViewModel_NegativePrice(int price)
        {
            //arrange
            var itemEditViewModel = new ItemEditViewModel();
            var mockItemRepository = RepositoryMocks.GetItemRepository();
            var item = mockItemRepository.Object.GetItemById(1);
            item.IsItemOfTheWeek = true;
            item.InStock = true;
            item.Price = price;
            itemEditViewModel.Item = item;
            itemEditViewModel.CategoryId = 1;

            var mockCategoryRepository = new Mock<ICategoryRepository>();

            var itemManagementController = new ItemManagementController(mockItemRepository.Object, mockCategoryRepository.Object);

            //act
            var result = itemManagementController.AddItem(itemEditViewModel);

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult.Model);
            Assert.True(string.IsNullOrEmpty(viewResult.ViewName));

        }
    }
}
