using SkuskaApp.DTOs;

namespace SkuskaApp.Services;

public interface IFileService
{
    public void WriteToJSON(DataDTO dataDto);
    public List<DataDTO> getAll();
}