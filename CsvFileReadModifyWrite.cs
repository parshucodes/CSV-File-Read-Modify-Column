namespace ReadModifyWriteCSVFile;

interface IApplyInterface
{
    public List<string[]> ModifyColumn(string InputFilePath, int columnIndex);
    public void saveToCsv(string OutputFilePath, List<string[]> data);
}
public class ReadModifyWriteCSVFile : IApplyInterface
{
    public string InputFilePath { get; set; }
    public string OutputFilePath { get; set; }

    public int columtomodify { get; set; }

    public List<string[]> ModifyColumn(string InputFilePath, int columnIndex)
    {
        List<string[]> modifiedData = new List<string[]>();
        try
        {
            
            string lines;
            using (StreamReader sr = new StreamReader(InputFilePath))
            {
                while ((lines = sr.ReadLine()) != null)
                {
                    string[] fields = lines.Split(',');
                    if (columnIndex < fields.Length)
                    {
                        if (fields[columnIndex] == "male")
                        {
                            fields[columnIndex] = "Handsome";
                        }
                        else
                        {
                            fields[columnIndex] = "Beautiful";
                        }
                    }
                    modifiedData.Add(fields);
                }
            }
            
        }
        catch (System.Exception e)
        {

            Console.WriteLine("the file could not be read" + e.Message);
        }
        return modifiedData;

    }

    public void saveToCsv(string OutputFilePath, List<string[]> data)
    {
        try
        {
            using (StreamWriter wr = new StreamWriter(OutputFilePath, true))
            {
                foreach (var item in data)
                {
                    wr.WriteLine(string.Join(",", item));
                }
            }
        }
        catch (System.Exception e)
        {
            
            Console.WriteLine("unable to save the file" + e.Message);
        }
    }
}