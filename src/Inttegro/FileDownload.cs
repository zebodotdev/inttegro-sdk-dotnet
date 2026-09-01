namespace Inttegro;

public sealed class FileDownload
{
    public FileDownload(byte[] data, string? contentType = null)
    {
        Data = data;
        ContentType = contentType;
    }

    public byte[] Data { get; }
    public string? ContentType { get; }

    public Task SaveToAsync(string path, CancellationToken cancellationToken = default) =>
        File.WriteAllBytesAsync(path, Data, cancellationToken);
}
