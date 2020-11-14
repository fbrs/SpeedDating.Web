using System;
using System.Collections.Generic;
using WooCommerceNET.WooCommerce.v3;

namespace SpeedDating.Web.Services
{
    public interface IWoocommerceService
    {
        List<Order> GetOrdersInDateRange(DateTime? from = null, DateTime? to = null);

        List<Product> GetAllProducts();

        ProductCategory CreateCategory(ProductCategory category);

        ProductAttribute CreateProductAttribute(ProductAttribute productAttribute);

        List<ProductAttributeTerm> CreateProductAttributeTerms(List<ProductAttributeTerm> terms, int productAttributeId);
    }
}
