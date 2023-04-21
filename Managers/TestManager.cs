using dotnetpost.models;
using Microsoft.EntityFrameworkCore;

namespace dotnetpost.managers;

public class TestManager{
    MyDbContext _context;
    public TestManager(){
        _context = new MyDbContext();
    }

    public async Task<List<object>> GetTestResult(){
        List<object> res = new List<object>();        
        //var dbres = await _context.some_table_name.Where(x => true).ToListAsync();
        //foreach (var item in dbres){
        //    res.Add(new MiddleContainer(item));
        //}
        return res;
    }
}