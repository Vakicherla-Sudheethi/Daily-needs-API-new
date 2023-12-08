using DailyNeeds1.Entities;
using DailyNeeds1.Repo;
using DailyNeeds1.DTO;
using System.Collections.Generic;
using System.Linq;

namespace DailyNeeds1.Repo
{
    public class CartImpl : IRepo<CartDTO>
    {
        private readonly DailyNeedsDbContext _context;

        public CartImpl(DailyNeedsDbContext context)
        {
            _context = context;
        }

        public bool Add(CartDTO item)
        {
            Cart cartNew = new Cart();
            cartNew.UserID = item.UserID;
            cartNew.ProductID = item.ProductID;
            cartNew.Quantity = item.Quantity;
            _context.cartss.Add(cartNew);
            // _context.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        { 
            var cartDelete = _context.cartss.Find(Id);

            if (cartDelete == null)
                return false;

            _context.cartss.Remove(cartDelete);
            // _context.SaveChanges();
            return true;
        }

        public List<CartDTO> GetAll()
        {
            var result = _context.cartss
                .Select(c => new CartDTO()
                {
                    CartID = c.CartID,
                    UserID = c.UserID,
                    ProductID = c.ProductID,
                    Quantity = c.Quantity
                    
                })
                .ToList();
            return result;
        }

        //newly-added
        public List<ProductCartDTO> GetAllCartsByUser(int userID)
        {
            var result =
            (
                from p in _context.products
                join
                c in _context.cartss
                on
                p.ProductID equals c.ProductID
                join o in _context.offers
                on p.ProductID equals o.ProductID
                where c.UserID==userID
                select new ProductCartDTO()
                {
                    CartID = c.CartID,
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    OfferPercentage=o.OfferPercentage,
                    Quantity = c.Quantity,
                }


            )
            .ToList();
            return result;

        }

        public bool Update(CartDTO item)
        {
            var cartUpdate = _context.cartss.Find(item.CartID);

            if (cartUpdate == null)
                return false;

            cartUpdate.UserID = item.UserID;
            cartUpdate.ProductID = item.ProductID;
            cartUpdate.Quantity = item.Quantity;
            // _context.SaveChanges();

            return true;
        }

        
        public CartDTO GetByCartId(int cartId)
        {
            var cart = _context.cartss.FirstOrDefault(c => c.CartID == cartId);

            if (cart == null)
                return null;

            var cartDTO = new CartDTO()
            {
                CartID = cart.CartID,
                UserID = cart.UserID,
                ProductID = cart.ProductID,
                Quantity = cart.Quantity
            };

            return cartDTO;
        }
    }
}
