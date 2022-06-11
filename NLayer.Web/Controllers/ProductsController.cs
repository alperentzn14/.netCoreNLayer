using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        private readonly ICategoryService _category;
        private readonly IMapper _mapper;


        public ProductsController(IProductService service,ICategoryService category,IMapper mapper)
        {
            _service = service;
            _category = category;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
         
            return View(await _service.GetProductsWithCategory());
        }

        public async Task<IActionResult> Save()
        {
            var categories = await _category.GetAllAsync();
            var categoriesDto = _mapper.Map <List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto,"Id","Name");
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
        
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<Product>(productDto));
                return RedirectToAction(nameof(Index));
            }
            var categories = await _category.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();
        }
    }
}
