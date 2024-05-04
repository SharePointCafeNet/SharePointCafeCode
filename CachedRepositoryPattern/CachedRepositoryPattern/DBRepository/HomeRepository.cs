using CachedRepositoryPattern.Models;
using System;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace CachedRepositoryPattern.DBRepository;

public class HomeRepository : IHomeRepository
{
    private AppDBContext _dbContext;

    public HomeRepository(AppDBContext appDBContext)
    {
        _dbContext = appDBContext;
    }

    public async Task<List<Content>> GetGoodStuff()
    {

        var data =  await _dbContext.Content.Where(p => p.IsGoodStuff == true).Take(5).OrderByDescending(d => d.Id).ToListAsync();
        return data;
    }

    public async Task<List<Content>> GetHomePageContent()
    {
        //var data = new List<Content>();
        var data = await _dbContext.Content.ToListAsync();
        return data;
    }
}
