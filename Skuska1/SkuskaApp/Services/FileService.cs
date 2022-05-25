using Newtonsoft.Json;
using SkuskaApp.DTOs;

namespace SkuskaApp.Services;

public class FileService : IFileService
{
    public void WriteToJSON(DataDTO dataDto)
    {
        var filePath = @"C:\Users\Dell\Desktop\Skola\LS2022\PIOT\Skuska\Skuska1\SkuskaApp\Services\user.json";
        var jsonData = System.IO.File.ReadAllText(filePath);
        var dataList = JsonConvert.DeserializeObject<List<DataDTO>>(jsonData) ?? new List<DataDTO>();
        dataList.Add(dataDto);
        jsonData = JsonConvert.SerializeObject(dataList);
        System.IO.File.WriteAllText(filePath, jsonData);
    }

    public List<DataDTO> getAll()
    {
        var filePath = @"C:\Users\Dell\Desktop\Skola\LS2022\PIOT\Skuska\Skuska1\SkuskaApp\Services\user.json";
        var jsonData = System.IO.File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<DataDTO>>(jsonData) ?? new List<DataDTO>();
    }
    
}