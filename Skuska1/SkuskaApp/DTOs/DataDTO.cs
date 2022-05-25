namespace SkuskaApp.DTOs;

public class DataDTO
{
    public DataDTO(float temp, float hum)
    {
        this.temp = temp;
        this.hum = hum;
    }

    public void print()
    {
        Console.WriteLine(temp);
        Console.WriteLine(hum);
    }
    public int ID { get; set; }
    public float temp { get; set; }
    public float hum { get; set; }
}