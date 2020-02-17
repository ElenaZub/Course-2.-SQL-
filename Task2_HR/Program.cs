using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Task2_HR.Models;

namespace Task2_HR
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new zzaContext())
            {
                var customerOrder = context.Customer
                    .Where(customer => customer.FirstName == "Elena")
                    .Include(order => order.Order)
                        .ThenInclude(orderItem => orderItem.Select)
                    .FirstOrDefault();
            }
        }
    }
}
