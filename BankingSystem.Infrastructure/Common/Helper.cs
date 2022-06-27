using BankingSystem.Domain.Models.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Infrastructure.Common
{
    public class Helper
    {
        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }


        public static ResponseModel ReturnResponse(int statusCode, string message, Object data, HttpContext context)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            return new ResponseModel
            {
                StatusCode = statusCode,
                Message = message,
                Data = data
            };

        }
    }
}
