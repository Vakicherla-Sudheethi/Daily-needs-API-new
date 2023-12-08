using System;
using System.Collections.Generic;
using System.Linq;
using DailyNeeds1.DTO;
using DailyNeeds1.Entities;
using DailyNeeds1.DTO;

namespace DailyNeeds1.Repo
{
    public class CategoryImpl : IRepo<CategoryDTO>
    {
        DailyNeedsDbContext ctx;

        public CategoryImpl(DailyNeedsDbContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(CategoryDTO item)
        {
            try
            {
                Category category = new Category
                {
                    CategoryName = item.CategoryName
                };

                ctx.categories.Add(category);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                var category = ctx.categories.Find(Id); 
                if (category != null)
                {
                    ctx.categories.Remove(category);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<CategoryDTO> GetAll()
        {
            var categories = ctx.categories
                .Select(c => new CategoryDTO
                {
                    CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName
                })
                .ToList();

            return categories;
        }

        public bool Update(CategoryDTO item)
        {
            try
            {
                var category = ctx.categories.Find(item.CategoryID);
                if (category != null)
                {
                    category.CategoryName = item.CategoryName;
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
