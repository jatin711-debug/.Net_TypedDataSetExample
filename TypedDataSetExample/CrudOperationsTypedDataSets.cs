using System;
using System.Collections.Generic;
using System.Text;

namespace TypedDataSetExample
{
    class CrudOperationsTypedDataSets
    {
        private DataSetTemplateTableAdapters.ProductsTableAdapter productsTableAdapter;
        private DataSetTemplate.ProductsDataTable dataTable;

        internal CrudOperationsTypedDataSets()
        {
            productsTableAdapter = new DataSetTemplateTableAdapters.ProductsTableAdapter();
            dataTable = new DataSetTemplate.ProductsDataTable();
        }

        public void GetAllProducts()
        {
            //productsTableAdapter.Fill(dataTable); or other way is
            dataTable = productsTableAdapter.GetProducts();
            foreach(var row in dataTable)
            {
                Console.WriteLine($"{row.ProductID} {row.ProductName}");
            }
        }

        public void GetProductById(int id)
        {
            dataTable = productsTableAdapter.GetProducts();
            var row = dataTable.FindByProductID(id);
            if(row != null)
            {
                Console.WriteLine($"{row.ProductID} {row.ProductName} {row.UnitPrice} {row.UnitsInStock}");
            }
            else
            {
                Console.WriteLine("Invalid ID");
            }
        }

        public void GetProductByName(string name)
        {
            dataTable = productsTableAdapter.GetProductByName(name);
            if(dataTable.Count > 0)
            {
                var row = dataTable[0];
                Console.WriteLine($"{row.ProductID} {row.ProductName} {row.UnitPrice} {row.UnitsInStock}");
            }
        }

        public void InsertProduct(string name,int price,short quantity)
        {
            productsTableAdapter.Insert(name, price, quantity);
        }

        public void UpdateProduct(int id,string name, int price, short quantity)
        {
            productsTableAdapter.Update(name, price, quantity,id);
        }

        public void DeleteProduct(int id)
        {
            productsTableAdapter.Delete(id);
        }
    }
}
