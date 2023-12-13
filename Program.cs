using AsyncProgramming.Patterns.TaskBasedAsynchronousPattern;

await TaskBasedAsyncPatternHelper.FetchAndPrintUser(1);

Console.ReadLine();
    
async Task FetchDataAndSaveToFileAsync(string url, string filePath)
{
    var dataTask = FetchDataAsync(url);

    var saveDataTask = dataTask.ContinueWith(async t =>
    {
        var data = t.Result;
        
        await using var writer = new StreamWriter(filePath);
        
        await writer.WriteAsync(data);
    });

    await saveDataTask;
}

async Task<string> FetchAndProcessDataAsync()
{
    string rawData = await FetchDataAsync("https://example.com/data");

    string processedData = ProcessData(rawData);

    return processedData;
}

string ProcessData(string rawData)
{
    return rawData.ToUpper();
}

async Task<string> FetchDataAsync(string url)
{
    using var httpClient = new HttpClient();
    
    string result = await httpClient.GetStringAsync(url);

    return result;
}

// Reading a file asynchronously
async Task<string> ReadFileAsync(string filePath)
{
    using var reader = new StreamReader(filePath);
    
    string content = await reader.ReadToEndAsync();

    return content;
}

// Making multiple API calls concurrently
async Task<IEnumerable<string>> FetchMultipleDataAsync(IEnumerable<string> urls)
{
    using var httpClient = new HttpClient();

    var tasks = urls.Select(url => httpClient.GetStringAsync(url));

    string[] results = await Task.WhenAll(tasks);

    return results;
}

// Performing a CPU-bound operation asynchronously
async Task<int> CalculateResultAsync(int input)
{
    int result = await Task.Run(() => PerformComplexCalculation(input));

    return result;
}

int PerformComplexCalculation(int input)
{
    return input * 2;
}

async Task ExecuteMultipleTasksAsync()
{
    var tasks = new List<Task>
    {
        FetchDataAsync("https://example.com/data1"),
        FetchDataAsync("https://example.com/data2"),
        FetchDataAsync("https://example.com/data3")
    };

    try
    {
        await Task.WhenAll(tasks);
    }
    catch (AggregateException ex)
    {
        foreach (var innerEx in ex.InnerExceptions)
        {
        }
    }
}
