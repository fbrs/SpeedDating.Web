using System;
using System.Collections.Generic;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v3;

namespace SpeedDating.Web.Services
{
    public class WoocommerceService : IWoocommerceService
    {


        public ProductCategory CreateCategory(ProductCategory category)
        {
            var woocommerce = InitWCObject();

            var wooCategory = woocommerce.Category.Add(category).Result;

            return wooCategory;
        }

        public ProductAttribute CreateProductAttribute(ProductAttribute productAttribute)
        {
            var woocommerce = InitWCObject();

            var wooProductAttribute = woocommerce.Attribute.Add(productAttribute).Result;

            
            return wooProductAttribute;
        }

        public List<ProductAttributeTerm> CreateProductAttributeTerms(List<ProductAttributeTerm> terms, int productAttributeId)
        {
            var woocommerce = InitWCObject();

            List<ProductAttributeTerm> wooTerms = new List<ProductAttributeTerm>();

            foreach (var term in terms)
            {
                var wooTerm = woocommerce.Attribute.Terms.Add(term, productAttributeId).Result;

                wooTerms.Add(wooTerm);

                //save to db not sure yet
            }

            return wooTerms;
        }

        public List<Product> GetAllProducts()
        {
            var woocomerce = InitWCObject();

            var products = woocomerce.Product.GetAll().Result;

            return products;
        }

        public List<Order> GetOrdersInDateRange(DateTime? from = null, DateTime? to = null)
        {
            var woocommerce = InitWCObject();

            var orders = woocommerce.Order.GetAll().Result;

            

            return orders;
        }


        private WCObject InitWCObject()
        {
            RestAPI rest = new RestAPI("http://speedrande.cz/wp-json/wc/v3/", "ck_f7cac2309cddac52a8d4ee02a80081e5cce180be", "cs_adda6c0249faf14510d93213aea5fcdd60e55ab1");

            WCObject woocommerce = new WCObject(rest);

            return woocommerce;
        }
    }
}
