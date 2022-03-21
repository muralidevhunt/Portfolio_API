using Microsoft.EntityFrameworkCore;
using PortfolioAPI.IServices;
using PortfolioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioAPI.Services
{
    public class PortfolioService:IPortfolioService
    {
        APIContext dbContext;
        public PortfolioService(APIContext _db)
        {
            dbContext = _db;
        }

        public IEnumerable<Portfolio> GetInvestor()
        {
            var investor = dbContext.Portfolio.ToList();
            return investor;
        }
        public Portfolio AddInvestor(Portfolio portfolio)
        {
            if (portfolio != null)
            {
                dbContext.Portfolio.Add(portfolio);
                dbContext.SaveChanges();
                return portfolio;
            }
            return null;
        }
        public Portfolio UpdateInvestor(Portfolio portfolio)
        {
            dbContext.Entry(portfolio).State = EntityState.Modified;
            dbContext.SaveChanges();
            return portfolio;
        }

        public Portfolio DeleteInvestor(int id)
        {
            var portfolio = dbContext.Portfolio.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(portfolio).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return portfolio;
        }

        public Portfolio GetInvestorById(int id)
        {
            var portfolio = dbContext.Portfolio.FirstOrDefault(x => x.Id == id);
            return portfolio;
        }
    }
}
