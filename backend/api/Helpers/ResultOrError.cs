namespace api.Helpers;

public class ResultOrError<T>
{
    public T? Result { get; set; }
    public string? Error { get; set; }

    public static string ServerError = "Unknown error occurred";

    public bool IsResult => this.Error == null;
    public bool IsError => this.Error != null;
}

public class ResultOrError : ResultOrError<bool>
{
}
