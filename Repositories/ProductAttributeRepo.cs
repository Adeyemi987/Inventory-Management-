//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using InventoryBeginners.Data;
//using InventoryBeginners.Interfaces;
//using InventoryBeginners.Models;
//using Microsoft.EntityFrameworkCore;
//using CodesByAniz.Tools;

//namespace InventoryBeginners.Repositories
//{
//    public class ProductAttributeRepo : IProductAttribute
//    {
//        private readonly InventoryContext _context; // for connecting to efcore.
//        public ProductAttributeRepo(InventoryContext context) // will be passed by dependency injection.
//        {
//            _context = context;
//        }
//        public ProductAttribute Create(ProductAttribute productAttribute)
//        {
//            _context.ProductAttributes.Add(productAttribute);
//            _context.SaveChanges();
//            return productAttribute;
//        }

//        public ProductAttribute Delete(ProductAttribute productAttribute)
//        {
//            _context.ProductAttributes.Attach(productAttribute);
//            _context.Entry(productAttribute).State = EntityState.Deleted;
//            _context.SaveChanges();
//            return productAttribute;
//        }

//        public ProductAttribute Edit(ProductAttribute productAttribute)
//        {
//            _context.ProductAttributes.Attach(productAttribute);
//            _context.Entry(productAttribute).State = EntityState.Modified;
//            _context.SaveChanges();
//            return productAttribute;
//        }


//        private List<ProductAttribute> DoSort(List<ProductAttribute> items, string SortProperty, SortOrder sortOrder)
//        {

//            if (SortProperty.ToLower() == "name")
//            {
//                if (sortOrder == SortOrder.Ascending)
//                    items = items.OrderBy(n => n.Name).ToList();
//                else
//                    items = items.OrderByDescending(n => n.Name).ToList();
//            }           

//            return items;
//        }

//        public PaginatedList<ProductAttribute> GetItems(AttributeType attributeType, string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
//        {
//            List<ProductAttribute> items;

//            if (SearchText != "" && SearchText != null)
//            {
//                items = _context.ProductAttributes.Where(n => n.Name.Contains(SearchText) && n.AttributeId==attributeType).ToList();
//            }
//            else
//                items = _context.ProductAttributes.Where(n=> n.AttributeId == attributeType).ToList();

//            items = DoSort(items, SortProperty, sortOrder);

//            PaginatedList<ProductAttribute> retItems = new PaginatedList<ProductAttribute>(items, pageIndex, pageSize);

//            return retItems;
//        }

//        public ProductAttribute GetItem(int id)
//        {
//            ProductAttribute item = _context.ProductAttributes.Where(u => u.Id == id).FirstOrDefault();
//            return item;
//        }

//        public bool IsItemExists(string name,AttributeType attributeType)
//        {
//            int ct = _context.ProductAttributes.Where(n => n.Name.ToLower() == name.ToLower() && n.AttributeId==attributeType).Count();
//            if (ct > 0)
//                return true;
//            else
//                return false;
//        }

//        public bool IsItemExists(string name, int Id, AttributeType attributeType)
//        {
//            int ct = _context.ProductAttributes.Where(n => n.Name.ToLower() == name.ToLower() && n.Id != Id && n.AttributeId == attributeType).Count();
//            if (ct > 0)
//                return true;
//            else
//                return false;
//        }

//    }
//}
