namespace api.Helpers;

public class ResultOrError<T>
{
    public T? Result { get; set; }
    public string? Error { get; set; }

    public bool IsResult => this.Error == null;
    public bool IsError => this.Error != null;
}
