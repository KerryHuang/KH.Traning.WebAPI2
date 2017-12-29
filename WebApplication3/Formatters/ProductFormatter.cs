using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.Formatters
{
    public class ProductFormatter : BufferedMediaTypeFormatter
    {
        public ProductFormatter()
        {
            // 加入 "text/csv" 到支援清單
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            if (type == typeof(Products))
            {
                return true;
            }
            else
            {
                Type enumerableType = typeof(IEnumerable<Products>);
                return enumerableType.IsAssignableFrom(type);
            }
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            using (var writer = new StreamWriter(writeStream))
            {
                // 集合
                var products = value as IEnumerable<Products>;
                if (products != null)
                {
                    foreach (var product in products)
                    {
                        WriteItem(product, writer);
                    }
                }
                else
                {
                    // 單一
                    var singleProduct = value as Products;
                    if (singleProduct == null)
                    {
                        throw new InvalidOperationException("Cannot serialize type");
                    }
                    WriteItem(singleProduct, writer);
                }
            }
        }

        // 將 Products 物件序列化 CSV 格式 
        private void WriteItem(Products product, StreamWriter writer)
        {
            writer.WriteLine("{0},{1},{2},{3}",
                            Escape(product.ProductID),
                            Escape(product.ProductName),
                            Escape(product.CategoryID),
                            Escape(product.UnitPrice));
        }

        // CSV格式 非常簡單，它是使用“，”（逗號）來分隔資料項目。
        // 如果碰到一些特別符號可能讓CSV輸出格式出現問題，例如，字串內有“，”（逗點）。
        static char[] _specialChars = new char[] { ',', '\n', '\r', '"' };
        private string Escape(object o)
        {
            if (o == null)
            {
                return "";
            }
            string field = o.ToString();
            if (field.IndexOfAny(_specialChars) != -1)
            {
                return String.Format("\"{0}\"", field.Replace("\"", "\"\""));
            }
            else return field;
        }
    }
}