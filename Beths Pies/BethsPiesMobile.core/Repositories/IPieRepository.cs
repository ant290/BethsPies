using System.Collections.Generic;
using BethsPiesMobile.core.Models;

namespace BethsPiesMobile.core.Repositories
{
    public interface IPieRepository
    {
        List<Pie> GetAllPies();
        List<Category> GetCategoriesWithPies();
        Pie GetPieById(int id);
    }
}