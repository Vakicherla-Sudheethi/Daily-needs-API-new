using System;
using System.Collections.Generic;
using System.Linq;
using DailyNeeds1.DTO;
using DailyNeeds1.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyNeeds1.Repo
{
    public class OfferImpl : IRepo<OfferDTO>
    {
        private DailyNeedsDbContext ctx;

        public OfferImpl(DailyNeedsDbContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(OfferDTO item)
        {
            try
            {
                Offer offer = new Offer
                {
                    ProductID = item.ProductID,
                    OfferPercentage = item.OfferPercentage
                };

                ctx.offers.Add(offer);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int offerId)
        {
            try
            {
                var offer = ctx.offers.Find(offerId);
                if (offer != null)
                {
                    ctx.offers.Remove(offer);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Handle exception/log if necessary
                return false;
            }
        }

        public List<OfferDTO> GetAll()
        {
            var offers = ctx.offers
                .Select(o => new OfferDTO
                {
                    OfferId = o.OfferId,
                    ProductID = o.ProductID,
                    OfferPercentage = o.OfferPercentage
                })
                .ToList();

            return offers;
        }

        public bool Update(OfferDTO item)
        {
            try
            {
                var offer = ctx.offers.Find(item.OfferId);
                if (offer != null)
                {
                    offer.ProductID = item.ProductID;
                    offer.OfferPercentage = item.OfferPercentage;
                    // Update other relevant fields
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Handle exception/log if necessary
                return false;
            }
        }
        //newly-added
        public List<ProductOfferDTO> GetAllProductOffers(int locationId)
        {
            var result = (
            from p in ctx.products
            join
            o in ctx.offers
            on
            p.ProductID equals o.ProductID
            where p.LocId == locationId
            select new ProductOfferDTO()
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                Price = p.Price,
                OfferPercentage = o.OfferPercentage,
                LocId=p.LocId,
            }
            )
            .ToList();

            return result;
        }
    }
}

