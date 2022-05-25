

using SkuskaApp.DTOs;

namespace SkuskaApp.Services;

public class COMService : ICOMService
{
    private DataContext dataContext;
    
    public COMService(DataContext dataContext)
    {
        this.dataContext = dataContext;

    }


    public void PostDataToDB(DataDTO dataDto)
    {
        this.dataContext.DataDtos.Add(dataDto);
        this.dataContext.SaveChanges();
    }
}