using SkuskaApp.DTOs;

namespace SkuskaApp.Services;

public interface ICOMService
{
    void PostDataToDB(DataDTO dataDto);
}