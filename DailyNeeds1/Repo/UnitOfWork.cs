using DailyNeeds1.Entities;
using DailyNeeds1.Repo;
using DailyNeeds1.Repo;

namespace DailyNeeds1.Repo
{
    public class UnitOfWork
    {
        DailyNeedsDbContext context = null;
        CityImpl cityImpl = null;
        LocationImpl locationImpl = null;
        CategoryImpl categoryImpl = null;
        RoleImpl roleImpl = null;
        UserImpl userImpl = null;
        //RegistrationImpl registrationImpl = null;
        LoginImpl loginImpl = null;
        ProductImpl productImpl = null;
        CartImpl cartImpl = null;
        OfferImpl offerImpl = null;


        public UnitOfWork(DailyNeedsDbContext ctx)
        {
            context = ctx;
        }

        public CityImpl CityImplObject
        {
            get
            {
                if (cityImpl == null)
                    cityImpl = new CityImpl(context);
                return cityImpl;
            }
        }

        public LocationImpl LocationImplObject
        {
            get
            {
                if (locationImpl == null)
                    locationImpl = new LocationImpl(context);
                return locationImpl;
            }
        }

        public CategoryImpl CategoryImplObject
        {
            get
            {
                if (categoryImpl == null)
                    categoryImpl = new CategoryImpl(context);
                return  categoryImpl;
            }
        }

        public RoleImpl RoleImplObject
        {
            get
            {
                if(roleImpl == null)
                    roleImpl = new RoleImpl(context);
                return roleImpl;

            }
        }

        public UserImpl UserImplObject
        {
            get
            {
                if (userImpl == null)
                    userImpl = new UserImpl(context);
                return userImpl;

            }
        }

        //public RegistrationImpl RegistrationImplObject
        //{
        //    get
        //    {
        //        if (registrationImpl == null)
        //            registrationImpl = new RegistrationImpl(context);
        //        return registrationImpl;


        //    }
        //}

        public LoginImpl LoginImplObject
        {
            get
            {
                if(loginImpl == null)
                    loginImpl = new LoginImpl(context);
                return loginImpl;
            }
        }

        public ProductImpl ProductImplObject
        {
            get
            {
                if(productImpl == null)
                    productImpl = new ProductImpl(context);
                return productImpl;
            }
        }

        public CartImpl CartImplObject
        {
            get
            {
                if(cartImpl == null)
                    cartImpl = new CartImpl(context);
                return cartImpl;
            }
        }

        public OfferImpl OfferImplObject
        {
            get
            {
                if(offerImpl == null)
                    offerImpl = new OfferImpl(context);
                return offerImpl;
            }
        }


        public void SaveAll()
        {
            if (context != null)
            {
                context.SaveChanges();
            }
        }
    }
}