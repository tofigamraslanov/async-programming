namespace AsyncProgramming.Patterns.AsynchronousProgrammingModel;

public class ApmFileReader
{
    private const int InputReportLength = 1024;
    private byte[]? _buffer;
    private FileStream? _fileStream;

    public void BeginReadAsync()
    {
        _buffer = new byte[InputReportLength];

        _fileStream = new FileStream("../../../random.txt", FileMode.Open,
                                                            FileAccess.Read,
                                                            FileShare.Read,
                                                            1024,
                                                            FileOptions.Asynchronous);

        _fileStream.BeginRead(_buffer, 0, InputReportLength, ReadCallbackAsync, _buffer);
    }

    private void ReadCallbackAsync(IAsyncResult result) => _fileStream?.EndRead(result);
}